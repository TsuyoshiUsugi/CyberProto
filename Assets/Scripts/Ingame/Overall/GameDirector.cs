using Cysharp.Threading.Tasks;
using Game;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    None,
    Countdown,
    Play,
    End,
}

public class GameDirector : MonoBehaviour
{

    [SerializeField]
    private GameTimeManager _timer;

    private ReactiveProperty<GameState> _gameState = new ReactiveProperty<GameState>(GameState.None);
    public IReadOnlyReactiveProperty<GameState> State => _gameState;

    public bool CanPause => _gameState.Value == GameState.Play;

    private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

    private void Awake()
    {

    }

    private void Start()
    {
        var cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationTokenSource.Token, this.GetCancellationTokenOnDestroy());
        GameRunAsync(cts.Token).Forget();
    }

    private async UniTask GameRunAsync(CancellationToken ct)
    {
        Debug.Log("カウントダウンスタート");
        _gameState.Value = GameState.Countdown;
        await _timer.StartCountdownAsync(ct);

        Debug.Log("ゲームスタート");
        _gameState.Value = GameState.Play;
        await _timer.StartGameTimerAsync(ct);

        Debug.Log("ゲーム終了");
        _gameState.Value = GameState.End;
    }

    public void Restart()
    {
        cancellationTokenSource.Cancel();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Exit()
    {
        cancellationTokenSource.Cancel();
        SceneManager.LoadScene("StageSelectScene");
    }
}
