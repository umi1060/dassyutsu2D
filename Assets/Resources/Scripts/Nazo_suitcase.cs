using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Nazo_suitcase : MonoBehaviour
{
    //　現在の入力を保存する配列
    public int[] input = new int[3] { 0, 0, 0 };
    //　正解の配列
    public int[] correct = new int[3];
    //　切り替え画像
    public Image[] images = new Image[4];
    // public GameObject TapPositionTrue = default;
    public GameObject TapPositionFalse = default;

    //　マテリアルを変更するゲームオブジェクト
    [SerializeField] GameObject[] gameobjs = new GameObject[4];
    //　宝箱が開いたマスクパネル
    [SerializeField] GameObject MaskPanel = default;
    //　ロケット取得後のマスクパネル
    [SerializeField] GameObject MaskPanel2 = default;

    public void OnClick(int i)
    {
        if (FlagManager.instance.IsClearSuitCase == false)
        {
            //　マテリアルのインデックス
            var idx = input[i];
            //　数を増やす
            input[i]++;
            if (input[i] >= input.Length)
            {
                input[i] = 0;
            }
            //　ゲームオブジェクトに画像切り替え
            gameobjs[i].GetComponent<Image>().sprite = images[i].sprite;


            CheckCorrect();
        }
    }



    public void CheckCorrect()
    {
        //　正解か判定
        if (input.SequenceEqual(correct) == true)
        {
            // ボタンを反応しないようにする
            for (int i = 0; i < gameobjs.Length; i++)
            {
                gameobjs[i].GetComponent<Button2>().interactable = false;
            }

            //TODO： フラグ変更
            FlagManager.instance.IsClearSuitCase = true;
            //　TapPosition 表示/非表示
            TapPositionFalse.SetActive(false);
            // TapPositionTrue.SetActive(true);

            this.gameObject.SetActive(false);
            //DelayMethodを1.0秒後に呼び出す
            Invoke(nameof(DelayMethod), 1.0f);


        }
    }

    public void DelayMethod()
    {

        MaskPanel.SetActive(true);
        //DelayMethodを1.0秒後に呼び出す
        Invoke(nameof(DelayMethod2), 1.0f);

    }

    public void DelayMethod2()
    {

        //筆を入手
        this.GetComponent<PickupObj>().OnClickObj();
        //筆をとった後の画像に切り替え
        MaskPanel2.SetActive(true);
        this.gameObject.SetActive(false);
    }


}
