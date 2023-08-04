using Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class OrderPresenter : MonoBehaviour
{
    public void Connect(Customer customer, OrderView view)
    {
        foreach (var item in customer.Orders)
        {
            view.AddFood(item.Food);
        }

        customer.Orders.ObserveAdd()
            .Subscribe(evt => view.AddFood(evt.Value.Food))
            .AddTo(view);

        customer.Orders.ObserveReplace()
            .Where(evt => evt.NewValue.IsProvided)
            .Subscribe(evt => view.RemoveFood(evt.NewValue.OrderNumber))
            .AddTo (view);

        customer.ProvideCompleted
            .Subscribe(_ => view.OnCompleted())
            .AddTo(view);

        customer.ObserveEveryValueChanged(customer => customer.transform.position)
            .Subscribe(vec => view.SetPosition((Vector2)vec));

        customer.OnDestroyAsObservable()
            .Subscribe(_ => Destroy(view.gameObject))
            .AddTo(view);
    }
}
