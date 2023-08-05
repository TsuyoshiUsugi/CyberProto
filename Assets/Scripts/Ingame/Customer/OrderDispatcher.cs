using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace Game
{
    public class OrderDispatcher : MonoBehaviour
    {
        [SerializeField]
        Transform _orderViewContainer;

        [SerializeField]
        OrderView orderViewPrefab;

        [SerializeField]
        OrderPresenter presenter;

        private void Awake()
        {
            var spawner = ServiceLocator.Instance.Resolve<ISpawner>();
            spawner.CustomerInstantiated
                .Subscribe(customer =>
                {
                    var view = Instantiate(orderViewPrefab, _orderViewContainer);
                    view.gameObject.SetActive(true);
                    presenter.Connect(customer, view);
                });
        }
    }

}