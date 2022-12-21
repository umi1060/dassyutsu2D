using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TreasureBoxNazo : MonoBehaviour
{
    //　現在の入力を保存する配列
    public int[] inputColor = new int[4] { 0, 0, 0, 0 };
    //　正解の配列
    public int[] correct = new int[4];
    //　色の数　白、オレンジ、水色、ピンク
    [SerializeField] int ColorType = 4;
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
        if (FlagManager.instance.IsClearTreasureBox == false)
        {
            //　マテリアルのインデックス
            var idx = inputColor[i];
            //　数を増やす
            inputColor[i]++;
            if (inputColor[i] >= ColorType)
            {
                inputColor[i] = 0;
            }
            //　ゲームオブジェクトにカラー反映
            if (inputColor[i] == 0) gameobjs[i].GetComponent<Image>().color = Color.white;
            if (inputColor[i] == 1) gameobjs[i].GetComponent<Image>().color = Color.red;
            if (inputColor[i] == 2) gameobjs[i].GetComponent<Image>().color = Color.blue;
            if (inputColor[i] == 3) gameobjs[i].GetComponent<Image>().color = Color.green;


            CheckCorrect();
        }
    }



    public void CheckCorrect()
    {
        //　正解か判定
        if (inputColor.SequenceEqual(correct) == true)
        {
            // ボタンを反応しないようにする
            for(int i = 0; i < gameobjs.Length; i++)
            {
                gameobjs[i].GetComponent<Button2>().interactable = false;
            }

            //TODO： フラグ変更
            FlagManager.instance.IsClearTreasureBox = true;
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

        //ロケット入手
        this.GetComponent<PickupObj>().OnClickObj();
        //ロケットをとった後の画像に切り替え
        MaskPanel2.SetActive(true);
        this.gameObject.SetActive(false);
    }


}
