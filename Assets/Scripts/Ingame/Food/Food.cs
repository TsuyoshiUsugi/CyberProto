using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Food")]
public class Food : ScriptableObject
{
    public Ingredient[] ingredients;
    public Sprite Icon;
    public string Name;
}
