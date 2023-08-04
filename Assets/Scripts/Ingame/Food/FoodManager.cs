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
                    if (ingredients.Contains(ingredient)) continue;
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

            List<Food> creatableFoods = new();   //Item�ō���Food���������ė���

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

            //cratable�̐H�ނ�S�ĕԂ�
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
        /// �������ɗ^����ꂽ�H�ނ����ƃ}�b�`����Food������ꍇ�Ԃ�
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

                if (currentMatchNum == maxIngredientNum)    //Food�����̂ɕK�v�ȑf�ނԂ�f�ނ������Ă���
                {
                    if (!food) food = candidatefood;

                    if (food.Ingredients.Length == candidatefood.Ingredients.Length && food != candidatefood)
                    {
                        Debug.LogError("�������̑f�ނō���g�ݍ��킹����������܂�");
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

