using System.Collections.Generic;
using UnityEngine;

public class GenerateNumber : MonoBehaviour
{
    public CelebrationManager celebrationManager;

    //public UIManager uiManager;

    public int numberIndex;                                     // The number that will be randomly generated

    public GameObject[] NumberMeshes;                           // Array the 3D models of the numbers to be spawned

    public GameObject numberOnScreen;                           // The number which is spawed on the screen

    public Transform numberOnScreenSpawningTransform;          // Transform to spawn the number in the right place

    private System.Random randomNumberGenerator = new System.Random();
    public List<int> usedNumbers = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        GenerateNumberMain();                           // Calling the main function that handles the number generation & spawning functionalites
    }

    
    // The main function that handles the number generation & spawning functionalites
    public void GenerateNumberMain()
    {
        if (usedNumbers.Count >= 10)
        {
            Debug.Log("All numbers have been generated!");

            celebrationManager.GameEndCelebration();

            return;
        }

        int randomNum = randomNumberGenerator.Next(1, 11);            // int num = rand.Next(1, 11);
       

        // Keep generating random numbers until it's not yet generated
        while (usedNumbers.Contains(randomNum))
        {
            randomNum = randomNumberGenerator.Next(1, 11);
        }
        usedNumbers.Add(randomNum);

        numberIndex = randomNum;                        // Assigning the number index - This will be the number that will be spawned

        Destroy(numberOnScreen);                        // Destroy any previously spawned number

        // Instantiating the number on screen based on the generated randomNumber
        numberOnScreen = Instantiate(NumberMeshes[numberIndex - 1], numberOnScreenSpawningTransform.transform);        

        // Setting it's transform to zero as the number will inherit it's parent's transform
        numberOnScreen.transform.localPosition = new Vector3(0, 0, 0);
        numberOnScreen.transform.localRotation = Quaternion.identity;
    }

}
