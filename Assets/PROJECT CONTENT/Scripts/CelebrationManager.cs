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
        trophyOnScreen.transform.localPosition = new Vector3(0, 0, -0.003f);
        trophyOnScreen.transform.localScale = new Vector3(0.003f, 0.003f, 0.003f);
        trophyOnScreen.transform.localRotation = Quaternion.Euler(90, 0, 0);

        uiManager.titleText.text = "WINNER!";

        uiManager.mainButton.gameObject.SetActive(false);
        uiManager.restartButton.gameObject.SetActive(true);

        particlesManager.PlayGameWinnerParticles();

        uiManager.CallTextPrompt("You did great. You won!!", 2f);

        if (numberGenerator.audioManager.numbersAudioSource.isPlaying)
        {
            numberGenerator.audioManager.numbersAudioSource.Stop();
        }

        numberGenerator.audioManager.gameAudioSource.clip = numberGenerator.audioManager.audioClips[3];

        numberGenerator.audioManager.gameAudioSource.Play();
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
