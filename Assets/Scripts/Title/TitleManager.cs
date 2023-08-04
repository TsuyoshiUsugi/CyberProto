using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Title
{
    public class TitleManager : MonoBehaviour
    {
        [SerializeField] string _stageSelectSceneName = "";

        public void MoveToStageSelect()
        {
            SceneManager.LoadScene(_stageSelectSceneName);
        }

        public void QuitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();//ゲームプレイ終了
#endif
        }
    }

}

    
