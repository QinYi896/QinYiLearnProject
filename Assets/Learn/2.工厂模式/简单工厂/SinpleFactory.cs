using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Weapon
{
    public string Name { get; set; }
}

//pistol
public class Pistol : Weapon
{
    public Pistol(string name)
    {
        this.Name = name;
        Debug.Log(string.Format("这是一个{0}pistol", name));
    }
}

//步枪
public class Rifle : Weapon
{
    public Rifle(string name)
    {
        this.Name = name;
        Debug.Log(string.Format("这是一个{0}步枪", name));
    }
}

public enum WeaponType
{
    None = 0,
    EPistol,
    ERifle
}

public class WeaponFactory
{
    public Weapon Create(WeaponType type, string name)
    {
        Weapon weapon = null;
        switch (type)
        {
            case WeaponType.EPistol:
                weapon = new Pistol(name);
                break;
            case WeaponType.ERifle:
                weapon = new Rifle(name);
                break;
        }
        return weapon;
    }
}
/// <summary>
/// 简单工厂
/// 缺点：开闭原则(OCP)，即对扩展开放，对修改关闭
/// </summary>
public class SinpleFactory : MonoBehaviour
{
  
   
        void Start()
        {
            WeaponFactory weaponFactory = new WeaponFactory();
            Weapon weapon1 = weaponFactory.Create(WeaponType.EPistol, "王八盒子");
            Weapon weapon2 = weaponFactory.Create(WeaponType.ERifle, "AK47");
        }
    

}
