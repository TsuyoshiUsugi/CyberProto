using System;
using System.Collections;
using System.Collections.Generic;
using UniRx.Triggers;
using UniRx;
using UnityEngine;


namespace Game
{
    public class Bullet : MonoBehaviour
    {
        public Food Food { get; set; }
        private const float lifeSpan = 10f;
        public Vector2 Direction { get; set; }

        private void Start()
        {
            this.UpdateAsObservable().Subscribe(_ =>
            {
                transform.Translate(Direction.x, Direction.y, 0);
            });
            Destroy(gameObject, lifeSpan);
        }
    }
}
