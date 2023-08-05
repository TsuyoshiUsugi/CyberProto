using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace Game
{
    public class OrderDispatcher : MonoBehaviour
    {
        [SerializeField]
        Canvas canvas;

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
                    var view = Instantiate(orderViewPrefab, canvas.transform);
                    view.gameObject.SetActive(true);
                    presenter.Connect(customer, view);
                });
        }
    }

}