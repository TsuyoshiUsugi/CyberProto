using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace StageSelect
{
    public class AvairableStages : MonoBehaviour
    {
        [SerializeField] LevelSettings[] _levelSettings;
        public LevelSettings[] LevelSettings => _levelSettings;
    }
}
