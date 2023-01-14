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
            //�^�C�����C���Đ�
            this.GetComponent<PlayableDirector>().Play();
        }
    }

    //�^�C�����C���Ō�Ɏ��s����֐�
    public void AfterTimeLine()
    {
        ItemBox.instance.UseSelectItem();

        // TapPositionTrue.SetActive(true);
        FlagManager.instance.UseFude = true;
        this.gameObject.SetActive(false);
        

    }
}
