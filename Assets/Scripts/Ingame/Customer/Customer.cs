using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using System.Linq;

namespace Game
{
    public class Customer : MonoBehaviour, ICustomer
    {
        private ReactiveDictionary<Food, bool> _requestFoodsDictionary = new ReactiveDictionary<Food, bool>();
        private Subject<Unit> _provideCompletedSubject = new Subject<Unit>();

        public IReadOnlyReactiveDictionary<Food, bool> RequestFoods => _requestFoodsDictionary;
        public System.IObservable<Unit> ProvideCompleted => _provideCompletedSubject;

        public List<Food> TestFoods;

        public bool IsContains(Food food)
        {
            // リクエストしていてかつまだ提供されてない
            return _requestFoodsDictionary.TryGetValue(food, out var result) && !result;
        }

        public void OnProvide(Food food)
        {
            _requestFoodsDictionary[food] = true;

            if (IsComplete())
            {
                _provideCompletedSubject.OnNext(Unit.Default);
                _provideCompletedSubject.OnCompleted();
            }
        }

        private bool IsComplete()
        {
            return _requestFoodsDictionary.All(pair => pair.Value);
        }

        void Start()
        {
            // フードコンテナからランダムな料理を受け取ってくる
            var foodContainer = ServiceLocator.Instance.Resolve<IFoodContainer>();

            foreach (var item in TestFoods)
            {
                _requestFoodsDictionary.Add(item, false);
            }
        }
    }

}