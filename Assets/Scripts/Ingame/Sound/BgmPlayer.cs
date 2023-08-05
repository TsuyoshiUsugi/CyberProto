using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmPlayer : MonoBehaviour, IBgmPlayer
{
    [SerializeField]
    private AudioSource _audioSource;
    [SerializeField]
    private float _fadeOutSpeed = 1.0f;

    private bool _isFadingOut = false;
    public void Play(AudioClip clip)
    {
        _audioSource.clip = clip;
        _audioSource.Play();
    }

    public void Stop()
    {
        if(_isFadingOut)
            throw new System.InvalidOperationException("フェードアウト中です");

        StartCoroutine(FadeOutStopCoroutine());
    }

    private IEnumerator FadeOutStopCoroutine()
    {
        _isFadingOut = true;

        float startVolume = _audioSource.volume;
        float currentVolume = startVolume;


        while(true)
        {
            currentVolume -= Time.deltaTime * _fadeOutSpeed;   
            
            if(currentVolume <= 0.0f)
            {
                currentVolume = 0;
                break;
            }

            _audioSource.volume = currentVolume;
            yield return null;
        }

        _audioSource.Stop();
        _isFadingOut = false;
        _audioSource.volume = startVolume;
    }

    private void Awake()
    {
        ServiceLocator.Instance.Register<IBgmPlayer>(this);
    }
    private void OnDestroy()
    {
        ServiceLocator.Instance.UnRegister<IBgmPlayer>(this);
    }
}
