using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSound : MonoBehaviour
{
    [SerializeField]
    private AudioClip _bgmclip;
    [SerializeField]
    private AudioClip _seclip;
    [SerializeField]
    private BgmPlayer _bgmPlayer;
    [SerializeField]
    private SePlayer _sePlayer;

    private IEnumerator Start()
    {
        _bgmPlayer.Play(_bgmclip);
        yield return new WaitForSeconds(1.0f);

        for (int i = 0; i < 5; i++)
        {
            _sePlayer.Play(_seclip);
            yield return new WaitForSeconds(0.2f);
        }

        _bgmPlayer.Stop();
    }
}
