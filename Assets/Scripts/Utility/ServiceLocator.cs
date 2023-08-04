using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocator
{
    public static readonly ServiceLocator Instance = new ServiceLocator();

    Dictionary<Type, object> services = new Dictionary<Type, object>();

    /// <summary>
    /// �T�[�r�X��o�^����
    /// </summary>
    public IDisposable Register<T>(T instance) where T : class
    {
        if (!services.TryAdd(typeof(T), instance))
        {
            services[typeof(T)] = instance;
        }

        return new Disposable<T>(instance);
    }

    /// <summary>
    /// �T�[�r�X���擾����
    /// </summary>
    public T Resolve<T>() where T : class
    {
        if (services.TryGetValue(typeof(T), out var service))
        {
            return (T)service;
        }

        return null;
    }

    /// <summary>
    /// �T�[�r�X��j������
    /// </summary>
    public void UnRegister<T>(T instance) where T : class
    {
        if (services.TryGetValue(typeof(T), out var service))
        {
            if (instance == service)
            {
                services.Remove(typeof(T));
            }
        }
    }

    private class Disposable<T> : IDisposable where T : class
    {
        private readonly T Instance;

        public Disposable(T instance)
        {
            this.Instance = instance;
        }

        public void Dispose()
        {
            ServiceLocator.Instance.UnRegister<T>(Instance);
        }
    }
}
