using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonIn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            mEventCenter.Broadcast(mEventType.ShowText);
            mEventCenter.Broadcast(mEventType.ShowText2, 3, 4.5555555f, "¼àÌýÊÂ¼þ¹ã²¥",this.gameObject);
        });
    }

    
}
