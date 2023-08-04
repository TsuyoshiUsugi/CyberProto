using UniRx;
using Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameServiceBuilder : Utility.ServiceLocatorBuilder
{
    [SerializeField]
    private FoodManager _foodManager;

    [SerializeField]
    private GameDirectionMediator _gameDirectionMediator;

    public override void Build(ServiceLocator locator)
    {
        locator.Register<IFoodContainer>(_foodManager)
            .AddTo(_foodManager);

        locator.Register<IGameDirector>(_gameDirectionMediator)
            .AddTo(_gameDirectionMediator);
    }
}
