using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;

[CreateAssetMenu]
public class LevelSettings : ScriptableObject
{
    public int clearScore;
    public Food[] foods;
    public SpawnCycle[] normalCycles;
    public SpawnCycle[] rushCycles;
    public float rushStartTime;
    public float rushEndTime;
    public int _rankSBorder;
    public int _rankABorder;
    public int _rankBBorder;
}