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

            //�^�C�����C���Đ�
            this.GetComponent<PlayableDirector>().Play();

           
        }
    }

    //�^�C�����C���Ō�Ɏ��s����֐�

    public void AfterTimeLine()
    {
        //MaskPanel.SetActive(true);
        ItemBox.instance.UseSelectItem();
        this.gameObject.GetComponent<PickupObj>().OnClickObj();
        this.gameObject.SetActive(false);
        
    }
}

