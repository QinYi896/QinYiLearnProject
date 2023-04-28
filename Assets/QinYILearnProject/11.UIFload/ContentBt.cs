using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentBt : MonoBehaviour
{
    public List<Button> childBt = new List<Button>();
    [HideInInspector]
    public bool isButtonIn;
    private void Start()
    {
        transform.GetComponent<Button>().onClick.AddListener(() =>
        {
            Set();
        });

        Set();
    }

    public void Set()
    {
       foreach(Button bt in childBt)
        {
            bt.gameObject.SetActive(isButtonIn);
        }

        isButtonIn = !isButtonIn;
    }
    public void AddChild(Button bt)
    {
        childBt.Add(bt);
    }
    public void RemoveChild(Button bt)
    {
        childBt.Remove(bt);
    }
}
