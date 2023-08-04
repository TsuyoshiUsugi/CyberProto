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
        [SerializeField] private GameObject _bulletPrefab;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vec"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Fire(Vector2 vec)
        {
            throw new NotImplementedException();
        }
        
        public bool HasFood()
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


