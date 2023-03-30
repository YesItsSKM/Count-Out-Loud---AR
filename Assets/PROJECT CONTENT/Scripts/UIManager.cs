using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI mainButtonText, titleText;                       // Texts that might have to be changed later

    public Canvas numbersInventory;                                         // Showing the inventory UI

    bool isInventoryOpen = false;                                            // Check variable to see if Inventory is open or not

    public void Start()
    {
        
    }

    public void ToggleInventory()
    {
        isInventoryOpen = !isInventoryOpen;

        if (isInventoryOpen)
        {
            mainButtonText.text = "Go Back";
        }
        else
        {
            mainButtonText.text = "Collect";
        }


        titleText.gameObject.SetActive(!isInventoryOpen);
        
        numbersInventory.gameObject.SetActive(isInventoryOpen);
    }

}
