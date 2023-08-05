using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UniRx;

namespace Game
{
    public class Cannon : MonoBehaviour
    {
        public Food CurrentFood { get; private set; }

        public Subject<Unit> Fired { get; } = new Subject<Unit>();
        public Subject<List<Ingredient>> FoodChanged { get; } = new Subject<List<Ingredient>>();
        [SerializeField] private GameObject _bulletPrefab;
        

        /// <summary>
        /// 食べ物を大砲にセットする
        /// </summary>
        /// <param name="food"></param>
        public void SetFood(Food food)
        {
            FoodChanged.OnNext(CalculateFoodDifference(CurrentFood, food));
            CurrentFood = food;
        }

        /// <summary>
        /// 食べ物を発射する
        /// </summary>
        /// <param name="bulletVector"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Fire(Vector2 bulletVector)
        {
            if (!HasFood()) throw new NullReferenceException("CurrentFoodが設定されていません。");
            var bulletObject = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
            var bullet = bulletObject.GetComponent<Bullet>();
            bullet.Direction = bulletVector;
            bullet.SetFood(CurrentFood);
            // 検討
            SetFood(null);
            Fired.OnNext(Unit.Default);
        }
        
        /// <summary>
        /// 大砲に食事が含まれているか
        /// </summary>
        /// <returns></returns>
        public bool HasFood()
        {
            if (CurrentFood == null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// nextに含まれているが、previousに含まれていない材料を返す
        /// </summary>
        /// <param name="previous"></param>
        /// <param name="next"></param>
        private List<Ingredient> CalculateFoodDifference(Food previous, Food next)
        {
            if(next == null)
            {
                throw new NullReferenceException();
            }

            var diffs = new List<Ingredient>();
            foreach (var ingredient in next.Ingredients)
            {
                if (previous == null) diffs.Add(ingredient);
                else if(previous.Ingredients.Any(preIngredient => preIngredient.Id == ingredient.Id))
                {
                    diffs.Add(ingredient);
                }
            }
            return diffs;
        }
    }
}


