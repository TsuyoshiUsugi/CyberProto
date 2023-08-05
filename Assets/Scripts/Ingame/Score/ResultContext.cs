using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "ResultContext")]
    public class ResultContext : ScriptableObject
    {
        public int _score;
        public int _orderCompleteNum;
        public float _populality;
    }
}
