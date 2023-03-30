using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelebrationManager : MonoBehaviour
{
    public GenerateNumber numberGenerator;

    public GameObject trophy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameEndCelebration()
    {
        Debug.Log("THANK YOU FOR PLAYING!!");

        Destroy(numberGenerator.numberOnScreen);

        GameObject trophyOnScreen = Instantiate(trophy, numberGenerator.numberOnScreenSpawningTransform.transform);

        // Setting trophy's transform
        trophyOnScreen.transform.localPosition = new Vector3(0, 0, -0.3f);
        trophyOnScreen.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        trophyOnScreen.transform.localRotation = Quaternion.Euler(90, 0, 0);
    }
}
