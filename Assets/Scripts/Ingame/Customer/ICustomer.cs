using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public interface ICustomer
    {
        bool IsContains(Food food);

        void OnProvide(Food food);
    }

}