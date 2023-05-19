using System.Collections;
using System.Collections.Generic;
using UnityEngine;
interface I1
{
    public void method1();
}

interface I2
{
    public void method2();
    public void method3();
}

interface I3
{
    public void method4();
    public void method5();
}

class A2
{
    public void depend1(I1 i)
    {
        i.method1();
    }
    public void depend2(I2 i)
    {
        i.method2();
    }
    public void depend3(I2 i)
    {
        i.method3();
    }
}

class B2 : I1, I2{  
    public void method1()
{
     Debug.Log("类 B 实现接口 I1 的方法 1");
}
public void method2()
{
     Debug.Log("类 B 实现接口 I2 的方法 2");
}
public void method3()
{
     Debug.Log("类 B 实现接口 I2 的方法 3");
}  
}  
  
class C2
{
    public void depend1(I1 i)
    {
        i.method1();
    }
    public void depend2(I3 i)
    {
        i.method4();
    }
    public void depend3(I3 i)
    {
        i.method5();
    }
}

class D2 : I1, I3{  
    public void method1()
{
     Debug.Log("类 D 实现接口 I1 的方法 1");
}
public void method4()
{
     Debug.Log("类 D 实现接口 I3 的方法 4");
}
public void method5()
{
     Debug.Log("类 D 实现接口 I3 的方法 5");
}  
}  
public class LSP2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

}
