using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 武器工厂抽象基类
/// </summary>
public abstract class WeaponFactoryBase
{
    public abstract Weapon CreateWeapon(string name);
}

/// <summary>
/// pistol生产工厂
/// </summary>
public class PistolFactory : WeaponFactoryBase
{
    public override Weapon CreateWeapon(string name)
    {
        return new Pistol(name);
    }
}

/// <summary>
/// 步枪生产工厂
/// </summary>
public class RifleFactory : WeaponFactoryBase
{
    public override Weapon CreateWeapon(string name)
    {
        return new Rifle(name);
    }
}
public class FactoryMe : MonoBehaviour
{
   
    private void Start()
    {
        PistolFactory pis = new PistolFactory();
        Weapon weapon1 = pis.CreateWeapon("王八盒子");

        RifleFactory rifle = new RifleFactory();
        Weapon we2 = rifle.CreateWeapon("手枪");
    }
}
