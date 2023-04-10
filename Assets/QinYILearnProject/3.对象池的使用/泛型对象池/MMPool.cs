using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct MPoolGa
{
    public GameObject poolGa;
    public int producenum;
}
public class MMPool : MonoBehaviour
{
    public static MMPool _mmpool;
    public List<List<GameObject>> instGalist=new List<List<GameObject>>();

    public List<MPoolGa> poollist=new List<MPoolGa>();
    private void Awake()
    {
        _mmpool = this;
    }
    void Start()
    {

        for (int i = 0; i < poollist.Count; i++)
        {
            List<GameObject> curInslist = new List<GameObject>();
            for (int k = 0; k < poollist[i].producenum; k++)
            {
                GameObject ga = Instantiate(poollist[i].poolGa);
                ga.SetActive(false);
                ga.transform.SetParent(this.transform);
                curInslist.Add(ga);
            }
            instGalist.Add(curInslist);
        }
      
    }

   public  GameObject GetPool(int poolGaNum)
    {

      foreach(GameObject gaa in instGalist[poolGaNum])
        {
           if(!gaa.activeInHierarchy)
            {
                return gaa;
            }
        }

        GameObject ga = Instantiate(poollist[poolGaNum].poolGa);
        ga.transform.SetParent(this.transform);
        ga.SetActive(false);
        instGalist[poolGaNum].Add(ga);
        return ga;
      
    }
}
