using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class FoodManager : MonoBehaviour
    {
        [SerializeField] LevelSettings _settings;

        public Food GetRandomFood()
        {
            //Setting����Food���擾���ă����_���Ɏ擾�\�ȐH����Ԃ�
            int rnd = UnityEngine.Random.Range(0, _settings.foods.Length);
            return _settings.foods[rnd];
        }

        public Ingredient[] GetIngredients()
        {

        }

        public List<Food> GetCandidateFoods(List<Ingredient> items)
        {
            List<Food> candidateFoods = new();
            //�e���������āA��ꂻ���Ȃ��̂�Ԃ�
            foreach (var food in _settings.foods)
            {
                var ingredientNum = food.Ingredients.Length;
                var currentMatchNum = 0;
                for (int i = 0; i < food.Ingredients.Length; i++)
                {
                    if (items.Contains(food.Ingredients[i])) currentMatchNum++;
                }

                if (ingredientNum == currentMatchNum) candidateFoods.Add(food);
            }

            return candidateFoods;
        }

        public List<Ingredient> GetCandidateIngredients(List<Ingredient> items)
        {

        }

        public bool TryGetCreatableFood(List<Ingredient> items, out Food food)
        {
            //items���󂯎���č쐬�\��food��Ԃ�

        }
    }
}

