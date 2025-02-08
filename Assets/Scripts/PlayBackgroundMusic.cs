using UnityEngine;

public class PlayBackgroundMusic : MonoBehaviour
{
    public AudioClip music;
    private AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    audioSource = GetComponent<AudioSource>();
    audioSource.clip = music;
    audioSource.loop = true;
    audioSource.Play();  
    }

}
