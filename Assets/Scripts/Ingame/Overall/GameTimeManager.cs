using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UniRx;
using UnityEngine;

public class GameTimeManager : MonoBehaviour
{
    [SerializeField]
    private int _countdownDuration = 3;

    private IntReactiveProperty countdown = new IntReactiveProperty();
    public IReadOnlyReactiveProperty<int> Countdown => countdown;

    private Subject<Unit> countdownCompletedSubject = new Subject<Unit>();
    public System.IObservable<Unit> CountdownCompleted => countdownCompletedSubject;

    [SerializeField]
    private int _gameDuration = 60;

    private FloatReactiveProperty gameTimer = new FloatReactiveProperty();
    public IReadOnlyReactiveProperty<float> GameTimer => gameTimer;

    private Subject<Unit> gameEndSubject = new Subject<Unit>();
    public IObservable<Unit> GameEnd => gameEndSubject;

    private void Awake()
    {
        gameTimer.Value = _gameDuration;
        countdown.Value = _countdownDuration;
    }

    public async UniTask StartCountdownAsync(CancellationToken ct)
    {
        countdown.Value = _countdownDuration;
        while (--countdown.Value > 0)
        {
            await UniTask.Delay(1000, cancellationToken: ct);
        }

        countdownCompletedSubject.OnNext(Unit.Default);
        countdownCompletedSubject.OnCompleted();
    }

    public async UniTask StartGameTimerAsync(CancellationToken ct)
    {
        gameTimer.Value = _gameDuration;
        double s = Time.timeAsDouble;
        while (Time.timeAsDouble - s < _gameDuration)
        {
            gameTimer.Value = _gameDuration - (float)(Time.timeAsDouble - s);
            await UniTask.Yield(cancellationToken: ct);
        }
        gameTimer.Value = 0.0f;
        gameEndSubject.OnNext(Unit.Default);
        gameEndSubject.OnCompleted();
    }
}
