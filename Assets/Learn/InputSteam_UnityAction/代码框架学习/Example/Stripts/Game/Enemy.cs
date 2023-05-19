using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 写命名空间是个好习惯
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