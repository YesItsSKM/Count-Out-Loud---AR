using UnityEngine;

public class ParticlesManager : MonoBehaviour
{
    public GameObject fireflies, confetti;

    // Start is called before the first frame update
    void Start()
    {
        ResetParticlesInTheScene();
    }

    public void ResetParticlesInTheScene()
    {
        fireflies.gameObject.SetActive(true);
        confetti.gameObject.SetActive(false);
    }

    public void PlayGameWinnerParticles()
    {
        fireflies.gameObject.SetActive(false);
        confetti.gameObject.SetActive(true);
    }
}
