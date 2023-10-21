using UnityEngine;

public class InGameBGMController : MonoBehaviour
{
    private AudioSource inGameBGM;

    private void Start()
    {
        inGameBGM = GetComponent<AudioSource>();
    }

    public void StartInGameBGM()
    {
        inGameBGM.Play(); // Start playing the in-game BGM
    }

    // Add any other methods to control the in-game BGM, e.g., pause, stop, or volume adjustment.
}