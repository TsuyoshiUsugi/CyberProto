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
  [SerializeField]
  private Material _transitionIn;

  void Start()
  {
    StartCoroutine(FadeInCorotine());

  }
  IEnumerator FadeInCorotine()
  {
    _image.enabled = true;
    _image.material = _transitionIn;

    yield return ForAction01(_fadeTime, _transitionIn, t =>
    {
      _image.color = new Color(0, 0, 0, 1 - t);
    });
    _image.enabled = false;
  }

  private IEnumerator ForAction01(float second, Material material, Action<float> action)
  {
    float time = 0;
    material.SetColor("_Color", _image.color);
    while (time < second)
    {
      material.SetFloat("_Alpha", 1 - time / second);

      yield return new WaitForEndOfFrame();
      time += Time.deltaTime;
      //   action(time / second);
    }
    material.SetFloat("_Alpha", 0);
  }
}
