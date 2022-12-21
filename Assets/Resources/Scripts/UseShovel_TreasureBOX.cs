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
            c.a = 0.0f; // 初期値
            blackImage.color = c;


            //暗転処理
            DOTween.ToAlpha(
                () => blackImage.color,
                color => blackImage.color = color,
                1f, // 目標値
                fadeTime // 所要時間
            ).OnComplete(() =>
            {
                //マスク画像表示
                MaskPanel.SetActive(true);
                MaskPanel2.SetActive(true);
                DOTween.ToAlpha(
                    () => blackImage.color,
                    color => blackImage.color = color,
                    0f, // 目標値
                    fadeTime // 所要時間
                ).OnComplete(() =>
                {
                    blackCanvas.SetActive(false);
                    //ここに完了した後の処理を書く
                    
                    //タップさせないようにする
                    
                    TapPosition_true.SetActive(true);
                    TapPosition_false.SetActive(false);
                }

                );
            });



        }
    }

}
