using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class FoodManager : MonoBehaviour, IFoodContainer
    {
        LevelSettings _settings;
        [SerializeField] GameContext _gameContext;

        private void Start()
        {
            _settings = _gameContext.levelSettings;
        }

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
            HashSet<Ingredient> selectableIngredients = new(); //Itemで作れるFoodの素材がかえってくる

            if (items.Count == 0)
            {
                foreach (var food in _settings.foods)
                {
                    selectableIngredients.UnionWith(food.Ingredients);
                }

                return selectableIngredients.ToList();
            }


            foreach (var food in _settings.foods)
            {
                var contain = true;

                foreach(var ingredient in items)
                {
                    if (!food.Ingredients.Contains(ingredient))
                    {
                        contain = false;
                        break;
                    }
                }

                if (contain)
                {
                    selectableIngredients.UnionWith(food.Ingredients);
                }
            }
            return selectableIngredients.ToList();
        }
        /// <summary>
        /// 引き数に与えられた食材たちとマッチするFoodがある場合返す
        /// </summary>
        /// <param name="items"></param>
        /// <param name="food"></param>
        /// <returns></returns>
        public bool TryGetCreatableFood(List<Ingredient> items, out Food food)
        {
            food = default;

            foreach (var candidatefood in _settings.foods)
            {
                var maxIngredientNum = candidatefood.Ingredients.Length;

                if (maxIngredientNum != items.Count) continue;

                foreach (var ingredient in items)//candidatefoodが設定側のfood(個数は一緒)
                {
                    if (ingredient == null) throw new NullReferenceException("ingredientが空です");
                    if (!candidatefood.Ingredients.Select(x => x.Id).Contains(ingredient.Id))
                    {
                        return false;
                    }
                }

                food = candidatefood;
                return true;
            }
            return false;
        }
    }
}

