using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class SePlayer : MonoBehaviour, ISePlayer
{
    [SerializeField]
    private Option _option;
    [SerializeField]
    private AudioSource _audioSource;

    public void Play(AudioClip clip)
    {
        _audioSource.PlayOneShot(clip);
    }
    private void Awake()
    {
        ServiceLocator.Instance.Register<ISePlayer>(this);
        _option.SeVolumeChanged.Subscribe(volume => _audioSource.volume = volume).AddTo(this);
    }
    private void OnDestroy()
    {
        ServiceLocator.Instance.UnRegister<ISePlayer>(this);
    }
}
