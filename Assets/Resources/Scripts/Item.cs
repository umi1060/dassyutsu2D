using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable] // インスペクターで表示されるもの

public class Item
{

    public enum Type
    {
        default_null,
        shovel,
        pear,
        sunoil,
        surfboard,
        starfruit,
        rocket,
        fude,
        glasses,
        water_towel,
        ball,
        key,
        coin,
        beer,
        pillow,
        match,
        matchbox,
        hanabi

    }

    public Type type;
    public Sprite sprite;
    public string text;

    //　データベースのitemから反映

    public Item(Item item)
    {
        this.type = item.type;
        this.sprite = item.sprite;
        this.text = item.text;
    }

    public Item()
    {

    }


}
