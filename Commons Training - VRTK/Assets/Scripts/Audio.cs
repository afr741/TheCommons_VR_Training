using UnityEngine;

public class Audio : MonoBehaviour {

    private AudioSource source;

    public AudioClip correct;
    public AudioClip wrong;
    public AudioClip loginToLinux;
    public AudioClip registerForMath1000;
    public AudioClip noVideo;
    public AudioClip noFiles;
    public AudioClip balanceNegative;
    public AudioClip noLogin;
    public AudioClip noEmail;
  
    public float volume = .25f;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void wrongSound()
    {
        source.PlayOneShot(wrong, volume);
    }

    public void correctSound()
    {
        source.PlayOneShot(correct, volume);
    }


    public void loginToLinuxSound()
    {
        source.PlayOneShot(loginToLinux, volume);
    }

    public void registerForMath1000Sound()
    {
        source.PlayOneShot(registerForMath1000, volume);
    }

    public void noVideoSound()
    {
        source.PlayOneShot(noVideo, volume);
    }
    public void noFilesSound()
    {
        source.PlayOneShot(noFiles, volume);
    }
    public void balanceNegativeSound()
    {
        source.PlayOneShot(balanceNegative, volume);
    }
    public void noLoginSound()
    {
        source.PlayOneShot(noLogin, volume);
    }
    public void noEmailSound()
    {
        source.PlayOneShot(noEmail, volume);
    }

}
