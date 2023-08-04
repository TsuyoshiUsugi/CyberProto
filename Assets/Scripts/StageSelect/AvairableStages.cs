using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace StageSelect
{
    public class AvairableStages : MonoBehaviour
    {
        [Header("ã‚©‚ç‡”Ô‚Éƒ{ƒ^ƒ“‚ÉŠ„‚èU‚ç‚ê‚Ü‚·")]
        [SerializeField] LevelSettings[] _levelSettings;
        public LevelSettings[] LevelSettings => _levelSettings;
    }
}
