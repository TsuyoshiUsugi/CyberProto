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
        public ReactiveProperty<bool> IsArrowActive { get; private set; } = new ReactiveProperty<bool>(false);
        private Vector2 _clickedCoodination;
        private Vector2 _releasedCoodination;
        private Vector2 _mouseScreenPoint;

        public Vector2 CurrentDirection => _releasedCoodination - _clickedCoodination;

        private void Start()
        {
            // マウスをクリックしたときの処理を購読
            this.UpdateAsObservable()
                .Where(_ => Input.GetMouseButtonDown(0))
                .Where(_ => _cannon.HasFood())
                .Where(_ => !IsArrowActive.Value)
                .Subscribe(_ =>
                {
                    IsArrowActive.Value = true;
                    _mouseScreenPoint = Input.mousePosition;
                    _clickedCoodination = _mouseScreenPoint;
                });

            // マウスを離したときの処理を購読
            this.UpdateAsObservable()
                .Where(_ => Input.GetMouseButtonUp(0))
                .Where(_ => _cannon.HasFood())
                .Where(_ => IsArrowActive.Value)
                .Subscribe(_ =>
                {
                    _mouseScreenPoint = Input.mousePosition;
                    _releasedCoodination = _mouseScreenPoint;
                    if (ExceedingThreshold())
                    {
                        var direction = ConvertBulletDirection(CurrentDirection);
                        _cannon.Fire(direction);
                        Debug.Log(direction);
                         transform.Translate(direction.x, direction.y, 0);
                    }
                    IsArrowActive.Value = false;
                });
        }

        /// <summary>
        /// 引っ張ったベクトルの大きさが閾値を超えているか
        /// </summary>
        /// <returns></returns>
        private bool ExceedingThreshold()
        {
            return CurrentDirection.magnitude > _shotThreshold;
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