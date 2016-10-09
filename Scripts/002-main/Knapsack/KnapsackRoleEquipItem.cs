using UnityEngine;
using System.Collections;

public class KnapsackRoleEquipItem : MonoBehaviour
{

    private InventoryItem it;

    private UISprite sprite;
    private UISprite Sprite
    {
        get
        {
            if (sprite == null)
            {
                sprite = this.GetComponent<UISprite>();
            }
            return sprite;
        }
    }

    void Awake()
    {
        sprite = GetComponent<UISprite>();
    }

    public void SetId(int id)
    {

        Inventory inventory = null;
        bool isExit = InventoryManager._Instance.InventoryDict.TryGetValue(id, out inventory);
        if (isExit)
        {
            //Debug.Log(inventory.Icon);
            sprite.spriteName = inventory.Icon;

        }

    }

    public void SetInventoryItem(InventoryItem it)
    {       
        if (it == null)
            return;


        this.it = it;

        sprite.spriteName = it.Inventory.Icon;
    }

    public void OnPress(bool isPress)
    {
        //Debug.Log("OnPressed");

        if (it == null)
            return;


        if (isPress)
        {
            //Debug.Log("OnPressed");
            object[] o = new object[3];
            o[0] = it;
            o[1] = false;
            o[2] = this;
            //传入两个参数
            transform.parent.parent.SendMessage("OnInventoryClick", o);
        }
    }

    public void Clear()
    {
        it = null;
        sprite.spriteName = "bg_道具";
    }
}
