using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace Game
{
    public class Cannon : MonoBehaviour
    {
        // private List<Ingredient> _Selecting;
        public List<Ingredient> Selecting { get; set; }
        public ReactiveCollection<Ingredient> Canditates { get; } = new ReactiveCollection<Ingredient>();
        public Subject<Unit> CandidateChanged { get; } = new Subject<Unit>();

        void AddIngredient(Ingredient ingrediente)
        {
            throw new NotImplementedException();
        }
    }
}


