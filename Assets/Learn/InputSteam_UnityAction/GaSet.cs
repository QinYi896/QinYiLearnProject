using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaSet : MonoBehaviour
{
    private string gaName;

    



    // Start is called before the first frame update
    void Start()
    {
        gaName = transform.gameObject.name;
        mEventCenter.AddListener<string,bool>(mEventType.mGaSet, GaAceSetFun);
    }
    private void OnDisable()
    {
        mEventCenter.RemoveListener<string,bool>(mEventType.mGaSet, GaAceSetFun);
    }

    private void GaAceSetFun(string _name,bool isCan)
    {
        if(gaName==_name)
        {
            transform.GetChild(0).gameObject.SetActive(isCan);
        }
    }
}
