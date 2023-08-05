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
        [SerializeField] Button _startButton;
        [SerializeField] Button _quitButton;
        [SerializeField] Button _optionButton;
        [SerializeField] GameObject _optionObject;
        [SerializeField] bool _isOpen = false;

        public Subject<Unit> StartButtonClicked = new Subject<Unit>();
        public Subject<Unit> QuitButtonClicked = new Subject<Unit>();

        // Start is called before the first frame update
        void Start()
        {
            if(_optionObject) _optionObject.SetActive(false);
            _startButton.onClick.AddListener(() => StartButtonClicked.OnNext(Unit.Default));
            _quitButton.onClick.AddListener(() => QuitButtonClicked.OnNext(Unit.Default));
            _optionButton.onClick.AddListener(() => {
                _optionObject?.SetActive(!_isOpen);
                _isOpen = !_isOpen;
                });
        }

    }
}
