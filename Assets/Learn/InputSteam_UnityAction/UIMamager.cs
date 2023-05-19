using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIMamager : MonoBehaviour
{
    public UnityAction num1Act;

    public UnityAction meunAct;

    public void Num1Bt()
    {
        num1Act.Invoke();
    }
}
