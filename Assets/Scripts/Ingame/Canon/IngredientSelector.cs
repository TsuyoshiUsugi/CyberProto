using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace Game
{
    public class IngredientSelector : MonoBehaviour
    {
        public List<Ingredient> Selecting { get; set; }
        public ReactiveCollection<Ingredient> Canditates { get; } = new ReactiveCollection<Ingredient>();
        public Subject<Unit> CandidateChanged { get; } = new Subject<Unit>();

        void AddIngredient(Ingredient ingrediente)
        {
            throw new NotImplementedException();
        }
    }
}