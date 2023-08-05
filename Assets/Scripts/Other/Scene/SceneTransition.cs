using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour,ISceneTransition
{
    [SerializeField,Scene]
    private string _nextSceneName;
    [HorizontalLine(color: EColor.Red)]
    [SerializeField]
    private Image _animationImage;
    [SerializeField]
    private List<Sprite> _animationSprites;
    [SerializeField]
    private float _animationInterval = 0.1f;

    [HorizontalLine(color: EColor.Red)]
    [SerializeField]
    private Image _fadeImage;
    [SerializeField]
    private float _fadeTime = 0.5f;
    private void Awake()
    {
        ServiceLocator.Instance.Register<ISceneTransition>(this);
    }

    public void FadeOut()
    {
        StartCoroutine(FadeOutCoroutine(_nextSceneName));
    }
    public void FadeOut(string sceneName)
    {
        StartCoroutine(FadeOutCoroutine(sceneName));
    }
    private IEnumerator FadeOutCoroutine(string sceneName)
    {
        _fadeImage.enabled = true;

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        asyncLoad.allowSceneActivation = false;


        yield return ForAction01(_fadeTime, t =>
        {
            _fadeImage.color = new Color(0, 0, 0, t);
        });

        _animationImage.enabled = true;
        
        while (!asyncLoad.isDone)
        {
            yield return AnimationImage();
            if (asyncLoad.progress >= 0.9f)
            {
                asyncLoad.allowSceneActivation = true;
                break;
            }
        }
    }
    private IEnumerator AnimationImage()
    {
        foreach (var sprite in _animationSprites)
        {
            _animationImage.sprite = sprite;
            yield return new WaitForSeconds(_animationInterval);
        }
    }

    private IEnumerator ForAction01(float second, Action<float> action)
    {
        float time = 0;
        while (time < second)
        {
            yield return null;
            time += Time.deltaTime;
            action(time / second);
        }
    }

    private void OnDestroy()
    {
        ServiceLocator.Instance.UnRegister<ISceneTransition>(this);
    }
}
