using UnityEngine;
using UnityEngine.Audio;

public class Sound : MonoBehaviour
{
    public AudioClip clip;

    public float volume;
    public float pitch;
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.instance.PlaySound(clip);
    }

    // Update is called once per frame
   
}
