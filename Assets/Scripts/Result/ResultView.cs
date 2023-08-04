using System.Collections;
using System.Collections.Generic;
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

        // Start is called before the first frame update
        void Start()
        {
            
        }

        public void Replay()
        {
            _replay.onClick.AddListener(SceneManager.LoadScene());
        }

        void ReturnToStateSelect()
        {

        }
    }
}
