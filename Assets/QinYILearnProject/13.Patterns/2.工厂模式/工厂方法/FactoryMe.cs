using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ���������������
/// </summary>
public abstract class WeaponFactoryBase
{
    public abstract Weapon CreateWeapon(string name);
}

/// <summary>
/// pistol��������
/// </summary>
public class PistolFactory : WeaponFactoryBase
{
    public override Weapon CreateWeapon(string name)
    {
        return new Pistol(name);
    }
}

/// <summary>
/// ��ǹ��������
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
        Weapon weapon1 = pis.CreateWeapon("���˺���");

        RifleFactory rifle = new RifleFactory();
        Weapon we2 = rifle.CreateWeapon("��ǹ");
    }
}
