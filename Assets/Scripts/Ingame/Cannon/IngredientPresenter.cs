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
            
            // �ޗ����N���b�N���ꂽ�Ƃ�
            _ingredientView.IngredientClicked.Subscribe(ingredient =>
            {
                _ingredientSelector.AddIngredient(ingredient);
            }).AddTo(this);
            
            
            
            // model to view
            
            // ��C�ɒǉ��\�ȍޗ��̌�₪�ω������Ƃ�
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
        /// ingredients�Ɋ܂܂��UI��enable�A�����łȂ����̂�disable����
        /// </summary>
        /// <param name="ingredients"></param>
        private void AnimateIngredientShowHide(List<Ingredient> ingredients){
            
        }

        /// <summary>
        /// ingredients�Ɋ܂܂��f�ނ��C�ɓ����A�j���[�V����
        /// </summary>
        /// <param name="ingredients"></param>
        private void AnimateCannonSetting(List<Ingredient> ingredients)
        {
            
        }
    }
}
