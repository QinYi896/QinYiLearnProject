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

            // ʮ��ȫ����������ʾͨ�ؽ���
            if (PointGame.Get<IGameModel>().KillCount.Value == 10)
            {
                GamePassEvent.Trigger();
            }
        }

       
    }
}
