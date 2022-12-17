using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class UseSunoil : MonoBehaviour
{
    public GameObject DeletePanelImage = default;

    // Start is called before the first frame update
   public void OnClick()
    {
        if (ItemBox.instance.checkSelectSlotItem(Item.Type.sunoil) == true)
        {
            //タイムライン再生
            this.GetComponent<PlayableDirector>().Play();
        }
    }

    //タイムライン途中に実行する関数
    public void DoTimeLine()
    {
        
        Destroy(DeletePanelImage.GetComponent<Image>());

    }


    //タイムライン最後に実行する関数
    public void AfterTimeLine()
    {
        PanelSlider.instance.BackPanel();
        ItemBox.instance.UseSelectItem();
    }
}
