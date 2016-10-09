using UnityEngine;
using System.Collections;

public class InventoryItemUI : MonoBehaviour
{

    private UISprite sprite;
    private UILabel label;
    public InventoryItem it;

    private UISprite Sprite
    {
        get
        {
            if (sprite == null)
            {

                sprite = transform.Find("Sprite").GetComponent<UISprite>();
            }
            return sprite;
        }
    }

    private UILabel Label
    {
        get
        {
            if (label == null)
            {

                label = transform.Find("Label").GetComponent<UILabel>();
            }
            return label;
        }
    }

    public void SetInventoryItem(InventoryItem it)
    {
       

        this.it = it;
        Sprite.spriteName = it.Inventory.Icon;

       
        if (it.Count > 1)
            Label.text = it.Count.ToString();
        else
            Label.text = "";
    }

    public void Clear()
    {
        this.it = null;
        Label.text = "";
        Sprite.spriteName = "bg_道具";
        
    }

    public void OnClick()
    {
        //if (isPress&&it!=null&&it.Inventory.InventoryTYPE==InventoryType.Equip)
        //if (isPress&&it!=null)
        {
            
            object[] o = new object[3];
            o[0] = this.it;
            o[1] = true;//是否在左边
            o[2] = this;//当期InventoryItemUI
            //传入两个参数
            if (o[0]!=null)
                transform.parent.parent.parent.SendMessage("OnInventoryClick", o);
        }
    }

    public void ReduceCount(int count)
    {
        if ((it.Count-count)<=0)
        {
            Clear();
        }else if ((it.Count-count)==1)
        {
            label.text = "";
        }
        else
        {
            label.text = (it.Count - count).ToString();
        }
    }
}
