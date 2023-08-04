using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class IngredientView : MonoBehaviour
    {
        [SerializeField]
        private List<IngredientButton> _ingredientButtonDictionary;

        private List<Ingredient> _availableIngredients = new List<Ingredient>();
        public Subject<Ingredient> IngredientClicked { get; set; } = new Subject<Ingredient>();

        public void ResetState()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 選択した材料を選択可能にする
        /// </summary>
        /// <param name="ingredients"></param>
        public void SetActiveIngredients(List<Ingredient> ingredients)
        {
            // UI Animation
        }

        /// <summary>
        /// 選択した材料を大砲に入れるアニメーションを再生する
        /// </summary>
        /// <param name="ingredients"></param>
        public void UseIngredients(List<Ingredient> ingredients)
        {
            // UI Animation
        }

        private Button GetButton(Ingredient ingredient)
        {
            return _ingredientButtonDictionary.First(x => x.Ingredient.Id == ingredient.Id).Button;
        }
    }

    

    [System.Serializable]
    public struct IngredientButton
    {
        private Button _button;
        private Ingredient _ingredient;

        public Button Button { get; }
        public Ingredient Ingredient { get; }
    }
}

