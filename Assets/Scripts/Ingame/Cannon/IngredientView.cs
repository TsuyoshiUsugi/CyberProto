using DG.Tweening;
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
        private List<UnionIngredientUI> _ingredientButtonDictionary;

        [SerializeField]
        private Transform _cannonTrans;

        private List<Ingredient> _availableIngredients = new List<Ingredient>();
        public Subject<Ingredient> IngredientClicked { get; set; } = new Subject<Ingredient>();

        private void Start()
        {
            foreach(var union in _ingredientButtonDictionary)
            {
                union.Button.OnClickAsObservable()
                    .Subscribe(_ =>
                    {
                        Debug.Log(union.Ingredient.Name);
                        IngredientClicked.OnNext(union.Ingredient);
                    }).AddTo(this);
            }
        }

        /// <summary>
        /// 選択した材料を選択できないようにする
        /// </summary>
        /// <param name="ingredients"></param>
        /// <param name="selecting"></param>

        public void SetActiveIngredients(List<Ingredient> ingredients, List<Ingredient> selecting)
        {
            foreach (var ingredientButton in _ingredientButtonDictionary)
            {
                ingredientButton.Button.enabled = false;
                ingredientButton.Image.color = Color.gray;
            }

            foreach (var ingredient in ingredients)
            {
                Debug.Log($"ingred: {ingredient.Name}");
                var c = GetIngredientUI(ingredient);
                c.Button.enabled = true;
                c.Image.color = new Color(1, 1, 1, 1);
            }

            foreach (var selectIngredient in selecting)
            {
                var c = GetIngredientUI(selectIngredient);
                c.Button.enabled = false;
                c.Image.color = Color.gray;
            }
        }

        /// <summary>
        /// 選択した材料を大砲に入れるアニメーションを再生する
        /// </summary>
        /// <param name="ingredients"></param>
        public void UseIngredients(List<Ingredient> ingredients)
        {
            foreach (var i in ingredients)
            {
                var ui = GetIngredientUI(i);

                ui.Image.transform.DOMove(_cannonTrans.position, 0.5f);
            }
        }
        /// <summary>
        /// 材料の位置を元に戻す
        /// </summary>

        public void ResetIngredientView()
        {
            foreach (var ui in _ingredientButtonDictionary)
            {
                ui.Button.enabled = true;
                ui.Image.color = new Color(1, 1, 1, 1);
                ui.Image.transform.position = ui.Button.transform.position;
            }
        }

        private Button GetButton(Ingredient ingredient)
        {
            return _ingredientButtonDictionary.First(x => x.Ingredient.Id == ingredient.Id).Button;
        }
        private UnionIngredientUI GetIngredientUI(Ingredient ingredient)
        {
            return _ingredientButtonDictionary.First(x => x.Ingredient.Id == ingredient.Id);
        }
    }

    

    [System.Serializable]
    public struct UnionIngredientUI
    {
        [SerializeField]
        private Button _button;
        [SerializeField]
        private Image _image;
        [SerializeField]
        private Ingredient _ingredient;

        public Button Button { get { return _button; } }
        public Image Image { get { return _image; } }
        public Ingredient Ingredient { get { return _ingredient; } }
    }
}

