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
                _ingredientView.SetActiveIngredients(ingredients);
            }).AddTo(this);

            // 
            _Cannon.FoodChanged.Subscribe(ingredients =>
            {
                _ingredientView.UseIngredients(ingredients);
            }).AddTo(this);
        }
    }
}
