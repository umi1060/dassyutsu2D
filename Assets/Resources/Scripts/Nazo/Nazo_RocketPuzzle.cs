using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class Nazo_RocketPuzzle : MonoBehaviour
{
    //入力
    public int[] input = new int[9] { 0, 3, 2,1,0,1,0,3,0 };
    //正解
    public int[] correct = new int[9];

    //public Sprite[] images = new Sprite[4];
    // public GameObject TapPositionTrue = default;
    public GameObject TapPositionFalse = default;

    [SerializeField] GameObject[] gameobjs = new GameObject[9];

    

    private void Start()
    {
        // 初期化
        for(int m=0; m < input.Length; m++)
        {
            SetImage(m);
        }
    }


    public void OnClick(int i)
    {
        if (FlagManager.instance.IsClearSuitCase == false)
        {
            //?@?}?e???A?????C???f?b?N?X
            var idx = input[i];
            //?@??????????
            input[i]++;
            if (input[i] >= 4)
            {
                input[i] = 0;
            }
            //画像セット
            SetImage(i);



        }
    }

    //画像セット
    public void SetImage(int i)
    {
        if (input[i] == 0) gameobjs[i].transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0);
        if (input[i] == 1) gameobjs[i].transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90);
        if (input[i] == 2) gameobjs[i].transform.rotation = Quaternion.Euler(0.0f, 0.0f, 180);
        if (input[i] == 3) gameobjs[i].transform.rotation = Quaternion.Euler(0.0f, 0.0f, 270);
    }

    

    public void CheckCorrect()
    {
        
        if (input.SequenceEqual(correct) == true)
        {
            // 全て押せないようにする
            for (int i = 0; i < gameobjs.Length; i++)
            {
                gameobjs[i].GetComponent<Button2>().interactable = false;
            }

            FlagManager.instance.IsClearRocketPuzzle = true;
            //押せないようにする
            TapPositionFalse.SetActive(false);

            this.GetComponent<PlayableDirector>().Play();

        }
    }

    public void AfterTimeline()
    {
        this.gameObject.SetActive(false);
        // TODO: セーブ！！
    }



}
