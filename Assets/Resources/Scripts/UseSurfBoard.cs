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
            if (FlagManager.instance.UseFude == true)
            {
                //�^�C�����C���Đ�
                this.GetComponent<PlayableDirector>().Play();
            }          
        }
    }

    //�^�C�����C���Ō�Ɏ��s����֐�
    public void AfterTimeLine()
    {
        ItemBox.instance.UseSelectItem();

        // TapPositionTrue.SetActive(true);
        FlagManager.instance.UseSurfBoard = true;
        this.gameObject.SetActive(false);
    }

    public void DoTimeLine()
    {
        PanelSlider.instance.BackPanel();
    }
}
