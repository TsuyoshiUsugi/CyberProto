using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game
{
    public class ResultView : MonoBehaviour
    {
        [SerializeField] ResultContext _resultContext;
        [SerializeField] Button _stageSelect;
        [SerializeField] Button _replay;
        [SerializeField] string _sceneSelectName = "";
        [SerializeField] int _rankSBorder = 100;
        [SerializeField] int _rankABorder = 80;
        [SerializeField] int _rankBBorder = 70;

        [Header("�X�R�A�̎Q�ƈꗗ")]
        [SerializeField] Text _scoreText;
        [SerializeField] Text _orderCompleteNum;
        [SerializeField] Text _popularity;
        [SerializeField] Text _resultRank;

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
            _scoreText.text = _resultContext._score.ToString();
            _orderCompleteNum.text = _resultContext._orderCompleteNum.ToString();
            _popularity.text = _resultContext._populality.ToString();
            _resultRank.text = CalculateRank(_resultContext._score).ToString();
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
            var currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }

        void ReturnToSceneSelect()
        {
            SceneManager.LoadScene(_sceneSelectName);
        }
    }
}
