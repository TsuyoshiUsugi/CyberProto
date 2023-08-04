using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SePlayer : MonoBehaviour, ISePlayer
{
    [SerializeField]
    private AudioSource _audioSource;

    public void Play(AudioClip clip)
    {
        _audioSource.PlayOneShot(clip);
    }
}
