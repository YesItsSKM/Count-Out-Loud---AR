using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesManager : MonoBehaviour
{
    public GameObject fireflies, confetti;

    // Start is called before the first frame update
    void Start()
    {
        ResetParticlesInTheScene();
    }

    // Update is called once per frame
    void Update()
    {
        
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
