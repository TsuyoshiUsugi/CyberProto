using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
  [CreateAssetMenu(fileName = "ScoreSettings")]
  public class ScoreSettings : ScriptableObject
  {
    public int _infredientScore;
    public int _completeBonus;
    public int _speedBonus;
    public int[] _popularityBonuses;
  }
}