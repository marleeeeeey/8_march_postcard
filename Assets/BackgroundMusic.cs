using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private AudioSource audioSource;   // Компонент AudioSource

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.Play();
    }

}