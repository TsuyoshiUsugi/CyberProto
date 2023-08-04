using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace Game
{
    public class Cannon : MonoBehaviour
    {
        // SetFood
        public Food CurrentFood { get; set; }

        void Fire(Vector2 vec)
        {
            throw new NotImplementedException();
        }
        
        bool HasFood()
        {
            if (CurrentFood == null)
            {
                return false;
            }
            return true;
        }

        public Subject<(Food, Food)> FoodChanged { get; set; } = new Subject<(Food, Food)>();
    }
}


