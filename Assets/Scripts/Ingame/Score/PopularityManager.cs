using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace Game
{
    public class PopularityManager : MonoBehaviour
    {
        private IGameDirector _gameDirector;

        private readonly FloatReactiveProperty _popularityScore = new FloatReactiveProperty();
        public IReadOnlyReactiveProperty<float> PopularityScore => _popularityScore;

        private int _min = 1;
        private int _max = 5;

        [SerializeField]
        private float _provideAdd = 0.05f;

        [SerializeField]
        private float _fastProvideAdd = 0.1f;

        [SerializeField]
        private float _completedAdd = 0.1f;

        [SerializeField]
        private float _missDecrease = 0.2f;

        private float PopularityScoreValue
        {
            get { return _popularityScore.Value; }
            set
            {
                _popularityScore.Value = Mathf.Clamp(value, _min, _max);
                Debug.Log(_popularityScore.Value);
            }
        }

        private void Start()
        {
            _popularityScore.Value = 3;
            var spawner = ServiceLocator.Instance.Resolve<ISpawner>();

            if (spawner == null)
            {
                return;
            }

            spawner.CustomerInstantiated
                .Subscribe(ObserveCustomer)
                .AddTo(this);

            _gameDirector = ServiceLocator.Instance.Resolve<IGameDirector>();
        }

        private void ObserveCustomer(Customer customer)
        {
            customer.OrderProvided
                .Where(x => _gameDirector.State.Value == GameState.Play)
                .Subscribe(evt =>
            {
                if (evt.Timing == ProvideTiming.Fast)
                {
                    PopularityScoreValue += _fastProvideAdd;
                }
                else
                {
                    PopularityScoreValue += _provideAdd;
                }
            });

            customer.ProvideCompleted
                .Where(x => _gameDirector.State.Value == GameState.Play)
                .Subscribe(_ =>
            {
                PopularityScoreValue += _completedAdd;
            });

            customer.NotProvided
                .Where(x => _gameDirector.State.Value == GameState.Play)
                .Subscribe(_ =>
            {
                PopularityScoreValue -= _missDecrease;
            });
        }
    }
}
