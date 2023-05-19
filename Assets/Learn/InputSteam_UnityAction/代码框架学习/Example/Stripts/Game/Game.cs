using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FrameworkDesign.Example
{
    public class Game : MonoBehaviour
    {
        // Start is called before the first frame update
     public   GameObject ga;
        void Start()
        {
            GameStartEvent.Register(OngameStart);
          
        }
        private void OngameStart()
        {
            //ga = transform.Find("Enemies").gameObject;
            //ga.SetActive(true);
            ga = transform.Find("Enemies").gameObject;
            ga.SetActive(true);
        }

        private void OnDisable()
        {
            GameStartEvent.UnRegister(OngameStart);
           
        }
      
    }
}