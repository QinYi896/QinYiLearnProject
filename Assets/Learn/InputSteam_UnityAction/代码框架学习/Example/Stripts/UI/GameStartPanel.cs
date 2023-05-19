using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace FrameworkDesign.Example
{
    public class GameStartPanel : MonoBehaviour
    {
       
        void Start()
        {
            transform.Find("BtnGameStart").GetComponent<Button>().onClick.AddListener(() =>
            {
                transform.gameObject.SetActive(false);
                new StartGameCommand().Execute();
            });
        }

    }
}