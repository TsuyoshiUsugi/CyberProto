using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace Game
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField]
        private PopularityManager _popularityManager;

        [SerializeField]
        ScoreSettings _scoreSettings;

        private IGameDirector _gameDirector;

        public IReadOnlyReactiveProperty<int> Score => _score;
        private readonly IntReactiveProperty _score = new IntReactiveProperty(0);

        private IntReactiveProperty _provideCompletedCount = new IntReactiveProperty(0);
        public ReactiveProperty<int> ProvideCompletedCount => _provideCompletedCount;

        void Start()
        {
            var spawner = ServiceLocator.Instance.Resolve<ISpawner>();
            spawner.CustomerInstantiated
                .Subscribe(ObserveCustomer)
                .AddTo(this);

            _score.Subscribe(val => Debug.Log("score : " + val)).AddTo(this);

            _gameDirector = ServiceLocator.Instance.Resolve<IGameDirector>();
        }

        private void ObserveCustomer(Customer customer)
        {
            customer.OrderProvided
                .Where(x => _gameDirector.State.Value == GameState.Play)
                .Subscribe(evt =>
                {
                    _score.Value += _scoreSettings.IngredientScore * evt.Food.Ingredients.Length;

                    if (evt.Timing == ProvideTiming.Fast)
                    {
                        _score.Value += _scoreSettings.SpeedBonus;
                    }

                    AddPopularityBonus();
                })
                .AddTo(this);

            customer.ProvideCompleted
                .Where(x => _gameDirector.State.Value == GameState.Play)
                .Subscribe(_ =>
                {
                    _score.Value += _scoreSettings.CompleteBonus;
                    _provideCompletedCount.Value++;
                })
                .AddTo(this);
        }

        private void AddPopularityBonus()
        {
            int idx = Mathf.CeilToInt(_popularityManager.PopularityScore.Value) - 1;
            if (idx < 0 || idx >= _scoreSettings.PopularityBonuses.Length) ;
            _score.Value += _scoreSettings.PopularityBonuses[idx];
        }
    }
}