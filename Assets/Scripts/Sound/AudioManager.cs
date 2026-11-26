using UnityEngine.Audio;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
public enum AudioType
{
    Piniorb,
    Piniorb2,
    Piniorb3,
    Piniorb4
}

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] soundList;
    private static AudioManager instance;
    private AudioSource audioSource;

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
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public static void PlayAudioAtPosition(AudioType sound, float volume = 1)
    {
        if (instance != null)
        {
            instance.audioSource.PlayOneShot(instance.soundList[(int)sound], volume);
        }
    }
}