using System.Collections;
using System.Collections.Generic;
using UnityEngine;
interface I
{
    public void method1();
    public void method2();
    public void method3();
    public void method4();
    public void method5();
}

class A
{
    public void depend1(I i)
    {
        i.method1();
    }
    public void depend2(I i)
    {
        i.method2();
    }
    public void depend3(I i)
    {
        i.method3();
    }
}

class B :I
{
	 // �� B ֻ��Ҫʵ�ַ��� 1��2, 3��������������������Ҫ������Ҳ��Ҫʵ��
    public void method1()
{
       
    Debug.Log("�� B ʵ�ֽӿ� I �ķ��� 1");
}
public void method2()
{
    Debug.Log("�� B ʵ�ֽӿ� I �ķ��� 2");
}
public void method3()
{
    Debug.Log("�� B ʵ�ֽӿ� I �ķ��� 3");
}
public void method4() { }
public void method5() { }  
}  
  
class C
{
    public void depend1(I i)
    {
        i.method1();
    }
    public void depend2(I i)
    {
        i.method4();
    }
    public void depend3(I i)
    {
        i.method5();
    }
}


class D : I
{
	// �� D ֻ��Ҫʵ�ַ��� 1��4��5��������������������Ҫ������Ҳ��Ҫʵ��
    public void method1()
{
    Debug.Log("�� D ʵ�ֽӿ� I �ķ��� 1");
}
public void method2() { }
public void method3() { }
public void method4()
{
    Debug.Log("�� D ʵ�ֽӿ� I �ķ��� 4");
}
public void method5()
{
    Debug.Log("�� D ʵ�ֽӿ� I �ķ��� 5");
}  
}  

public class ISP : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        A a = new A();
        a.depend1(new B());
        a.depend2(new B());
        a.depend3(new B());

        C c = new C();
        c.depend1(new D());
        c.depend2(new D());
        c.depend3(new D());
    }

   
}
