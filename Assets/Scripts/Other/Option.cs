using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

[CreateAssetMenu(fileName = "Option")]
public class Option : ScriptableObject
{
    //•Û‘¶‚·‚é’l‚ª‚±‚êˆÈã‘‚¦‚é‚È‚ç\‘¢‘Ì‚É‚·‚é
    float _seValue;
    float _bgmValue;
    public float SEValue
    {
        get => _seValue;
        set
        {
            _seValue = value;
            SeVolumeChanged.OnNext(value);
        }
    }
    
    public float BGMValue
    {
        get => _bgmValue;
        set
        {
            _bgmValue = value;
            BgmVolumeChanged.OnNext(value);
        }
    }

    public Subject<float> SeVolumeChanged = new Subject<float>();
    public Subject<float> BgmVolumeChanged = new Subject<float>();
    ISaveService _saveService;
    readonly string _seVolumeKey = "";
    readonly string _bgmVolumeKey = "";

    private void OnEnable()
    {
        _saveService = ServiceLocator.Instance.Resolve<ISaveService>();

        if (_saveService.Load<float>(_seVolumeKey, out _seValue))
        {

        }

        if (_saveService.Load<float>(_bgmVolumeKey, out _bgmValue))
        {

        }
        
    }
}
