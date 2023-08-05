using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

namespace Game {
    public class CannonArrowPresenter : MonoBehaviour
    {
        [SerializeField] private CannonController _cannonController;
        [SerializeField] private CannonView _cannonView;

        private void Start()
        {
            _cannonController.IsArrowActive
                .Subscribe(active =>
                {
                    _cannonView.SetActive(active);
                }).AddTo(this);

            this.UpdateAsObservable()
                .Where(_ => _cannonController.IsArrowActive.Value)
                .Subscribe(_ =>
                {
                    _cannonView.SetDirectionUI(_cannonController.CurrentDirection);
                }).AddTo(this);
        }
    }
}
