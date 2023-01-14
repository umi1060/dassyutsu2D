using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class UseFude : MonoBehaviour
{

    public void OnClick()
    {
        if (ItemBox.instance.checkSelectSlotItem(Item.Type.fude) == true)
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
        FlagManager.instance.UseFude = true;
        this.gameObject.SetActive(false);
        

    }
}
