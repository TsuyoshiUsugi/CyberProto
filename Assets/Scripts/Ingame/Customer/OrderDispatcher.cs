using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace Game
{
    public class OrderDispatcher : MonoBehaviour
    {
        [SerializeField]
        Spawner spawner;

        [SerializeField]
        Canvas canvas;

        [SerializeField]
        OrderView orderViewPrefab;

        [SerializeField]
        OrderPresenter presenter;

        private void Awake()
        {
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