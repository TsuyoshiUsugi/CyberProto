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
        private bool isSpawnActive = false;

        public void StartSpawn()
        {
            isSpawnActive = true;
        }
        public void StopSpawn()
        {
            isSpawnActive = false;
        }

        void Start()
        {
            var levelSettings = _gameContext.levelSettings;
            normalModeTimers = new float[levelSettings.normalCycles.Length];
            rushModeTimers = new float[levelSettings.rushCycles.Length];

            SetUsing(levelSettings.normalCycles, normalModeTimers);
            state = 0;

            IGameDirector gameDirection = ServiceLocator.Instance.Resolve<IGameDirector>();

            gameDirection.GameTimer.Subscribe(CycleChanger);

            _popularityManager.PopularityScore
                .Select(f => Mathf.CeilToInt(f))
                .DistinctUntilChanged()
                .Subscribe(popularity =>
                {
                    timerScale = 1.0f + (popularity - 3) * timerScaleDiff;
                });

            gameDirection.State
                .Subscribe(state =>
                {
                    if (state == GameState.Play) StartSpawn();
                    else StopSpawn();
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
            if (!isSpawnActive) return;

            timer.Value += Time.deltaTime;

            for (int i = 0; i < usingCycles.Length; i++)
            {
                usingTimers[i] += Time.deltaTime * timerScale;

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