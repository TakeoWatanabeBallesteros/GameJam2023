using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public AudioClip m_clip;

    [Range(0f,1f)]
    public float m_volume;
    [Range(.1f, 3f)]
    public float m_pitch;

    public string name;

    [HideInInspector]
    public AudioSource source;
}
