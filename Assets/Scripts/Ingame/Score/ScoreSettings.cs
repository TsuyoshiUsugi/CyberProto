using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "ScoreSettings")]
    public class ScoreSettings : ScriptableObject
    {
        public int IngredientScore;
        public int CompleteBonus;
        public int SpeedBonus;

        [Header("5’iŠK")]
        public int[] PopularityBonuses = new int[5];
    }
}