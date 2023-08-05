using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceInitialize : MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Init()
    {

    }
}
