using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using TMPro;

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

        public Subject<Unit> QuitButtonClicked = new Subject<Unit>();

        // Start is called before the first frame update
        void Start()
        {
            if(_optionObject) _optionObject.SetActive(false);
            if(_stageSelectObject) _stageSelectObject.SetActive(false);

            _openStageSelectButton.onClick.AddListener(() =>
            {
                if (!_optionObject.activeSelf)
                {
                    _stageSelectObject.SetActive(true);
                }
            });

            _quitStageSelectButton.onClick.AddListener(() =>
            {
                if (!_optionObject.activeSelf)
                {
                    _stageSelectObject.SetActive(false);
                }
            });

            _quitGameButton.onClick.AddListener(() =>
            {
                if (!_optionObject.activeSelf)
                QuitButtonClicked.OnNext(Unit.Default);
            });
            _openOptionButton.onClick.AddListener(() => 
            {
                _openStageSelectButton.enabled = false;
                _quitGameButton.enabled = false;
                _optionObject?.SetActive(true); 
            });

            _exitOptionButton.onClick.AddListener(() =>
            {
                _openStageSelectButton.enabled = true;
                _quitGameButton.enabled = true;
                _optionObject?.SetActive(false);
            });
        }

    }
}
