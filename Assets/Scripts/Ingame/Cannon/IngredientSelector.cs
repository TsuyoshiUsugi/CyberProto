using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace Game
{
    public class IngredientSelector : MonoBehaviour
    {
        private List<Ingredient> _selecting = new List<Ingredient>();
        public List<Ingredient> Selecting => _selecting;
        private Food _creatableFood;
        [SerializeField] private FoodManager _foodManager;
        [SerializeField] private Cannon _cannon;
        
        public List<Ingredient> Canditates { get; private set; } = new List<Ingredient>();
        public Subject<List<Ingredient>> CandidateChanged { get; } = new Subject<List<Ingredient>>();


        private void Start()
        {
            // Candidatesを初期化して発火
            Canditates = _foodManager.GetCandidateIngredients(_selecting);
            foreach(var e in Canditates)
            {
                Debug.Log($"cand: {e.Name}");
            }


            Debug.Log($"cand count: {Canditates.Count}");
            _cannon.Fired.Subscribe(_ =>
            {
                ResetIngredients();
            }).AddTo(this);  
        }

        /// <summary>
        /// 選択中の材料を更新する
        /// </summary>
        /// <param name="ingredient"></param>
        public void AddIngredient(Ingredient ingredient)
        {
            _selecting.Add(ingredient);

            foreach(var ing in _selecting)
            {
                Debug.Log(ing.Name);
            }

            if (_foodManager.TryGetCreatableFood(_selecting, out _creatableFood))
            {
                Debug.Log("true");
                _cannon.SetFood(_creatableFood);
            }else
            {
                Debug.Log("false");
            }

            // Foodが作れなくてもcandidateは更新される場合がある
            Canditates = _foodManager.GetCandidateIngredients(_selecting);
            CandidateChanged.OnNext(Canditates);
        }

        /// <summary>
        /// 選択中の材料をリセットする
        /// </summary>
        public void ResetIngredients()
        {
            _selecting.Clear();
            // Foodが作れなくてもcandidateは更新される場合がある
            Canditates = _foodManager.GetCandidateIngredients(_selecting);
            CandidateChanged.OnNext(Canditates);
        }
    }
}