using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class UseSurfBoard : MonoBehaviour
{
    public void OnClick()
    {
        if (ItemBox.instance.checkSelectSlotItem(Item.Type.surfboard) == true)
        {
            //タイムライン再生
            this.GetComponent<PlayableDirector>().Play();
        }
    }

    //タイムライン最後に実行する関数
    public void AfterTimeLine()
    {
        ItemBox.instance.UseSelectItem();

        // TapPositionTrue.SetActive(true);
        FlagManager.instance.UseSurfBoard = true;
        this.gameObject.SetActive(false);


    }
}
