using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatType
{
    Health,
    Speed,
    ProjectileCount
}

[CreateAssetMenu(fileName = "New StatData", menuName = "Stats/Character Stats")]
public class StatData : ScriptableObject
{
    public string characterName;
    public List<StatEntry> stats;
}

[System.Serializable]
public class StatEntry
{
    public StatType statType;
    public float baseValue;
}