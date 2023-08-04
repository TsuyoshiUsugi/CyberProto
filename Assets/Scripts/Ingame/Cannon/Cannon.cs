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
        public Subject<List<Ingredient>> FoodChanged { get; } = new Subject<List<Ingredient>>();
        [SerializeField] private Bullet _bullet;

        /// <summary>
        /// �H�ו����C�ɃZ�b�g����
        /// </summary>
        /// <param name="food"></param>
        public void SetFood(Food food)
        {
            FoodChanged.OnNext(CalculateFoodDifference(CurrentFood, food));
            CurrentFood = food;
        }


        /// <summary>
        /// �H�ו��𔭎˂���
        /// </summary>
        /// <param name="bulletVector"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Fire(Vector2 bulletVector)
        {
            if (!HasFood()) throw new NullReferenceException("CurrentFood���ݒ肳��Ă��܂���B");
            // var bulletObject = Instantiate(_bulletPrefab);
            // var bullet = bulletObject.GetComponent<Bullet>();
            _bullet.Direction = bulletVector;
            
            // ����
            SetFood(null);
        }
        
        /// <summary>
        /// ��C�ɐH�����܂܂�Ă��邩
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
        /// next�Ɋ܂܂�Ă��邪�Aprevious�Ɋ܂܂�Ă��Ȃ��ޗ���Ԃ�
        /// </summary>
        /// <param name="previous"></param>
        /// <param name="next"></param>
        private List<Ingredient> CalculateFoodDifference(Food previous, Food next)
        {
            var diffs = new List<Ingredient>();
            foreach (var ingredient in next.Ingredients)
            {
                if (previous.Ingredients.Any(preIngredient => preIngredient.Id == ingredient.Id))
                {
                    diffs.Add(ingredient);
                }
            }
            return diffs;
        }
    }
}


