using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    [SerializeField]
    private Image _image;
    [SerializeField]
    private float _fadeTime = 0.5f;
    void Start()
    {
        StartCoroutine(FadeInCorotine());

    }
    IEnumerator FadeInCorotine()
    {
        _image.enabled = true;
        yield return ForAction01(_fadeTime, t => 
        {
            _image.color = new Color(0, 0, 0, 1 - t);
        });
        _image.enabled = false;
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
}
