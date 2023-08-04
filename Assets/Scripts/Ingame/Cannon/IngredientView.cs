using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;


namespace Game
{
    public class IngredientView : MonoBehaviour
    {
        private List<Ingredient> _availableIngredients = new List<Ingredient>();
        public Subject<Ingredient> IngredientClicked { get; set; } = new Subject<Ingredient>();

        public void ResetState()
        {
            throw new NotImplementedException();
        }

        public void SetActiveIngredients(Ingredient[] ingredients)
        {
            // UI Animation
        }

        /// <summary>
        /// 選択した材料を大砲に入れるアニメーションを再生する
        /// </summary>
        /// <param name="ingredients"></param>
        public void UseIngredients(Ingredient[] ingredients)
        {
            // UI Animation
        }
    }
}

