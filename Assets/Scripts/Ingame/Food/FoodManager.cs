using System;
using System.Linq;
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

        public List<Ingredient> GetIngredients()
        {
            List<Ingredient> ingredients = new();

            foreach (var food in _settings.foods)
            {
                foreach (var ingredient in food.Ingredients)
                {
                    ingredients.Add(ingredient);
                }
            }
            return ingredients;
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

        /// <summary>
        /// Ingredientを選んだ時に次に選択可能な素材のリストを返す
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public List<Ingredient> GetCandidateIngredients(List<Ingredient> items)
        {
            List<Ingredient> selectableIngredient = new();

            var creatableFoods = GetCandidateFoods(items);   //Itemで作れるFoodがかえって来る
            //cratableの食材を全て返す
            foreach (var food in creatableFoods)
            {
                foreach (var ingredient in food.Ingredients)
                {
                    selectableIngredient.Add(ingredient);
                }
            }

            return selectableIngredient;
        }

        public bool TryGetCreatableFood(List<Ingredient> items, out Food food)
        {
            //itemsを受け取って作成可能なfoodを返す
            food = GetCandidateFoods(items)[0];
            if (food)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

