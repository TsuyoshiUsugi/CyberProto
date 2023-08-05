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
        private SpriteRenderer _spriteRenderer;
        public Food Food { get; private set; }
        private const float lifeSpan = 10f;
        public Vector2 Direction { get; set; }

        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            this.UpdateAsObservable().Subscribe(_ =>
            {
                transform.Translate(Direction.x, Direction.y, 0);
            });
            Destroy(gameObject, lifeSpan);
        }

        /// <summary>
        /// Spriteをセットする
        /// </summary>
        /// <param name="food"></param>
        public void SetFood(Food food)
        {
            Food = food;
            _spriteRenderer.sprite = food.Icon;
        }
    }
}
