using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// д�����ռ��Ǹ���ϰ��
namespace FrameworkDesign.Example
{
   
    public class Enemy : MonoBehaviour
    {
      
        private void OnMouseDown()
        {
            new KillEnemyCommand().Execute();
            Destroy(this.gameObject);
            
        }
    }

}