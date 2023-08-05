using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

[CreateAssetMenu(fileName = "Option")]
public class Option : ScriptableObject
{
    //ï€ë∂Ç∑ÇÈílÇ™Ç±ÇÍà»è„ëùÇ¶ÇÈÇ»ÇÁç\ë¢ëÃÇ…Ç∑ÇÈ
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
