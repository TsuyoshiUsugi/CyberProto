using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace Title
{
    public class TitlePresenter : MonoBehaviour
    {
        [SerializeField] TitleManager _titleManager;
        [SerializeField] TitleView _titleView;

        private void Start()
        {
            _titleView.StartButtonClicked.Subscribe(_ => _titleManager.MoveToStageSelect()).AddTo(this);
            _titleView.QuitButtonClicked.Subscribe(_ => _titleManager.QuitGame()).AddTo(this);
        }
    }
}
