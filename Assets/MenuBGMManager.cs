using UnityEngine;

public class MenuBGMController : MonoBehaviour
{
    private AudioSource bgmAudioSource;

    private void Start()
    {
        bgmAudioSource = GetComponent<AudioSource>();
        // Start playing the BGM
        bgmAudioSource.Play();
    }

    public void PlayBGM()
    {
        // Play the BGM (if not already playing)
        if (!bgmAudioSource.isPlaying)
        {
            bgmAudioSource.Play();
        }
    }

    public void StopBGM()
    {
        // Stop the BGM
        bgmAudioSource.Stop();
    }
}