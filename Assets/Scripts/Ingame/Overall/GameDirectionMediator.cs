using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public interface IGameDirector
{
    bool CanPause { get; }
    IReadOnlyReactiveProperty<int> Countdown { get; }
    IObservable<Unit> CountdownCompleted { get; }
    IObservable<Unit> GameEnd { get; }
    IReadOnlyReactiveProperty<float> GameTimer { get; }
    IReadOnlyReactiveProperty<GameState> State { get; }

    void Exit();
    void Restart();
}

public class GameDirectionMediator : MonoBehaviour, IGameDirector
{
    [SerializeField]
    private GameDirector _gameDirector;

    [SerializeField]
    private GameTimeManager _gameTimeManager;

    public IReadOnlyReactiveProperty<GameState> State => _gameDirector.State;

    public bool CanPause => _gameDirector.CanPause;

    public IReadOnlyReactiveProperty<int> Countdown => _gameTimeManager.Countdown;

    public IObservable<Unit> CountdownCompleted => _gameTimeManager.CountdownCompleted;

    public IReadOnlyReactiveProperty<float> GameTimer => _gameTimeManager.GameTimer;

    public IObservable<Unit> GameEnd => _gameTimeManager.GameEnd;

    public void Restart()
    {
        _gameDirector.Restart();
    }

    public void Exit()
    {
        _gameDirector.Exit();
    }
}
