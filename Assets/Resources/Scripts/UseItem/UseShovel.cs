using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


public class UseShovel : MonoBehaviour
{
   // [SerializeField] GameObject MaskPanel = default;
    [SerializeField] GameObject TapPositionTrue = default;

    // Start is called before the first frame update
    public void OnClick()
    {
        if(ItemBox.instance.checkSelectSlotItem(Item.Type.shovel) == true)
        {
            //マスク画像表示
           // MaskPanel.SetActive(true);

            //タイムライン再生
            this.GetComponent<PlayableDirector>().Play();

           
        }
    }

    //タイムライン最後に実行する関数

    public void AfterTimeLine()
    {
        FlagManager.instance.UseShovelTime++;
        if (FlagManager.instance.UseShovelTime == 2)
        {
            ItemBox.instance.UseSelectItem();
        }

        // this.gameObject.GetComponent<PickupObj>().OnClickObj();
        TapPositionTrue.SetActive(true);
        this.gameObject.SetActive(false);
        
    }
}

