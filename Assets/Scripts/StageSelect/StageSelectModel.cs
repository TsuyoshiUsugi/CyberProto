using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectModel : MonoBehaviour
{
    [SerializeField] GameContext _gameContext; 

    public void SelectStage(LevelSettings loadLevel)
    {
        _gameContext.levelSettings = loadLevel;
        ServiceLocator.Instance.Resolve<ISceneTransition>().FadeOut();
    }
}
