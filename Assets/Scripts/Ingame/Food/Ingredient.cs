using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "Ingredient")]
    public class Ingredient : ScriptableObject
    {
        public string Name;
        public Sprite Icon;
        public int Id;
    }
}