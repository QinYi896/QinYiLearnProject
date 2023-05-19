using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 人类的接口
/// </summary>
public interface IPerSon
{
    /// <summary>
    /// 会读书的方法
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
        Debug.Log("喜欢读杂志");
    }
}

public class StoryBool : IRead
{
    public void GetRead()
    {
        Debug.Log("喜欢读故事书");
    }
}

public class CartoonBook : IRead
{
    public void GetRead()
    {
        Debug.Log("喜欢漫画");
    }
}


public class mother:IPerSon
{
    public void ReadFun(IRead read)
    {
        Debug.Log("母亲");
        read.GetRead();
    }
}


public class My : IPerSon
{
    public void ReadFun(IRead read)
    {
        Debug.Log("我");
        read.GetRead();
    }
}
/// <summary>
/// 依赖倒置
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
