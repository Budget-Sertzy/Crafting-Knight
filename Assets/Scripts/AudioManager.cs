using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource sfxSource;

    [Header("Music")]
    public AudioClip backgroundMusic;
    [Range(0f, 1f)] public float musicVolume = 0.5f;

    [Header("SFX")]
    [Range(0f, 1f)] public float sfxVolume = 1f;

    [Header("Common SFX")]
    public AudioClip swordSFX;
    public AudioClip hitSFX;
    public AudioClip shootSFX;
    public AudioClip gameoverSFX;

    private void Awake()
    {
        // Simple singleton
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // keep music between scenes
    }

    private void Start()
    {
        // Start background music
        if (backgroundMusic != null)
        {
            PlayMusic(backgroundMusic);
        }
    }

    public void PlayMusic(AudioClip clip, bool loop = true)
    {
        if (clip == null || musicSource == null) return;

        musicSource.clip = clip;
        musicSource.loop = loop;
        musicSource.volume = musicVolume;
        musicSource.Play();
    }

    public void StopMusic()
    {
        if (musicSource == null) return;
        musicSource.Stop();
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip == null || sfxSource == null) return;

        sfxSource.volume = sfxVolume;
        sfxSource.PlayOneShot(clip);
    }
}
