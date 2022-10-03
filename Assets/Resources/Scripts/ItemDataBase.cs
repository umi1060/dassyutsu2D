using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDataBase : MonoBehaviour
{
    public static ItemDataBase instance;

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] ItemDataBaseEntity itemDataBaseEntity = default;

    // Itemをtypeから生成する
    public Item Spawn(Item.Type type)
    {
        foreach (Item itemData in itemDataBaseEntity.items)
        {
            if (itemData.type == type)
            {
                return new Item(itemData);
            }
        }

        return null;
    }
}