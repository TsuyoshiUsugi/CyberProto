using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game
{
    [CreateAssetMenu(fileName = "Food")]
    public class Food : ScriptableObject
    {
        public Ingredient[] ingredients;
        public Sprite Icon;
        public string Name;
    }
}