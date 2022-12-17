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
            //�^�C�����C���Đ�
            this.GetComponent<PlayableDirector>().Play();
        }
    }

    //�^�C�����C���r���Ɏ��s����֐�
    public void DoTimeLine()
    {
        
        Destroy(DeletePanelImage.GetComponent<Image>());

    }


    //�^�C�����C���Ō�Ɏ��s����֐�
    public void AfterTimeLine()
    {
        PanelSlider.instance.BackPanel();
        ItemBox.instance.UseSelectItem();
    }
}
