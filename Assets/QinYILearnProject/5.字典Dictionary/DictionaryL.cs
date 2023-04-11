using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable] // 在 Inspector 中可见
public class Item
{
    public string name;
    public int id;
    public float HP;

}
public class DictionaryL : MonoBehaviour
{
    public List<Item> itemList; // 创建一个物品的列表

    public Dictionary<int, Item> itemDictionary = new Dictionary<int, Item>(); // 创建一个物品的字典并初始化（初始化是必须的）
    // key 的类型为 int，value 的类型为 Item
    // key 和 value 形成配对

    // Start is called before the first frame update
    void Start()
    {
        Item sword = new Item(); // 初始化一个物品
        sword.name = "陈"; // 设定物品的名字
        sword.id = 0; // 设定物品的 id
        sword.HP = 9;
        Item axe = new Item();
        axe.name = "毅";
        axe.id = 5;

        axe.HP = 99;
        Item bike = new Item();
        bike.name = "倭";
        bike.id = 3;
        bike.HP = 999;
        itemDictionary.Add(sword.id, sword); // 为物品字典添加一个元素
        itemDictionary.Add(axe.id, axe);
        itemDictionary.Add(bike.id, bike);

        //// 遍历字典：
        //foreach (KeyValuePair<int, Item> item in itemDictionary)
        //{
        //    Debug.Log("Key: " + item.Key);
        //    Debug.Log("Value: " + item.Value.name);
        //}
        //// 这里我们也可以写成 foreach(var item in itemDictionary)

        // 遍历字典的 key：
        foreach (var key in itemDictionary.Keys)
        {
            Debug.Log("Key: " + key);
        }
        // 这里的 key 是 int 类型
        // 所以也可以写成 foreach(int key in itemDictionary.Keys)

        // 遍历字典的 value：
        foreach (var value in itemDictionary.Values)
        {
           
            Debug.Log("Item Name: " + value.id);
            Debug.Log("Item Name: " + value.name);
            Debug.Log("Item Name: " + value.HP);
        }
    }


}
