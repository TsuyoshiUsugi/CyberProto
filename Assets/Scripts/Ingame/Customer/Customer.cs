using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class Customer : MonoBehaviour
{
    private Subject<Unit> requestFoodEntered = new Subject<Unit>();
    private Subject<Food> foodProvided = new Subject<Food>();
    private Subject<Unit> ProvideCompleted = new Subject<Unit>();


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
