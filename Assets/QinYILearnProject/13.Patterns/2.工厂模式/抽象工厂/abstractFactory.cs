using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 国家武器基类类
/// </summary>
public abstract class CountryWeaponFactoryBase
{
    string name;
    public WeaponFactoryBase RifleFactory;
    public WeaponFactoryBase PistolFactory;

    public virtual void InitFactory(string factoruName)
    {
        name = factoruName;
        RifleFactory = new RifleFactory();
        PistolFactory = new PistolFactory();
    }

    public abstract void CreatePistol(string name);
    public abstract void CreateRifle(string name);

}

/// <summary>
/// 中国武器工厂
/// </summary>
public class ChineseWeaponFactory : CountryWeaponFactoryBase
{
    public override void InitFactory(string factoryName)
    {
        base.InitFactory(factoryName);
        Debug.Log(string.Format("初始化{0},并做一些个性化设置", factoryName));
    }

    public override void CreatePistol(string name)
    {
        base.PistolFactory.CreateWeapon(name);
    }

    public override void CreateRifle(string name)
    {
        base.RifleFactory.CreateWeapon(name);
    }
}

/// <summary>
/// 美国武器工厂
/// </summary>
public class AmericanWeaponFactory : CountryWeaponFactoryBase
{
    public override void InitFactory(string factoryName)
    {
        base.InitFactory(factoryName);
        Debug.Log(string.Format("初始化{0},并做一些个性化设置", factoryName));
    }

    public override void CreatePistol(string name)
    {
        base.PistolFactory.CreateWeapon(name);
    }

    public override void CreateRifle(string name)
    {
        base.RifleFactory.CreateWeapon(name);
    }
}
public class abstractFactory : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CountryWeaponFactoryBase chineseWeaponFactory = new ChineseWeaponFactory();
        chineseWeaponFactory.InitFactory("中国军工厂");
        chineseWeaponFactory.CreatePistol("92式pistol");
        chineseWeaponFactory.CreateRifle("95式自动步枪");

        CountryWeaponFactoryBase americanWeaponFactory = new AmericanWeaponFactory();
        americanWeaponFactory.InitFactory("美国武器工厂");
        americanWeaponFactory.CreatePistol("MK23pistol");
        americanWeaponFactory.CreateRifle("M-16步枪");
    }

   
}
