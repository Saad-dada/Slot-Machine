using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Clips")]
    public AudioClip leverPull;
    public AudioClip reelTick;
    public AudioClip reelStop;
    public AudioClip winSound;

    private AudioSource source;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        source = GetComponent<AudioSource>();
    }

    public void Play(AudioClip clip, float volume = 1f)
    {
        if (clip == null) return;
        source.PlayOneShot(clip, volume);
    }
}