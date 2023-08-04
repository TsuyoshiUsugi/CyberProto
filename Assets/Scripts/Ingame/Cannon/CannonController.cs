using System.Collections;
using System.Collections.Generic;
using Game;
using UniRx;
using UniRx.Triggers;
using UnityEngine;


namespace Game
{
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
            // マウスをクリックしたときの処理を購読
            this.UpdateAsObservable()
                .Where(_ => Input.GetMouseButtonDown(0))
                .Where(_ => _cannon.HasFood())
                .Where(_ => !_mouseHold)
                .Subscribe(_ =>
                {
                    _mouseHold = true;
                    _mouseScreenPoint = Input.mousePosition;
                    _clickedCoodination = _mouseScreenPoint;
                });

            // マウスを離したときの処理を購読
            this.UpdateAsObservable()
                .Where(_ => Input.GetMouseButtonUp(0))
                .Where(_ => _cannon.HasFood())
                .Where(_ => _mouseHold)
                .Subscribe(_ =>
                {
                    _mouseScreenPoint = Input.mousePosition;
                    _releasedCoodination = _mouseScreenPoint;
                    if (ExceedingThreshold())
                    {
                        var screenDir = _releasedCoodination - _clickedCoodination;
                        var direction = ConvertBulletDirection(screenDir);
                        _cannon.Fire(direction);
                        Debug.Log(direction);
                         transform.Translate(direction.x, direction.y, 0);
                    }
                    _mouseHold = false;
                });
        }

        /// <summary>
        /// 引っ張ったベクトルの大きさが閾値を超えているか
        /// </summary>
        /// <returns></returns>
        private bool ExceedingThreshold()
        {
            var difference = _releasedCoodination - _clickedCoodination;
            return difference.magnitude > _shotThreshold;
        }

        /// <summary>
        /// mousePositionのベクトルをbulletの進行ベクトルに変換
        /// </summary>
        /// <param name="dir"></param>
        /// <returns></returns>
        private Vector2 ConvertBulletDirection(Vector2 dir)
        {
            // TODO: 要調整(Lerpしてもいいかも)
            return dir * -0.0001f;
        }
    }
}