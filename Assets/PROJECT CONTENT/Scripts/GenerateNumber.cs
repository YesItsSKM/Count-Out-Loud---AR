using UnityEngine;

public class GenerateNumber : MonoBehaviour
{
    public int numberIndex;                                     // The number that will be randomly generated

    public GameObject[] NumberMeshes;                           // Array the 3D models of the numbers to be spawned

    public GameObject numberOnScreen;                           // The number which is spawed on the screen

    public Transform numberOnScreenSpawningTransform;          // Transform to spawn the number in the right place

    // Start is called before the first frame update
    void Start()
    {
        GenerateNumberMain();                           // Calling the main function that handles the number generation & spawning functionalites
    }

    
    // The main function that handles the number generation & spawning functionalites
    public void GenerateNumberMain()
    {
        int randomNumber = Random.Range(1, 11);         // Generating a random number between [1-10] (both inclusive)

        numberIndex = randomNumber;                     // Assigning the number index - This will be the number that will be spawned

        Destroy(numberOnScreen);                        // Destroy any previously spawned number

        // Instantiating the number on screen based on the generated randomNumber
        numberOnScreen = Instantiate(NumberMeshes[numberIndex - 1], numberOnScreenSpawningTransform.transform);        

        // Setting it's transform to zero as the number will inherit it's parent's transform
        numberOnScreen.transform.localPosition = new Vector3(0, 0, 0);
        numberOnScreen.transform.localRotation = Quaternion.identity;
    }

}
