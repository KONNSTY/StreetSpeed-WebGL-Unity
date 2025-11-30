using UnityEngine;

public class AudioManger : MonoBehaviour
{
    public static AudioManger audioManger;

    public AudioClip Music;

    private static bool isMuted = false;
    private AudioSource audioSource;

    void Awake()
    {
        if (audioManger == null)
        {
            audioManger = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (audioManger != this)
        {
            Destroy(gameObject);
            return;
        }
        
        audioSource = GetComponent<AudioSource>();
        if(audioSource != null && Music != null)
        {
            audioSource.clip = Music;
            audioSource.loop = true;
            audioSource.volume = 0.5f;
            audioSource.Play();
        }
    }

    public static void MuteGame(bool mute)
    {
       isMuted = mute;
    }

    void Update()
    {
        if(audioSource != null)
        {
            if(isMuted && audioSource.isPlaying)
            {
                audioSource.Pause();
            }
            else if(!isMuted && !audioSource.isPlaying)
            {
                audioSource.UnPause();
            }
        }
    }


}
