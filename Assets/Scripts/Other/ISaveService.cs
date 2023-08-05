using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISaveService
{
    bool Save<T>(string filename, T data);
    bool Load<T>(string filename, out T? data);
}
