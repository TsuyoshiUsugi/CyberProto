using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace StageSelect
{
    public class AvairableStages : MonoBehaviour
    {
        [Header("�ォ�珇�ԂɃ{�^���Ɋ���U���܂�")]
        [SerializeField] LevelSettings[] _levelSettings;
        public LevelSettings[] LevelSettings => _levelSettings;
    }
}
