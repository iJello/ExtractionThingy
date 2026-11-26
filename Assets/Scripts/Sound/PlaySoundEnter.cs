using UnityEngine.Audio;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlaySoundEnter : MonoBehaviour
{
    [SerializeField] private AudioType sound;
    [SerializeField, Range(0f, 1f)] private float volume = 1f;

    // override public void OnStateEnter(Animation animator, AnimatorStateInfo stateInfo, int layerIndex)
    // {
    //     AudioManager.PlayAudioAtPosition(sound, volume);
    // }
}
