using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;

public class TestFoodManager : MonoBehaviour
{
    FoodManager _foodManager;
    [SerializeField] List<Ingredient> _items = new();
    // Start is called before the first frame update
    void Start()
    {
        _foodManager = GetComponent<FoodManager>();        

        var list = _foodManager.GetCandidateIngredients(_items);

        var a = _foodManager.TryGetCreatableFood(_items, out Food food);
        Debug.Log($"{a} : {food.Name}");
    }
}
