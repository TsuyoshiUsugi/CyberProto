using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "Food")]
    public class Food : ScriptableObject
    {
        [SerializeField] Ingredient[] _ingredients;
        [SerializeField] Sprite _icon;
        [SerializeField] string _name;

        public Ingredient[] Ingredients => _ingredients;
        public Sprite Icon => _icon;
        public string Name => _name;
    }
}
