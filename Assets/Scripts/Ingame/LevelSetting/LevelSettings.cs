using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LevelSettings : ScriptableObject
{
    public int clearScore;
    public Food[] foods;
    public SpawnCycle[] normalCycles;
    public SpawnCycle[] rushCycles;
    public float rushStartTime;
    public float rushEndTime;
}