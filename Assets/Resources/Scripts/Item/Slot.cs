using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] Image image = default;
    [SerializeField] GameObject backimage = default;
    public Item item = null;
    [SerializeField] Sprite defaultsprite = default;

    private void Start()
    {
  
        if (item == null)
        {
            item = ItemDataBase.instance.Spawn(Item.Type.default_null);
        }
        image.sprite = item.sprite;
    }

    public void SetImage(Item item)
    {
        this.item = item;
        backimage.SetActive(true);
        image.sprite = item.sprite;
    }

    public void ObjInit()
    {

        image.sprite = defaultsprite;
        item = ItemDataBase.instance.Spawn(Item.Type.default_null);

        HideBackimage();
    }

    public void RemoveItem()
    {

        item = ItemDataBase.instance.Spawn(Item.Type.default_null);

        image.sprite = defaultsprite;
        //HideBackimage();
        backimage.SetActive(false);
    }

    // Slotが空かどうか
    public bool IsEmpty()
    {
        if (this.item.type == Item.Type.default_null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void OnSelect()
    {
        backimage.GetComponent<Image>().color = Color.white;
        Debug.Log("ChangeColor");
    }
    public void HideBackimage()
    {
        backimage.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
    }



    public Item GetItem()
    {
        return item;
    }
}
