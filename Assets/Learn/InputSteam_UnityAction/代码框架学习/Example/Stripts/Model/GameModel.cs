using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FrameworkDesign.Example
{
    public interface IGameModel
    {
        public BindableProperty<int> KillCount { get; }
        public BindableProperty<int> Gold { get; }
        public BindableProperty<int> Score { get; }
        public BindableProperty<int> BestScore { get; }
    }

   // public class GameModel : Singleton<GameModel>
    public class GameModel:IGameModel
    {

        BindableProperty<int> IGameModel.KillCount { get; } = new BindableProperty<int>()
        {
            Value = 0
        };


        BindableProperty<int> IGameModel.Gold { get; } = new BindableProperty<int>()
        {
            Value = 0
        };

        BindableProperty<int> IGameModel.Score { get; } = new BindableProperty<int>()
        {
            Value = 0
        };

        BindableProperty<int> IGameModel.BestScore { get; } = new BindableProperty<int>()
        {
            Value = 0
        };
    }
}