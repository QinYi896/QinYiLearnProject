using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


[System.Serializable]
public struct Date
{
    public int id;
    public string name;
    public float HP;
}

public class M_dictionary : MonoBehaviour
{
    public List<Date> dateslist = new List<Date>();

    private Dictionary<int, Date> dateDic = new Dictionary<int, Date>();

 
    void Start()
    {
        //Date d1;
        //d1.id = 0;
        //d1.name = "超级无敌大";
        //d1.HP = 77;

        //Date d2;
        //d2.id = 1;
        //d2.name = "手动滑稽奥斯";
        //d2.HP = 99;

        //Date d3;
        //d3.id = 2;
        //d3.name = "圣诞始动画福斯啊";
        //d3.HP = 999;

        //dateDic.Add(d1.id,d1);
        //dateDic.Add(d2.id, d2);
        //dateDic.Add(d3.id, d3);

        //foreach(var dic in  dateDic.Values )
        //{
        //    Debug.Log(dic.id+":"+dic.name+":"+dic.HP);
        //}
        //int k;
        //string str;

        //var item = dateDic[d1.id];
        //Debug.Log(item.name);
        //Debug.Log(item.HP);


    for(int i=0;i<dateslist.Count;i++)
        {
            dateDic.Add(i,dateslist[i]);
        }

        var item = dateDic[dateslist[2].id];
        Debug.Log(item.name);
        Debug.Log(item.HP);

        foreach (var dic in dateDic.Values)
        {
            Debug.Log(dic.id + ":" + dic.name + ":" + dic.HP);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
