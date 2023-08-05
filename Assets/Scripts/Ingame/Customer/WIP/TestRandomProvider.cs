using Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class TestRandomProvider : MonoBehaviour
{
#if UNITY_EDITOR
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            var customer = GetComponent<ICustomer>();
            var foodManager = FindFirstObjectByType<FoodManager>();
            var food = foodManager.GetRandomFood();
            if (customer.IsContains(food))
            {
                customer.OnProvide(food);
            }
        }
    }
#endif
}
