using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Sounds[] creatureSounds;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        if (audioSource != null)
        {
            audioSource.playOnAwake = false;
            audioSource.loop = false;
        }
    }

    public void PlayCreatureSound(string soundName)
    {
        if (audioSource == null || creatureSounds == null)
        {
            return;
        }

        Sounds sound = Array.Find(creatureSounds, s => s.name == soundName);
        
        if (sound.clip == null) 
        {
           Debug.LogError($"Sound {soundName} not found!");
            return;
        }

        PlayOneShot(sound, audioSource);
    }

    private void PlayOneShot(Sounds sound, AudioSource targetSource)
    {
        if (sound.clip == null || targetSource == null)
        {
            return;
        }
        
        targetSource.PlayOneShot(sound.clip);
    }
}
