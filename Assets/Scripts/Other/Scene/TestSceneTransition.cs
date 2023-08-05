using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSceneTransition : MonoBehaviour
{
    [SerializeField]
    private SceneTransition _transition;

    private void Start()
    {
        _transition.FadeOut();

    }
}
