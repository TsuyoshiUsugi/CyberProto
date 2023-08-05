using System;

namespace Game
{
    public interface ISpawner
    {
        IObservable<Customer> CustomerInstantiated { get; }
    }
}