using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace Game
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField]
        private GameContext _gameContext;

        [SerializeField]
        private Vector2 _spawnPoint = Vector2.zero;

        [SerializeField]
        private PopularityManager _popularityManager;

        [SerializeField]
        private float timerScaleDiff = 0.1f;

        private float timerScale = 1.0f;

        private Subject<Customer> _customerInstantiatedSubject = new Subject<Customer>();

        public System.IObservable<Customer> CustomerInstantiated => _customerInstantiatedSubject;

        private float[] normalModeTimers;
        private float[] rushModeTimers;

        private SpawnCycle[] usingCycles;
        private float[] usingTimers;

        private int state = 0;

        // あとでタイマークラスと置き換える
        private FloatReactiveProperty timer = new FloatReactiveProperty();

        void Start()
        {
            var levelSettings = _gameContext.levelSettings;
            normalModeTimers = new float[levelSettings.normalCycles.Length];
            rushModeTimers = new float[levelSettings.rushCycles.Length];

            SetUsing(levelSettings.normalCycles, normalModeTimers);
            state = 0;

            timer.Subscribe(CycleChanger);

            _popularityManager.PopularityScore
                .Select(f => Mathf.CeilToInt(f))
                .DistinctUntilChanged()
                .Subscribe(popularity =>
                {
                    timerScale = 1.0f + (popularity - 3) * timerScaleDiff;
                });
        }

        private void CycleChanger(float t)
        {
            switch (state)
            {
                case 0:
                    if (t >= _gameContext.levelSettings.rushStartTime)
                    {
                        SetUsing(_gameContext.levelSettings.rushCycles, rushModeTimers);
                        state++;
                    }
                    break;

                case 1:
                    if (t >= _gameContext.levelSettings.rushEndTime)
                    {
                        SetUsing(_gameContext.levelSettings.normalCycles, normalModeTimers);
                        state++;
                    }
                    break;
            }
        }

        private void Update()
        {
            timer.Value += Time.deltaTime * timerScale;

            for (int i = 0; i < usingCycles.Length; i++)
            {
                usingTimers[i] += Time.deltaTime;
                if (usingCycles[i].span <= usingTimers[i])
                {
                    var customer = Instantiate(usingCycles[i].customerPrefab, _spawnPoint, Quaternion.identity);
                    _customerInstantiatedSubject.OnNext(customer);

                    usingTimers[i] = 0.0f;
                }
            }
        }

        private void SetUsing(SpawnCycle[] cycles, float[] timers)
        {
            usingCycles = cycles;
            usingTimers = timers;

            for (int i = 0; i < timers.Length; i++)
            {
                timers[i] = cycles[i].initOffset;
            }
        }

#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(_spawnPoint, 0.5f);
        }
#endif
    }

}