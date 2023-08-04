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
                    if (ingredients.Contains(ingredient)) continue;
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

            List<Food> creatableFoods = new();   //Itemで作れるFoodがかえって来る

            foreach (var ingredient in items)
            {
                foreach (var food in _settings.foods)
                {
                    if (food.Ingredients.Contains(ingredient))
                    {
                        if (!creatableFoods.Contains(food)) creatableFoods.Add(food);
                    }
                }
            }

            //cratableの食材を全て返す
            foreach (var food in creatableFoods)
            {
                foreach (var ingredient in food.Ingredients)
                {
                    if (!selectableIngredient.Contains(ingredient)) selectableIngredient.Add(ingredient);
                }
            }

            return selectableIngredient;
        }

        /// <summary>
        /// 引き数に与えられた食材たちとマッチするFoodがある場合返す
        /// </summary>
        /// <param name="items"></param>
        /// <param name="food"></param>
        /// <returns></returns>
        public bool TryGetCreatableFood(List<Ingredient> items, out Food food)
        {
            food = null;

            foreach (var candidatefood in _settings.foods)
            {
                if (candidatefood.Ingredients.Length != items.Count) continue;
                var maxIngredientNum = candidatefood.Ingredients.Length;
                var currentMatchNum = 0;

                foreach (var ingredient in candidatefood.Ingredients)
                {
                    if (items.Contains(ingredient)) currentMatchNum++;
                }

                if (currentMatchNum == maxIngredientNum)    //Foodを作るのに必要な素材ぶん素材が入ってたら
                {
                    if (!food) food = candidatefood;

                    if (food.Ingredients.Length == candidatefood.Ingredients.Length && food != candidatefood)
                    {
                        Debug.LogError("引き数の素材で作れる組み合わせが複数あります");
                        Debug.Log(food.Name);
                        Debug.Log(candidatefood.Name);
                    }
                    else if (food.Ingredients.Length < candidatefood.Ingredients.Length) food = candidatefood;
                }
            }


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

