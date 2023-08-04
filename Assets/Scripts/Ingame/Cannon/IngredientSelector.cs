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
        private Food _creatableFood;
        [SerializeField] private FoodManager _foodManager;
        [SerializeField] private Cannon _cannon;
        
        public List<Ingredient> Canditates { get; private set; } = new List<Ingredient>();
        public Subject<List<Ingredient>> CandidateChanged { get; } = new Subject<List<Ingredient>>();
        
        /// <summary>
        /// �I�𒆂̍ޗ����X�V����
        /// </summary>
        /// <param name="ingredient"></param>
        public void AddIngredient(Ingredient ingredient)
        {
            _selecting.Add(ingredient);
            if (_foodManager.TryGetCreatableFood(_selecting, out _creatableFood))
            {
                _cannon.SetFood(_creatableFood);
            }
            // Food�����Ȃ��Ă�candidate�͍X�V�����ꍇ������
            Canditates = _foodManager.GetCandidateIngredients(_selecting);
            CandidateChanged.OnNext(Canditates);
        }

        /// <summary>
        /// �I�𒆂̍ޗ������Z�b�g����
        /// </summary>
        public void ResetIngredients()
        {
            _selecting.Clear();
            // Food�����Ȃ��Ă�candidate�͍X�V�����ꍇ������
            Canditates = _foodManager.GetCandidateIngredients(_selecting);
            CandidateChanged.OnNext(Canditates);
        }
    }
}