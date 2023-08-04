using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace StageSelect
{
    public class StageSelectView : MonoBehaviour
    {
        [SerializeField] AvairableStages _avairableStages;
        [SerializeField] List<Button> _stageSelectButtons;

        public Subject<LevelSettings> StageSelect = new();
        // Start is called before the first frame update
        void Start()
        {
            for (int i = 0; i < _stageSelectButtons.Count; i++)
            {
                _stageSelectButtons[i].onClick.AddListener(() => StageSelect.OnNext(_avairableStages.LevelSettings[i]));
            }
        }
    }
}

