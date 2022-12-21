using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UseShovel_TreasureBOX : MonoBehaviour
{

    public GameObject blackPanel = default;
    public GameObject blackCanvas = default;
    public GameObject TapPosition_true = default;
    public GameObject TapPosition_false = default;
    
    public GameObject MaskPanel = default;
    public GameObject MaskPanel2 = default;

    
    [SerializeField] float fadeTime = 1.0f;

    // Start is called before the first frame update
    public void OnClick()
    {


        if (ItemBox.instance.checkSelectSlotItem(Item.Type.shovel) == true)
        {
            blackCanvas.SetActive(true);


            FlagManager.instance.UseShovelTime++;
            if(FlagManager.instance.UseShovelTime == 2)
            {
                ItemBox.instance.UseSelectItem();
            }


            Image blackImage = blackPanel.GetComponent<Image>();
            var c = blackImage.color;
            c.a = 0.0f; // �����l
            blackImage.color = c;


            //�Ó]����
            DOTween.ToAlpha(
                () => blackImage.color,
                color => blackImage.color = color,
                1f, // �ڕW�l
                fadeTime // ���v����
            ).OnComplete(() =>
            {
                //�}�X�N�摜�\��
                MaskPanel.SetActive(true);
                MaskPanel2.SetActive(true);
                DOTween.ToAlpha(
                    () => blackImage.color,
                    color => blackImage.color = color,
                    0f, // �ڕW�l
                    fadeTime // ���v����
                ).OnComplete(() =>
                {
                    blackCanvas.SetActive(false);
                    //�����Ɋ���������̏���������
                    
                    //�^�b�v�����Ȃ��悤�ɂ���
                    
                    TapPosition_true.SetActive(true);
                    TapPosition_false.SetActive(false);
                }

                );
            });



        }
    }

}
