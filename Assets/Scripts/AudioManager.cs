using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("---------- Audio Source ----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("---------- Audio Clip ----------")]
    public AudioClip backgroundMusic;
    public AudioClip itemCollectedSFX;
    public AudioClip heartCollectedSFX;
    public AudioClip jumpSFX;
    public AudioClip fallingSFX;
    public AudioClip hitWoodSFX;
    public AudioClip wooSFX;

    // Start is called before the first frame update
    void Start()
    {
        musicSource.clip = backgroundMusic;
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void StopBackgroundMusic()
    {
        musicSource.Stop();
    }
}
