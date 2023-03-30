using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{

    public TextMeshProUGUI mainButtonText, titleText;                       // Texts that might have to be changed later

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

        // Hiding invisible UI elements
        titleText.gameObject.SetActive(!isInventoryOpen);
        
        
        // Toggling inventory UI based on where it is open or not
        numbersInventory.gameObject.SetActive(isInventoryOpen);
    }


    // RESETING THE UI
    public void ResetUI()
    {
        titleText.text = "COUNT OUT LOUD";

        mainButton.gameObject.SetActive(true);
        numbersInventory.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);

        progressSlider.value = 0f;

        foreach (Button button in numberButtons)
        {
            button.image.sprite = defaultNumberButtonSprite;
        }
    }

}
