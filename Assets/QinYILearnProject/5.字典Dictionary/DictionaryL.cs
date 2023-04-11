using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable] // �� Inspector �пɼ�
public class Item
{
    public string name;
    public int id;
    public float HP;

}
public class DictionaryL : MonoBehaviour
{
    public List<Item> itemList; // ����һ����Ʒ���б�

    public Dictionary<int, Item> itemDictionary = new Dictionary<int, Item>(); // ����һ����Ʒ���ֵ䲢��ʼ������ʼ���Ǳ���ģ�
    // key ������Ϊ int��value ������Ϊ Item
    // key �� value �γ����

    // Start is called before the first frame update
    void Start()
    {
        Item sword = new Item(); // ��ʼ��һ����Ʒ
        sword.name = "��"; // �趨��Ʒ������
        sword.id = 0; // �趨��Ʒ�� id
        sword.HP = 9;
        Item axe = new Item();
        axe.name = "��";
        axe.id = 5;

        axe.HP = 99;
        Item bike = new Item();
        bike.name = "��";
        bike.id = 3;
        bike.HP = 999;
        itemDictionary.Add(sword.id, sword); // Ϊ��Ʒ�ֵ����һ��Ԫ��
        itemDictionary.Add(axe.id, axe);
        itemDictionary.Add(bike.id, bike);

        //// �����ֵ䣺
        //foreach (KeyValuePair<int, Item> item in itemDictionary)
        //{
        //    Debug.Log("Key: " + item.Key);
        //    Debug.Log("Value: " + item.Value.name);
        //}
        //// ��������Ҳ����д�� foreach(var item in itemDictionary)

        // �����ֵ�� key��
        foreach (var key in itemDictionary.Keys)
        {
            Debug.Log("Key: " + key);
        }
        // ����� key �� int ����
        // ����Ҳ����д�� foreach(int key in itemDictionary.Keys)

        // �����ֵ�� value��
        foreach (var value in itemDictionary.Values)
        {
           
            Debug.Log("Item Name: " + value.id);
            Debug.Log("Item Name: " + value.name);
            Debug.Log("Item Name: " + value.HP);
        }
    }


}
