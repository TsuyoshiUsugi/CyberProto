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
        [SerializeField] private Cannon _cannon;
        [SerializeField] private IngredientSelector _ingredientSelector;
        
        void Start()
        {
            _ingredientView.IngredientClicked.Subscribe(ingredient =>
            {
                _ingredientSelector.AddIngredient(ingredient);
            }).AddTo(this);
        }
    }
}
