using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace StageSelect
{
    public class AvairableStages : MonoBehaviour
    {
        [Header("上から順番にボタンに割り振られます")]
        [SerializeField] LevelSettings[] _levelSettings;
        public LevelSettings[] LevelSettings => _levelSettings;
    }
}
