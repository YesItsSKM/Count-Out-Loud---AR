using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{

    public TextMeshProUGUI mainButtonText, titleText;                       // Texts that might have to be changed later

    public Canvas numbersInventory;                                         // Showing the inventory UI

    public Button mainButton, restartButton;

    public Button[] numberButtons;

    public Sprite defaultNumberButtonSprite;

    public Slider progressSlider;
 
    [SerializeField] bool isInventoryOpen = false;                                            // Check variable to see if Inventory is open or not

    public void Start()
    {
        ResetUI();
    }

    public void ToggleInventory()
    {
        isInventoryOpen = !isInventoryOpen;

        if (isInventoryOpen)
        {
            mainButtonText.text = "GO BACK";
        }
        else
        {
            mainButtonText.text = "COLLECT";
        }


        titleText.gameObject.SetActive(!isInventoryOpen);
        
        numbersInventory.gameObject.SetActive(isInventoryOpen);
    }

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
