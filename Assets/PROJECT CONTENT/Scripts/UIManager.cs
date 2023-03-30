using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public GenerateNumber generatedNumber;                                  // Accessing the Generated Number Class

    public TextMeshProUGUI mainButtonText, titleText;                       // Texts that might have to be changed later

    public Canvas numbersInventory;                                         // Showing the inventory UI

    bool isInventoryOpen = false;                                            // Check variable to see if Inventory is open or not

    public Button[] numButton;                                              // Array of number buttons
    
    public Sprite numCollectedSprite;                                       // Button background - Which gets updated once the user gets the number right

    // Define the dictionary to map tags to numbers
    Dictionary<string, int> tagToNumberMap;

    public void Start()
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
        for (int i = 0; i < numButton.Length; i++)
        {
            Button button = numButton[i];
            button.onClick.RemoveAllListeners(); // Remove any existing listeners
            button.onClick.AddListener(delegate { PickTheNumber(button.tag); });
        }
    }

    public void ToggleInventory()
    {
        isInventoryOpen = !isInventoryOpen;

        mainButtonText.text = "Go Back";

        titleText.gameObject.SetActive(!isInventoryOpen);
        
        numbersInventory.gameObject.SetActive(isInventoryOpen);
    }

    public void PickTheNumber(string buttonTag)
    {

        // Get the corresponding number from the dictionary
        int pickedNum;
        if (tagToNumberMap.TryGetValue(buttonTag, out pickedNum))
        {

            if (pickedNum == generatedNumber.numberIndex)
            {
                Debug.Log("Yay!");

                numButton[pickedNum - 1].image.sprite = numCollectedSprite;

                // TO DO: CUE THE PARTICLE EFFECTS

                StartCoroutine(DelayMethod());

                ToggleInventory();

                generatedNumber.GenerateNumberMain();
            }
            else
            {
                Debug.Log("Sorry try again!");
            }
        }
        else
        {
            Debug.LogWarning("No corresponding number found for tag: " + buttonTag);
        }
    }



    IEnumerator DelayMethod()
    {
        Debug.Log("Starting delayed method.");
        yield return new WaitForSeconds(1.0f);
        Debug.Log("Delayed method finished.");
    }

}
