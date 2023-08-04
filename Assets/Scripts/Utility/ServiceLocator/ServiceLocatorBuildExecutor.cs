using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utility
{
    public sealed class ServiceLocatorBuildExecutor : MonoBehaviour
    {
        public List<ServiceLocatorBuilder> builders;

        private void Awake()
        {
            for(int i = 0; i < builders.Count; i++)
            {
                if (builders[i] != null)
                {
                    builders[i].Build(ServiceLocator.Instance);
                }
            }
        }
    }
}

