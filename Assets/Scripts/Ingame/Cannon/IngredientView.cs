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
            foreach (var ingredientButton in _ingredientButtonDictionary)
            {
                ingredientButton.Button.enabled = false;
                ingredientButton.Image.color = Color.gray;
            }

            foreach (var ingredient in ingredients)
            {
                var c = GetIngredientButton(ingredient);
                c.Button.enabled = true;
                c.Image.color = new Color(1, 1, 1, 1);
            }
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
        private IngredientButton GetIngredientButton(Ingredient ingredient)
        {
            return _ingredientButtonDictionary.First(x => x.Ingredient.Id == ingredient.Id);
        }
    }

    

    [System.Serializable]
    public struct IngredientButton
    {
        private Button _button;
        private Image _image;
        private Ingredient _ingredient;

        public Button Button { get { return _button; } }
        public Image Image { get { return _image; } }
        public Ingredient Ingredient { get { return _ingredient; } }
    }
}

