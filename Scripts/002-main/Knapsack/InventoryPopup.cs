using UnityEngine;
using System.Collections;

public class InventoryPopup : MonoBehaviour
{

    private UILabel nameLabel;
    private UISprite iconSprite;
    private UILabel desLabel;
    private UILabel batBtnLael;

    private InventoryItem it;
    private InventoryItemUI itui;
    void Awake()
    {
        nameLabel = transform.Find("Bg/NameLabel").GetComponent<UILabel>();
        desLabel = transform.Find("Bg/DesLabel").GetComponent<UILabel>();
        batBtnLael = transform.Find("Bg/BatUseBtn/Label").GetComponent<UILabel>();
        iconSprite = transform.Find("Bg/IconSprite/Sprite").GetComponent<UISprite>();
    }

    public void Show(InventoryItem it,InventoryItemUI itui)
    {
        if (gameObject.active == false)
        {
            //Debug.Log("false");
            gameObject.active = true;
        }


        this.it = it;
        this.itui = itui;

        nameLabel.text = it.Inventory.Name;
        desLabel.text = it.Inventory.Des;
        iconSprite.spriteName = it.Inventory.Icon;

        batBtnLael.text = "批量使用(" + it.Count + ")";
    }

    public void Close()
    {
        gameObject.SetActive(false);
        it = null;
        itui = null;
    }

    public void OnClose()
    {
        transform.parent.SendMessage("DisableSellBtn");
        Close();
    }

    public void OnUse()
    {
        //PlayerInfo._Instance
        itui.ReduceCount(1);
        PlayerInfo._Instance.InventoryUse(it);
        OnClose();
    }

    public void OnBatUse()
    {
        itui.ReduceCount(it.Count);
        PlayerInfo._Instance.InventoryUse(it,it.Count);
        OnClose();
    }
}
