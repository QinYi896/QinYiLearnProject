using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Commend
    {
    public abstract void execube(Control control);
}

public  class JumpCommend : Commend
{
    public override void execube(Control control)
    {
        //JUmp
        control.Jum();
        
    }
}

public class FireCommend : Commend
{
    public override void execube(Control control)
    {
        //Fire
        control.Fire();
    }
}

public  class AttackCommend : Commend
{
    public override void execube(Control control)
    {
        //Attack
        control.Attact();
    }
}
public class InpuHandler : MonoBehaviour
{
  public  JumpCommend jumpm=new JumpCommend();
 public   FireCommend firem=new FireCommend();
 public   AttackCommend attackm=new AttackCommend();
    KeyCode[] keycodes = { KeyCode.Space, KeyCode.F, KeyCode.K };

    public Control control1;

    private void Start()
    {

  
    }
    private void Update()
    {
        Commend commend = Inputhadler();
        if (commend != null)
        {
          
            commend.execube(control1);
        }
    }

    public Commend Inputhadler()
    {
        if(Input.GetKeyDown(keycodes[0]))
            {
            return jumpm;
        }
        if (Input.GetKeyDown(keycodes[1]))
        {
        
            return firem;
        }
        if (Input.GetKeyDown(keycodes[2]))
        {
            return attackm;
        }
        return null;
    }
}
