using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public Sound[] sounds;
    [SerializeField] private AudioSource musicSource, effectSource;
    public static SoundManager instance;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }
    private void Start()
    {
    }
    public void PlaySound(AudioClip clip) {
        effectSource.PlayOneShot(clip);
    }

    public void changeMasterVolume(float volume)
    {
        Debug.Log(volume);
        AudioListener.volume = volume;
    }
}
