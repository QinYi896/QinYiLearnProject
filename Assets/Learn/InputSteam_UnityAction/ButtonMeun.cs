using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

interface IButton
{
    public void BtIn();
}


public class ButtonMeun : MonoBehaviour,IButton
{
    public string[] _name;
   

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
            {
                BtIn();
            });
    }
    public void BtIn()
    {
      if (_name[0] != null)
        mEventCenter.Broadcast<string, bool>(mEventType.mGaSet, _name[0], false);
        if (_name[1] != null)
            mEventCenter.Broadcast<string, bool>(mEventType.mGaSet, _name[1], true);
    }
}
