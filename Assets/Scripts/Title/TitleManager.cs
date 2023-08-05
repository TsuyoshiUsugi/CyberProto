using UnityEngine;

namespace Title
{
    public class TitleManager : MonoBehaviour
    {
        public void MoveToStageSelect()
        {
            ServiceLocator.Instance.Resolve<ISceneTransition>().FadeOut();
        }

        public void QuitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();//�Q�[���v���C�I��
#endif
        }
    }

}

    
