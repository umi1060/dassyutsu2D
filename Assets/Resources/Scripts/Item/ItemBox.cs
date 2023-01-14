using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class ItemBox : MonoBehaviour
{
    public static ItemBox instance;

    private void Awake()
    {

        instance = this;
    }



    // アイテムボックスが全てのSlotを把握
    [SerializeField] Slot[] slots = default;

    [SerializeField] GameObject zoomPanel = default;
    [SerializeField] GameObject zoomItemImage = default;
    [SerializeField] GameObject FirstCanvasBackImage = default;
    [SerializeField] GameObject CanvasBackImage = default;
    [SerializeField] GameObject zoomItemBackgroundPanel = default;
    [SerializeField] float zoompanelFedeinTime = 0.1f;
    [SerializeField] float zoompanelFedeOutTime = 0.5f;
    int PickSlotNum = default;
    //[SerializeField] GameObject zoomItemText = default;

    // 選択したアイテム
    // public Item selectItem = null;
    public Slot selectSlot = null;

    private void Start()
    { 

    }


    public void ObjInit()
    {
        selectSlot = null;
        for (int i = 0; i < slots.Length; i++)
        {
            Slot slot = slots[i];
            slot.ObjInit();


        }
    }

    // クリックしたらアイテムを受け取る
    public void SetItem(Item item)
    {
        // 左づめで入れる
        for (int i = 0; i < slots.Length; i++)
        {
            Slot slot = slots[i];
            if (slot.IsEmpty())
            {
                slot.SetImage(item);
                PickSlotNum = i;
                break;
            }

        }

    }

    public void activeZoomPanel(Item item)
    {
        zoomPanel.SetActive(true);
        zoomItemImage.GetComponent<Image>().sprite = item.sprite;
        //zoomItemText.GetComponent<TextMeshProUGUI>().text = item.text;
    }

    public void FadeInZoomPanel(Item item)
    {
        zoomPanel.SetActive(true);
        FirstCanvasBackImage.SetActive(true);
        FirstCanvasBackImage.GetComponent<Button>().interactable = false;
        zoomItemImage.GetComponent<Image>().sprite = item.sprite;
        zoomItemBackgroundPanel.GetComponent<RectTransform>().localScale = Vector3.zero;
        //1秒でスケール（1,1,1）にスケーリング
        zoomItemBackgroundPanel.GetComponent<RectTransform>().DOScale(
            Vector3.one,  //終了時点のScale
            zoompanelFedeinTime       //時間
            ).OnComplete(() =>
            {
                //終わったらボタンを押せるようにする
                FirstCanvasBackImage.GetComponent<Button>().interactable = true; ;
            });
    }

    public void FadeOutFirstZoomPanel()
    {
        FirstCanvasBackImage.SetActive(false);
        zoomItemBackgroundPanel.GetComponent<RectTransform>().localScale = Vector3.one;

        //背景のグレーを透明化
        CanvasBackImage.GetComponent<Image>().color = new Color32(0, 0, 0, 0);
        //1秒でスケール（1,1,1）にスケーリング
        zoomItemBackgroundPanel.GetComponent<RectTransform>().DOScale(
            Vector3.zero,  //終了時点のScale
            zoompanelFedeOutTime       //時間
            ).OnComplete(() =>
            {
                //終わったら背景をもどして非表示
                zoomItemBackgroundPanel.GetComponent<RectTransform>().localScale = Vector3.one;
                CanvasBackImage.GetComponent<Image>().color = new Color32(99, 99, 99, 101);
                
            });
        //並行して、スロットに移動
        zoomItemBackgroundPanel.GetComponent<RectTransform>().DOMove(
            slots[PickSlotNum].gameObject.GetComponent<RectTransform>().position,
            zoompanelFedeOutTime　　　　　　//時間
            ).OnComplete(() =>
            {
                //終わったら位置を戻す
                zoomItemBackgroundPanel.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
                zoomPanel.SetActive(false);
            });
    }

    // アイテム選択したら色が変わる
    public void SlotOnClick(int position)
    {
        
        // もし選択済のスロットがクリックされたら、ズームパネル表示
        if (slots[position] == selectSlot)
        {
            activeZoomPanel(selectSlot.GetItem());
        }
        // アイテムが空じゃなかったら実行
        if (slots[position].IsEmpty() == false)
        {
            
            // 一度全てのスロットの枠を非表示
            for (int i = 0; i < slots.Length; i++)
            {
                Slot slot = slots[i];
                slot.HideBackimage();
            }
            // 枠の表示
            slots[position].OnSelect();
            // 選択アイテムとして取得する
            selectSlot = slots[position];
        }




    }

    // アイテムの使用
    public void UseSelectItem()
    {
        if (selectSlot == null) return;
        selectSlot.RemoveItem();
        selectSlot = null;
        //度全てのスロットの枠を非表示
        for (int i = 0; i < slots.Length; i++)
        {
            Slot slot = slots[i];
            slot.HideBackimage();
        }

    }

    // スロットに特定のアイテムを持っているかcheck
    public bool IsHaveItem(Item.Type itemType)
    {
        
        // 左づめで入れる
        for (int i = 0; i < slots.Length; i++)
        {
            Slot slot = slots[i];
            if (slot.item.type == itemType)
            {
                return true;

            }

        }
        return false;

    }

    //selectslotのアイテム✓
    public bool checkSelectSlotItem(Item.Type itemType)
    {
        if (selectSlot == null) return false;
        if (selectSlot.item.type == itemType) return true;
        return false;
    }

    // スロットに特定のアイテムを持っているかcheckしてから、特定アイテムだったら削除
    public void RemoveItem(Item.Type itemType)
    {
        // 左づめで入れる
        for (int i = 0; i < slots.Length; i++)
        {
            Slot slot = slots[i];
            if (slot.item.type == itemType)
            {
                slot.RemoveItem();
                selectSlot = null;

            }

        }


    }

}
