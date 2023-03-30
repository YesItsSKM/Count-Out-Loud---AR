using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberPickerManager : MonoBehaviour
{
    public UIManager uiManager;                                             // Accessing the UI Manager Class

    public GenerateNumber generatedNumber;                                  // Accessing the Generated Number Class

    public Sprite numCollectedSprite;                                       // Button background - Which gets updated once the user gets the number right

    Dictionary<string, int> tagToNumberMap;                                  // Defining the dictionary to map tags to numbers

    public float progress = 0f;                                              // Slider progress

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

                uiManager.progressSlider.value += 0.1f;                 // Correct number picked; Updating progress

                uiManager.numberButtons[pickedNum - 1].image.sprite = numCollectedSprite;       // Changing that button's backgound sprite to show that number has been chosen

                // TO DO: CUE THE PARTICLE EFFECTS

                uiManager.ToggleInventory();                        // Toggling the inventory - OFF

                generatedNumber.GenerateNumberMain();               // Generating another number
            }
            else
            {
                Debug.Log("Sorry try again!");                      // Wrong button pressed - Don't change anything
            }
        }
        else
        {
            Debug.LogWarning("No corresponding number found for tag: " + buttonTag);        // No button tag was found
        }
    }
}
