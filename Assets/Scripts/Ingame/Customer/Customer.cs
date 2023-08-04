using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using System.Linq;

namespace Game
{
    public struct Order : IEquatable<Order>
    {
        public Order(Food food, int orderNumber)
        {
            Food = food;
            IsProvided = false;
            _orderNumber = orderNumber + 1;
        }

        public Food Food;
        public bool IsProvided;

        public int OrderNumber
        {
            get
            {
                return _orderNumber - 1;
            }
        }
        private int _orderNumber;

        public override bool Equals(object obj)
        {
            return obj is Order order && Equals(order);
        }

        public bool Equals(Order other)
        {
            return EqualityComparer<Food>.Default.Equals(Food, other.Food) &&
                   IsProvided == other.IsProvided &&
                   _orderNumber == other._orderNumber;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Food, IsProvided, _orderNumber);
        }
    }

    public class Customer : MonoBehaviour, ICustomer
    {
        private Subject<Unit> _provideCompletedSubject = new Subject<Unit>();
        public System.IObservable<Unit> ProvideCompleted => _provideCompletedSubject;

        private ReactiveCollection<Order> _orders = new ReactiveCollection<Order>();
        public IReadOnlyReactiveCollection<Order> Orders => _orders;


        [SerializeField]
        [Range(1, 3)]
        private int _requestCount = 1;

        public bool IsContains(Food food)
        {
            var order = _orders.FirstOrDefault(order => order.Food == food && !order.IsProvided);

            return order.OrderNumber != -1;
        }

        public void OnProvide(Food food)
        {
            var order = _orders.FirstOrDefault(order => order.Food == food && !order.IsProvided);
            if (order.OrderNumber == -1) return;

            order.IsProvided = true;
            _orders[order.OrderNumber] = order;

            if (IsComplete())
            {
                _provideCompletedSubject.OnNext(Unit.Default);
                _provideCompletedSubject.OnCompleted();
            }
        }

        private bool IsComplete()
        {
            return _orders.All(order => order.IsProvided);
        }

        void Start()
        {
            // フードコンテナからランダムな料理を受け取ってくる
            //var foodContainer = ServiceLocator.Instance.Resolve<IFoodContainer>();
            var foodContainer = FindFirstObjectByType<FoodManager>();

            for (int i = 0; i < _requestCount; i++)
            {
                var food = foodContainer.GetRandomFood();
                _orders.Add(new Order(food, i));
            }
        }
    }

}