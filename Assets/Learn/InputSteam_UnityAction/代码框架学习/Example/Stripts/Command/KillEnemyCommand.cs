using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FrameworkDesign.Example
{

    public class KillEnemyCommand :ICommand
    {
        public void Execute()
        {
          PointGame.Get<IGameModel>() .KillCount.Value++;

            // 十个全部消灭再显示通关界面
            if (PointGame.Get<IGameModel>().KillCount.Value == 10)
            {
                GamePassEvent.Trigger();
            }
        }

       
    }
}
