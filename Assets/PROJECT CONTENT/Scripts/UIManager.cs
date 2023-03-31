using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{

    public TextMeshProUGUI mainButtonText, titleText, score;                       // Texts that might have to be changed later

    public Canvas numbersInventory;                                         // Inventory UI element

    public Button mainButton, restartButton;                                // Main buttons

    public Button[] numberButtons;                                          // Array of number buttons

    public Sprite defaultNumberButtonSprite;                               // This is the default background sprite (image) for the number buttons

    public Slider progressSlider;                                           // Assigning the progress slider (from UI)
 
    [SerializeField] bool isInventoryOpen = false;                           // Check variable to see if Inventory is open or not

    public void Start()
    {
        ResetUI();                                                           // Resetting the UI
    }

    public void ToggleInventory()
    {
        isInventoryOpen = !isInventoryOpen;                                  // Change inventory's flag value (Switching between open & closed)

        if (isInventoryOpen)
        {
            mainButtonText.text = "GO BACK";
        }
        else
        {
            mainButtonText.text = "COLLECT";
        }

        // Hiding title text
        titleText.gameObject.SetActive(!isInventoryOpen);

        StartCoroutine(AnimateInventoryToggle(isInventoryOpen));
    }


    // RESETING THE UI
    public void ResetUI()
    {
        titleText.text = "COUNT OUT LOUD";

        score.text = "Score: 0";

        mainButton.gameObject.SetActive(true);
        numbersInventory.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);

        progressSlider.value = 0f;

        numbersInventory.transform.localScale = new Vector3(0f, 0f, 1f);

        foreach (Button button in numberButtons)
        {
            button.image.sprite = defaultNumberButtonSprite;
        }
    }

    IEnumerator AnimateInventoryToggle(bool inventoryState)
    {
        float startScale, targetScale;

        float startTime = Time.time;
        float duration = 0.2f; // animation duration

        if (inventoryState)
        {
            numbersInventory.gameObject.SetActive(true);

            startScale = 0f;
            targetScale = 1f;

            while (Time.time < startTime + duration)
            {
                float elapsed = Time.time - startTime;
                float progress = Mathf.Lerp(startScale, targetScale, elapsed / duration);
                numbersInventory.transform.localScale = new Vector3(progress, progress, 1f);
                yield return null;
            }
        }

        else
        {
            startScale = 1f;
            targetScale = 0f;

            while (Time.time < startTime + duration)
            {
                float elapsed = Time.time - startTime;
                float progress = Mathf.Lerp(startScale, targetScale, elapsed / duration);
                numbersInventory.transform.localScale = new Vector3(progress, progress, 1f);
                yield return null;
            }

            numbersInventory.gameObject.SetActive(false);
        }

        
    }

}
