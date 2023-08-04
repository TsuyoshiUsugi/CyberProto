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
        public ReactiveCollection<Ingredient> Canditates { get; } = new ReactiveCollection<Ingredient>();
        public Subject<Unit> CandidateChanged { get; } = new Subject<Unit>();

        public void AddIngredient(Ingredient ingrediente)
        {
            throw new NotImplementedException();
        }
    }
}