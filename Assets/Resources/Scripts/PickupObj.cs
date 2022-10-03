using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PickupObj : MonoBehaviour
{
    // typeを持っている
    public Item.Type type = default;

    public static PickupObj instance;

    private void Awake()
    {
        instance = this;
    }

    

    public void OnClickObj()
    {
        // ItemDatabaseにtypeを渡して、Itemクラスを受け取る
        Item item = ItemDataBase.instance.Spawn(type);
        // TODO クリックしたら画像のフェードイン
        
        // ItemBoxで入手
        ItemBox.instance.SetItem(item);
        // ZoomPanel表示　TODO フェードアニメーションで表示
        ItemBox.instance.FadeInZoomPanel(item);

        // SE
       

       


    }

    
}
