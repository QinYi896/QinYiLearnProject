using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ��������������
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
/// �й���������
/// </summary>
public class ChineseWeaponFactory : CountryWeaponFactoryBase
{
    public override void InitFactory(string factoryName)
    {
        base.InitFactory(factoryName);
        Debug.Log(string.Format("��ʼ��{0},����һЩ���Ի�����", factoryName));
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
/// ������������
/// </summary>
public class AmericanWeaponFactory : CountryWeaponFactoryBase
{
    public override void InitFactory(string factoryName)
    {
        base.InitFactory(factoryName);
        Debug.Log(string.Format("��ʼ��{0},����һЩ���Ի�����", factoryName));
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
        chineseWeaponFactory.InitFactory("�й�������");
        chineseWeaponFactory.CreatePistol("92ʽpistol");
        chineseWeaponFactory.CreateRifle("95ʽ�Զ���ǹ");

        CountryWeaponFactoryBase americanWeaponFactory = new AmericanWeaponFactory();
        americanWeaponFactory.InitFactory("������������");
        americanWeaponFactory.CreatePistol("MK23pistol");
        americanWeaponFactory.CreateRifle("M-16��ǹ");
    }

   
}
