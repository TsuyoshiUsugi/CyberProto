using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using TMPro;
using DG.Tweening;

namespace Title
{
  public class TitleView : MonoBehaviour
  {
    [SerializeField] Button _openStageSelectButton;
    [SerializeField] Button _quitStageSelectButton;
    [SerializeField] Button _quitGameButton;
    [SerializeField] Button _openOptionButton;
    [SerializeField] Button _exitOptionButton;
    [SerializeField] GameObject _optionObject;
    [SerializeField] GameObject _stageSelectObject;
    [SerializeField] Image _optionBack;
    [SerializeField] Image _stageSelectBack;

    public Subject<Unit> QuitButtonClicked = new Subject<Unit>();

    // Start is called before the first frame update
    void Start()
    {
      if (_optionObject) _optionObject.SetActive(false);
      if (_stageSelectObject) _stageSelectObject.SetActive(false);

      _openStageSelectButton.onClick.AddListener(() =>
      {
        if (!_optionObject.activeSelf)
        {
          var seq = DOTween.Sequence()
                .OnStart(() =>
                {
                  _stageSelectBack.transform.localScale = Vector3.zero;
                  _stageSelectObject.SetActive(true);
                })
                .Append(_stageSelectBack.transform.DOScale(1.0f, 0.1f).SetEase(Ease.OutBack))
                .Play();
        }
      });

      _quitStageSelectButton.onClick.AddListener(() =>
      {
        if (!_optionObject.activeSelf)
        {
          var seq = DOTween.Sequence()
                .Append(_stageSelectBack.transform.DOScale(0.0f, 0.1f).SetEase(Ease.InBack))
                .OnComplete(() =>
                {
                  _stageSelectBack.transform.localScale = Vector3.one;
                  _stageSelectObject.SetActive(false);
                })
                .Play();
        }
      });

      _quitGameButton.onClick.AddListener(() =>
      {
        if (!_optionObject.activeSelf)
          QuitButtonClicked.OnNext(Unit.Default);
      });
      _openOptionButton.onClick.AddListener(() =>
      {
        var seq = DOTween.Sequence()
              .OnStart(() =>
              {
                _openStageSelectButton.enabled = false;
                _quitGameButton.enabled = false;

                _optionBack.transform.localScale = Vector3.zero;
                _optionObject?.SetActive(true);
              })
              .Append(_optionBack.transform.DOScale(1.0f, 0.1f).SetEase(Ease.OutBack))
              .Play();
      });

      _exitOptionButton.onClick.AddListener(() =>
      {
        var seq = DOTween.Sequence()
                .Append(_optionBack.transform.DOScale(0.0f, 0.1f).SetEase(Ease.InBack))
                .OnComplete(() =>
                {
                  _openStageSelectButton.enabled = true;
                  _quitGameButton.enabled = true;

                  _optionBack.transform.localScale = Vector3.one;
                  _optionObject?.SetActive(false);
                })
                .Play();
      });
    }
  }
}
