using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Exple : MonoBehaviour
{
    [SerializeField]
    IntStrDict m_strcolDict;
    public IDictionary<int,string> mSTrColDict
    {
        get { return m_strcolDict; }
        set { m_strcolDict.CopyFrom(value); }
    }
    // Start is called before the first frame update
    void Start()
    {
        if(mSTrColDict.ContainsKey(1))
        {
           
           // string st =(string) m_strcolDict[0];
            Debug.Log(mSTrColDict[1]);
        }
    }

}
