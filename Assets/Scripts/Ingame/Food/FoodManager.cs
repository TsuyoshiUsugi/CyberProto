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
            //SettingからFoodを取得してランダムに取得可能な食事を返す
            int rnd = UnityEngine.Random.Range(0, _settings.foods.Length);
            return _settings.foods[rnd];
        }

        public Ingredient[] GetIngredients()
        {

        }

        public List<Food> GetCandidateFoods(List<Ingredient> items)
        {
            List<Food> candidateFoods = new();
            //各料理を見て、作れそうなものを返す
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
            //itemsを受け取って作成可能なfoodを返す

        }
    }
}

