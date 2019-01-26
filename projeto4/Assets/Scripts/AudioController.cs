using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioController : MonoBehaviour
{
    public sound[] sounds;

    public static AudioController instance;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        foreach (sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

     void Start()
    {
        Play("Theme");
    }

    public void Play(string name)
    {
       sound s = Array.Find(sounds, sound => sound.name == name);

        //Verificar se houve erros ao por o nome do som
        if(s == null)
        {
            Debug.LogWarning("Sound: " +name + "not found!");
            return;
        }

        s.source.Play();
    }
}
