using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Game;
using UnityEngine;
using UniRx;

namespace game
{
    public class IngredientPresenter : MonoBehaviour
    {
        [SerializeField] private IngredientView _ingredientView;
        [SerializeField] private Cannon _Cannon;
        [SerializeField] private IngredientSelector _ingredientSelector;
        
        void Start()
        {
            // view to model
            
            // 材料がクリックされたとき
            _ingredientView.IngredientClicked.Subscribe(ingredient =>
            {
                _ingredientSelector.AddIngredient(ingredient);
            }).AddTo(this);
            
            
            
            // model to view
            
            // 大砲に追加可能な材料の候補が変化したとき
            _ingredientSelector.CandidateChanged.Subscribe(ingredients =>
            {
                AnimateIngredientShowHide(ingredients);
            }).AddTo(this);

            // 
            _Cannon.FoodChanged.Subscribe(ingredients =>
            {

            }).AddTo(this);
        }
        
        /// <summary>
        /// ingredientsに含まれるUIをenable、そうでないものをdisableする
        /// </summary>
        /// <param name="ingredients"></param>
        private void AnimateIngredientShowHide(List<Ingredient> ingredients){
            
        }

        /// <summary>
        /// ingredientsに含まれる素材を大砲に入れるアニメーション
        /// </summary>
        /// <param name="ingredients"></param>
        private void AnimateCannonSetting(List<Ingredient> ingredients)
        {
            
        }
    }
}
