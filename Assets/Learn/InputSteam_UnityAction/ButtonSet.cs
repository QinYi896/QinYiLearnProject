using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ButtonSet : MonoBehaviour
{
    public GameObject curbutton;
    private void OnEnable()
    {
        OnStartButton(curbutton);
    }

    public static void OnStartButton(GameObject ga)
    {
        if(ga != null)
        {
            var mevent = EventSystem.current;

            if (mevent != null)
            {
                mevent.SetSelectedGameObject(ga);
                Debug.Log(22);
            }
               
        }
    }
}
