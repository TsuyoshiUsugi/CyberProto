using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Utility
{
    [RequireComponent(typeof(ServiceLocatorBuildExecutor))]
    public abstract class ServiceLocatorBuilder : MonoBehaviour
    {
        private void Reset()
        {
            ServiceLocatorBuildExecutor executor = null;
            if(!TryGetComponent<ServiceLocatorBuildExecutor>(out executor))
            {
                executor = gameObject.AddComponent<ServiceLocatorBuildExecutor>();
            }

            if (!executor.builders.Contains(this))
            {
                executor.builders.Add(this);
            }
        }

        public abstract void Build(ServiceLocator locator);
    }
}
