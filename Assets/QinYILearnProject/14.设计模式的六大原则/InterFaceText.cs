using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����Ľӿ�
/// </summary>
public interface IPerSon
{
    /// <summary>
    /// �����ķ���
    /// </summary>
    /// <param name="read"></param>

    public void ReadFun(IRead read);
}

public interface IRead
    {
    public void GetRead();
}

public class Magazine : IRead
{
    public void GetRead()
    {
        Debug.Log("ϲ������־");
    }
}

public class StoryBool : IRead
{
    public void GetRead()
    {
        Debug.Log("ϲ����������");
    }
}

public class CartoonBook : IRead
{
    public void GetRead()
    {
        Debug.Log("ϲ������");
    }
}


public class mother:IPerSon
{
    public void ReadFun(IRead read)
    {
        Debug.Log("ĸ��");
        read.GetRead();
    }
}


public class My : IPerSon
{
    public void ReadFun(IRead read)
    {
        Debug.Log("��");
        read.GetRead();
    }
}
/// <summary>
/// ��������
/// </summary>
public class InterFaceText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //mother mo = new mother();
        //mo.ReadFun(new  CartoonBook());
        IPerSon mo = new mother();
        IRead cartoonbook = new CartoonBook();
        mo.ReadFun(cartoonbook);

        IPerSon wo = new My();
        IRead story = new StoryBool();
        wo.ReadFun(story);
    }

 
}
