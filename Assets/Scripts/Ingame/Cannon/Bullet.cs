﻿using System;
using System.Collections;
using System.Collections.Generic;
using UniRx.Triggers;
using UniRx;
using UnityEngine;


namespace Game
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        public Food Food { get; private set; }
        private const float LifeSpan = 10f;
        public Vector2 Direction { get; set; }

        private void Start()
        {
            var collider = GetComponent<Collider2D>();

            collider.OnTriggerEnter2DAsObservable()
                .Subscribe(other =>
                {
                    var customer = other.GetComponent<ICustomer>();
                    if(customer != null)
                    {
                        if (customer.IsContains(Food))
                        {
                            customer.OnProvide(Food);
                            HitAnimation();
                        }
                    }
                }).AddTo(this);

            this.UpdateAsObservable().Subscribe(_ =>
            {
                var vec = Direction * Time.deltaTime;
                transform.Translate(vec.x, vec.y, 0);
            });
            Destroy(gameObject, LifeSpan);
        }

        /// <summary>
        /// Spriteをセットする
        /// </summary>
        /// <param name="food"></param>
        public void SetFood(Food food)
        {
            Debug.Log(food);
            Debug.Log(food.Icon);
            Food = food;
            _spriteRenderer.sprite = food.Icon;
        }

        private void HitAnimation()
        {
            Destroy(gameObject);
        }
    }
}
