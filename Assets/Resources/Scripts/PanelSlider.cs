using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PanelSlider : MonoBehaviour
{
    #region 定義
    //回転スライド
    [SerializeField] float slideTime = default;
    public GameObject[] Panels1;
    public int currentIndex = 0;

    //ズーム
    int index = 0; // ズーム用インデックス
    public GameObject[] zoomPanels = default;
    [SerializeField] private EventSystem eventSystem= default;
    [SerializeField] GameObject LeftButton = default;
    [SerializeField] GameObject RightButton = default;
    [SerializeField] GameObject BackButton = default;

    public static PanelSlider instance;

    private void Awake()
    {

        instance = this;
    }
    #endregion

    #region 左右のボタン
    public void TurnRight()
    {
        FadeOutToLeft(Panels1[currentIndex]);
        currentIndex++;
        if (currentIndex >= 4)
        {
            currentIndex = 0;
        }
        FadeInToLeft(Panels1[currentIndex]);   
    }

    public void TurnLeft()
    {
        FadeOutToRight(Panels1[currentIndex]);
        currentIndex--;
        if (currentIndex < 0)
        {
            currentIndex = 3;
        }
        FadeInToRight(Panels1[currentIndex]);
    }
    #endregion

    #region スライドアニメーション
    public void FadeOutToLeft(GameObject gameObject)
    {       
        gameObject.GetComponent<RectTransform>().transform.DOLocalMoveX(-800, slideTime).OnComplete(() =>
        {
            //スライド終わったら
            gameObject.SetActive(false);
        }); 
    }

    public void FadeOutToRight(GameObject gameObject)
    {
        gameObject.GetComponent<RectTransform>().transform.DOLocalMoveX(800, slideTime).OnComplete(() =>
        {
            //スライド終わったら
            gameObject.SetActive(false);
        });
    }

    public void FadeInToLeft(GameObject gameObject)
    {
        gameObject.SetActive(true);
        gameObject.GetComponent<RectTransform>().transform.localPosition = new Vector3(800,0,0);
        gameObject.GetComponent<RectTransform>().transform.DOLocalMoveX(0, slideTime);
    }

    public void FadeInToRight(GameObject gameObject)
    {
        gameObject.SetActive(true);
        gameObject.GetComponent<RectTransform>().transform.localPosition = new Vector3(-800,0,0);
        gameObject.GetComponent<RectTransform>().transform.DOLocalMoveX(0, slideTime);
    }
    #endregion

    #region 多段階ズーム
    public void zoomPanel(GameObject ZoomGameObj)
    {
        GameObject CurrentPanel 
            = eventSystem.currentSelectedGameObject.transform.parent.gameObject.transform.parent.gameObject;
        //現在のパネルを保存
        zoomPanels[index] = CurrentPanel;
        //CurrentPanel.SetActive(false);
        index++;
        zoomPanels[index] = ZoomGameObj;
        ZoomGameObj.SetActive(true);
        LeftButton.SetActive(false);
        RightButton.SetActive(false);
        BackButton.SetActive(true);

    }

    public void BackPanel()
    {
        zoomPanels[index].SetActive(false);
        index--;
        zoomPanels[index].SetActive(true);
        if(index == 0)
        {
            LeftButton.SetActive(true);
            RightButton.SetActive(true);
            BackButton.SetActive(false);
        }
    }
    #endregion

    //パネル画像切り替えフェード
    public void ChangePanelImage(Sprite sprite)
    {

    }
    

}
