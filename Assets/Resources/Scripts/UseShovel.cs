using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


public class UseShovel : MonoBehaviour
{

    // Start is called before the first frame update
    public void OnClick()
    {
        if(ItemBox.instance.checkSelectSlotItem(Item.Type.shovel) == true)
        {

            //タイムライン再生
            this.GetComponent<PlayableDirector>().Play();

           
        }
    }

    //タイムライン最後に実行する関数

    public void AfterTimeLine()
    {
        //MaskPanel.SetActive(true);
        ItemBox.instance.UseSelectItem();
        this.gameObject.GetComponent<PickupObj>().OnClickObj();
        this.gameObject.SetActive(false);
        
    }
}

