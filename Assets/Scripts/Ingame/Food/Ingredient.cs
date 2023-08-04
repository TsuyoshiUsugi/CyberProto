using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "Ingredient")]
    public class Ingredient : ScriptableObject
    {
        [SerializeField] string _name;
        [SerializeField] Sprite _icon;
        [SerializeField] int _id;

        public string Name => _name;
        public Sprite Icon => _icon;
        public int Id => _id;
    }
}
