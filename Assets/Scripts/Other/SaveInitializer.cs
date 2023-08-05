using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveInitializer
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Init()
    {
        ServiceLocator.Instance.Register<ISaveService>(new PlayerPrefsSaveService());
    }
}
