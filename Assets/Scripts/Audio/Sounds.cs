using System;
using UnityEngine;

[Serializable]
public struct Sounds
{
    public string name;
    public AudioClip clip;
    [Range(0f, 1f)] public float volume;
}