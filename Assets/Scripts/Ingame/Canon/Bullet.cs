using System;
using System.Collections;
using System.Collections.Generic;
using UniRx.Triggers;
using UniRx;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 Direction { get; set; }
    public float Speed { get; set; }

    private void Start()
    {
        this.UpdateAsObservable().Subscribe(_ =>
        {
            transform.Translate(Direction.x, Direction.y, 0);
        });
    }
    
    // バレットにぶつかったとき何かしらする
}
