using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseRocket : MonoBehaviour
{
    [SerializeField] GameObject MaskPanel_true = default;
    [SerializeField] GameObject NazoPanel = default;

    public void OnClick()
    {
        if (ItemBox.instance.checkSelectSlotItem(Item.Type.rocket) == true)
        {
            FlagManager.instance.UseRocket = true;
            ItemBox.instance.UseSelectItem();
            MaskPanel_true.SetActive(true);

        }else if (FlagManager.instance.UseRocket == true)
        {
            //���Ƀ��P�b�g���g�p���Ă����ꍇ�͓�p�l����\������
            NazoPanel.SetActive(true);
        }
    }
}
