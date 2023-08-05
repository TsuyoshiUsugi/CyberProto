using UnityEngine;
using UnityEngine.UI;
using UniRx;
using TMPro;

namespace Game
{
    public class ResultView : MonoBehaviour
    {
        [SerializeField] ResultContext _resultContext;
        [SerializeField] Button _stageSelect;
        [SerializeField] Button _replay;
        [SerializeField] int _rankSBorder = 100;
        [SerializeField] int _rankABorder = 80;
        [SerializeField] int _rankBBorder = 70;

        [Header("�X�R�A�̎Q�ƈꗗ")]
        [SerializeField] GameObject _resultCanvas;
        [SerializeField] TextMeshProUGUI _scoreText;
        [SerializeField] TextMeshProUGUI _orderCompleteNum;
        [SerializeField] TextMeshProUGUI _popularity;
        [SerializeField] TextMeshProUGUI _resultRank;

        private void Awake()
        {
            ServiceLocator.Instance.Resolve<IGameDirector>().State.Where(state => state == GameState.End).Subscribe(_ => ShowResult());
        }

        // Start is called before the first frame update
        void Start()
        {
            _replay.onClick.AddListener(() => Replay());
            _stageSelect.onClick.AddListener(() => ReturnToSceneSelect());
        }

        /// <summary>
        /// �\���������
        /// ����̃X�R�A
        /// �񋟂ł����l��
        /// �]���n
        /// �]��
        /// �n�C�X�R�A�H
        /// </summary>
        public void ShowResult()
        {
            _resultCanvas.SetActive(true);
            _scoreText.text = $"{_resultContext._score} G";
            _orderCompleteNum.text = $"������񋟏o������ {_resultContext._orderCompleteNum} �l";
            _popularity.text = $"�]�� {_resultContext._populality:F1}";
            _resultRank.text = $"�]�� {CalculateRank(_resultContext._score)}";
        }

        ResultRank CalculateRank(int score)
        {
            if (score >= _rankSBorder)
            {
                return ResultRank.S;
            }
            else if (score >= _rankABorder)
            {
                return ResultRank.A;
            }
            else if (score >= _rankBBorder)
            {
                return ResultRank.B;
            }
            else
            {
                return ResultRank.C;
            }
        }

        enum ResultRank
        {
            S,
            A,
            B,
            C,
        }

        void Replay()
        {
            ServiceLocator.Instance.Resolve<ISceneTransition>().FadeOut();
        }

        void ReturnToSceneSelect()
        {
            ServiceLocator.Instance.Resolve<ISceneTransition>().FadeOut();
        }
    }
}
