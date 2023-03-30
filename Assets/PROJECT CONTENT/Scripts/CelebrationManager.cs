using UnityEngine;

public class CelebrationManager : MonoBehaviour
{
    public GenerateNumber numberGenerator;

    public ParticlesManager particlesManager;

    public UIManager uiManager;

    public GameObject trophy;

    GameObject trophyOnScreen;                                  // This object holds the trophy. Will use this for spawning & destroying the trophy object

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // This method handles the game end celebration
    public void GameEndCelebration()
    {
        Debug.Log("THANK YOU FOR PLAYING!!");

        Destroy(numberGenerator.numberOnScreen);

        trophyOnScreen = Instantiate(trophy, numberGenerator.numberOnScreenSpawningTransform.transform);

        // Setting trophy's transform
        trophyOnScreen.transform.localPosition = new Vector3(0, 0, -0.3f);
        trophyOnScreen.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        trophyOnScreen.transform.localRotation = Quaternion.Euler(90, 0, 0);

        uiManager.titleText.text = "WINNER!";

        uiManager.mainButton.gameObject.SetActive(false);
        uiManager.restartButton.gameObject.SetActive(true);

        particlesManager.PlayGameWinnerParticles();

    }


    // METHOD FOR RESTARTING THE GAME
    public void RestartGame()
    {
        Destroy(trophyOnScreen);
        
        numberGenerator.usedNumbers.Clear();

        uiManager.ResetUI();

        particlesManager.ResetParticlesInTheScene();

        numberGenerator.GenerateNumberMain();
    }
}
