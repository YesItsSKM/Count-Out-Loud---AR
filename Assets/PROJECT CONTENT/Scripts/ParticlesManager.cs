using UnityEngine;

public class ParticlesManager : MonoBehaviour
{
    public GameObject fireflies, confetti;
    
    public GameObject confettiBurst;

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

    public void PlayCorrectNumberSelectedParticles()
    {
        GameObject smallConfettiBurst = Instantiate(confettiBurst, new Vector3(0, 2f, 5f), Quaternion.identity);
        smallConfettiBurst.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

        Destroy(smallConfettiBurst, 10f);
    }
}
