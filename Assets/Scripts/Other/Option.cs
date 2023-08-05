using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

[CreateAssetMenu(fileName = "Option")]
public class Option : ScriptableObject
{
    //保存する値がこれ以上増えるなら構造体にする
    float _seValue;
    float _bgmValue;

    public float defaultSeValue = 50;
    public float defaultBgmValue = 50;
    public float SEValue
    {
        get => _seValue;
        set
        {
            _seValue = value;
            seVolumeChangedSubject.OnNext(value);
        }
    }
    
    public float BGMValue
    {
        get => _bgmValue;
        set
        {
            _bgmValue = value;
            bgmVolumeChangedSubject.OnNext(value);
        }
    }

    private Subject<float> seVolumeChangedSubject = new Subject<float>();
    private Subject<float> bgmVolumeChangedSubject = new Subject<float>();
    public System.IObservable<float> SeVolumeChanged => seVolumeChangedSubject;
    public System.IObservable<float> BgmVolumeChanged => bgmVolumeChangedSubject;
    ISaveService _saveService;
    readonly string _seVolumeKey = "SeVolumeKey";
    readonly string _bgmVolumeKey = "BgmVolumeKey";

    public void Init()
    {
        _saveService = ServiceLocator.Instance.Resolve<ISaveService>();
        if (_saveService == null)
            throw new System.InvalidOperationException("セーブサービスが見つかりません");
    }
    public void Load()
    {
        if (_saveService == null)
            throw new System.InvalidOperationException("セーブサービスがInitされてません");


        if (!_saveService.Load<float>(_seVolumeKey, out float seValue))
            SEValue = defaultSeValue;
        else
            SEValue = seValue;


        if (!_saveService.Load<float>(_bgmVolumeKey, out float bgmValue))
            BGMValue = defaultBgmValue;
        else
            BGMValue = bgmValue;

    }
    public void Save()
    {
        Debug.Log("save");
        _saveService.Save(_seVolumeKey, _seValue);
        _saveService.Save(_bgmVolumeKey, _bgmValue);
    }
}
