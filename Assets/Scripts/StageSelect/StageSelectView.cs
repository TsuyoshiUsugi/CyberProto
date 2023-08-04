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
            int index = 0;
            foreach (var button in _stageSelectButtons)
            {
                int inx = index;
                button.onClick.AddListener(() => StageSelect.OnNext(_avairableStages.LevelSettings[inx]));
                index++;
            }
        }
    }
}

