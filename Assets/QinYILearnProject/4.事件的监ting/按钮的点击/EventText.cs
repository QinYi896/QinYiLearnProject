using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EventText : MonoBehaviour
{
   

    private void Awake()
    {
        gameObject.SetActive(false);
        //  EventCenter.AddListener<string>(EventType.ShowText,Show);
         mEventCenter.AddListener<int, float, string, GameObject>(mEventType.ShowText2, ShowText2);
        mEventCenter.AddListener(mEventType.ShowText, ShowText3);
    }

    private void OnDestroy()
    {
        mEventCenter.RemoveListener<int, float, string, GameObject>(mEventType.ShowText2, ShowText2);
       //  EventCenter.RemoveListener<string>(EventType.ShowText, Show);
        mEventCenter.RemoveListener(mEventType.ShowText, ShowText3);
    }
    private void Show(string str)
    {
        gameObject.SetActive(true);
        GetComponent<Text>().text = str;
    }

    private void ShowText2(int num, float hight,string name,GameObject ga)
    {
        gameObject.SetActive(true);
        GetComponent<Text>().text = "����Ϊ{0}���߶�Ϊ{1}������Ϊ{2}������Ϊ{3}"+num+hight+name+ga;
    }

    private void ShowText3()
    {
        GetComponent<Text>().color = Color.red;
    }
}
