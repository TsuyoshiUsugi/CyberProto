using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [Serializable]
    public struct SpawnCycle
    {
        public float span;
        public Customer customerPrefab;
        public int initOffset;
    }
}