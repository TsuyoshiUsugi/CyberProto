using UnityEngine;
using UniRx;

namespace StageSelect
{
    public class StageSelectPresenter : MonoBehaviour
    {
        [SerializeField] StageSelectView _stageSelectView;
        [SerializeField] StageSelectModel _stageSelectModel;
        // Start is called before the first frame update
        void Start()
        {
            _stageSelectView.StageSelect.Subscribe(loadStageSettings => _stageSelectModel.SelectStage(loadStageSettings));
        }
    }
}
