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
        Debug.Log(string.Format("����һ��{0}pistol", name));
    }
}

//��ǹ
public class Rifle : Weapon
{
    public Rifle(string name)
    {
        this.Name = name;
        Debug.Log(string.Format("����һ��{0}��ǹ", name));
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
/// �򵥹���
/// ȱ�㣺����ԭ��(OCP)��������չ���ţ����޸Ĺر�
/// </summary>
public class SinpleFactory : MonoBehaviour
{
  
   
        void Start()
        {
            WeaponFactory weaponFactory = new WeaponFactory();
            Weapon weapon1 = weaponFactory.Create(WeaponType.EPistol, "���˺���");
            Weapon weapon2 = weaponFactory.Create(WeaponType.ERifle, "AK47");
        }
    

}
