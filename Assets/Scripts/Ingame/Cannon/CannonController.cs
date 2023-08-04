using System.Collections;
using System.Collections.Generic;
using Game;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    [SerializeField] private Cannon _cannon;
    [SerializeField] private float _shotThreshold;
    private bool _mouseHold = false;
    private Vector2 _clickedCoodination;
    private Vector2 _releasedCoodination;
    private Vector2 _mouseScreenPoint;
    
    private void Start()
    {
        this.UpdateAsObservable()
            .Where(_ => Input.GetMouseButtonDown(0))
            .Where(_ => _cannon.HasFood())
            .Where(_ => !_mouseHold)
            .Subscribe(_ =>
            {
                _mouseHold = true;
                _mouseScreenPoint = Input.mousePosition;
                Debug.Log($"bf: {_mouseScreenPoint}");
                _clickedCoodination = _mouseScreenPoint;
            });
        
        this.UpdateAsObservable()
            .Where(_ => Input.GetMouseButtonUp(0))
            .Where(_ => _cannon.HasFood())
            .Where(_ => _mouseHold)
            .Subscribe(_ =>
            {
                _mouseScreenPoint = Input.mousePosition;
                Debug.Log($"af: {_mouseScreenPoint}");
                _releasedCoodination = _mouseScreenPoint;
                if (ExceedingThreshold())
                {
                    var screenDir = _releasedCoodination - _clickedCoodination;
                    var direction = CalculateBulletDirection(screenDir);
                    transform.Translate(direction.x, direction.y,0);
                    Debug.Log(direction);
                }
                _mouseHold = false;
            });
    }

    private bool ExceedingThreshold()
    {
        var difference = _releasedCoodination - _clickedCoodination;
        return difference.magnitude > _shotThreshold;
    }

    private Vector2 CalculateBulletDirection(Vector2 dir)
    {
        // TODO: 要調整
        return dir * -0.01f;
    }
}
