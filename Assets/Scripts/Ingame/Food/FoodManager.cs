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
            //Setting����Food���擾���ă����_���Ɏ擾�\�ȐH����Ԃ�
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

        /// <summary>
        /// Ingredient��I�񂾎��Ɏ��ɑI���\�ȑf�ނ̃��X�g��Ԃ�
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public List<Ingredient> GetCandidateIngredients(List<Ingredient> items)
        {
            List<Ingredient> selectableIngredient = new();

            var creatableFoods = GetCandidateFoods(items);   //Item�ō���Food���������ė���
            //cratable�̐H�ނ�S�ĕԂ�
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
            //items���󂯎���č쐬�\��food��Ԃ�
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

