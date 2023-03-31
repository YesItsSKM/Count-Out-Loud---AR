using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NumberPickerManager : MonoBehaviour
{
    public UIManager uiManager;                                             // Accessing the UI Manager Class

    public GenerateNumber generatedNumber;                                  // Accessing the Generated Number Class

    public ParticlesManager particlesManager;

    public AudioManager audioManager;

    public Sprite numCollectedSprite;                                       // Button background - Which gets updated once the user gets the number right

    Dictionary<string, int> tagToNumberMap;                                  // Defining the dictionary to map tags to numbers

    float progress = 0f;                                                     // Slider progress

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the dictionary
        tagToNumberMap = new Dictionary<string, int>();

        // Add mappings for tags num1 to num10 to numbers 1 to 10
        for (int i = 1; i <= 10; i++)
        {
            string tag = "num" + i;
            int num = i;
            tagToNumberMap.Add(tag, num);
        }

        // Loop through each button and add a listener to its onClick event
        for (int i = 0; i < uiManager.numberButtons.Length; i++)
        {
            Button button = uiManager.numberButtons[i];
            button.onClick.RemoveAllListeners(); // Remove any existing listeners
            button.onClick.AddListener(delegate { PickTheNumber(button.tag); });
        }
    }


    // THIS METHOD HANDLES PICKING NUMBERS WHEN INVENTORY IS OPEN
    public void PickTheNumber(string buttonTag)
    {
        // Getting the corresponding number from the dictionary
        int pickedNum;
        if (tagToNumberMap.TryGetValue(buttonTag, out pickedNum))
        {

            if (pickedNum == generatedNumber.numberIndex)
            {
                Debug.Log("Yay!");

                audioManager.numbersAudioSource.clip = audioManager.audioClips[2];

                audioManager.numbersAudioSource.Play();

                progress = uiManager.progressSlider.value;                 // Correct number picked; Updating progress

                progress += 0.1f;

                uiManager.score.text = "Score: " + Mathf.FloorToInt(progress*100);

                StartCoroutine(AnimateProgressBar(progress));

                uiManager.numberButtons[pickedNum - 1].image.sprite = numCollectedSprite;       // Changing that button's backgound sprite to show that number has been chosen

                particlesManager.PlayCorrectNumberSelectedParticles();

                StartCoroutine(ToggleInventoryOff());

                generatedNumber.GenerateNumberMain();               // Generating another number
            }
            else
            {
                audioManager.numbersAudioSource.clip = audioManager.audioClips[1];

                audioManager.numbersAudioSource.Play();

                Debug.Log("Sorry try again!");                      // Wrong button pressed - Don't change anything
            }
        }
        else
        {
            Debug.LogWarning("No corresponding number found for tag: " + buttonTag);        // No button tag was found
        }
    }

    IEnumerator ToggleInventoryOff()
    {
        yield return new WaitForSeconds(2f);

        uiManager.ToggleInventory();                        // Toggling the inventory - OFF
    }

    IEnumerator AnimateProgressBar(float targetProgress)
    {
        float startTime = Time.time;
        float startProgress = uiManager.progressSlider.value;
        float duration = 1f; // 1 second animation duration

        while (Time.time < startTime + duration)
        {
            float elapsed = Time.time - startTime;
            float progress = Mathf.Lerp(startProgress, targetProgress, elapsed / duration);
            uiManager.progressSlider.value = progress;
            yield return null;
        }

        uiManager.progressSlider.value = targetProgress;
    }
}
