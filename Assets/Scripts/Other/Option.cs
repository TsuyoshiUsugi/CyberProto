using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

[CreateAssetMenu(fileName = "Option")]
public class Option : ScriptableObject
{
    //�ۑ�����l������ȏ㑝����Ȃ�\���̂ɂ���
    float _seValue;
    float _bgmValue;
    public Subject<float> VolumeChanged = new Subject<float>();
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
