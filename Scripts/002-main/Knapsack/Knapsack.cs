using UnityEngine;
using System.Collections;

public class Knapsack : MonoBehaviour {

    public static Knapsack _Instance;

    private EquipPopup equipPopup;
    private InventoryPopup inventoryPopup;

    private UILabel sellPriceLabel;
    private UIButton sellBtn;

    private TweenPosition tween;
    private InventoryItemUI itui;
    void Awake()
    {
        _Instance = this;
        tween = this.GetComponent<TweenPosition>();

        equipPopup = transform.Find("EquipPopup").GetComponent<EquipPopup>();
        inventoryPopup = transform.Find("InventoryPopup").GetComponent<InventoryPopup>();

        sellPriceLabel = transform.Find("Inventory/Sell/PriceLabel").GetComponent<UILabel>();
        sellBtn = transform.Find("Inventory/SellBtn").GetComponent<UIButton>();

        EventDelegate ed = new EventDelegate(this, "OnSellClick");
        sellBtn.onClick.Add(ed);


        DisableSellBtn();
    }

    void DisableSellBtn()
    {
        sellBtn.SetState(UIButtonColor.State.Disabled, true);
        sellBtn.GetComponent<Collider>().enabled = false;
        sellPriceLabel.text = "";
    }

    void EnableSellBtn()
    {
        sellBtn.SetState(UIButtonColor.State.Normal, true);
        sellBtn.GetComponent<Collider>().enabled = true;
    }

    //
    public void OnInventoryClick(object[] o)
    {
        //Debug.Log("OnEquipClick");
        InventoryItem it = o[0] as InventoryItem;
        bool isLeft = (bool)(o[1]);
        //Debug.Log(isLeft);

        InventoryItemUI itui=null;
        KnapsackRoleEquipItem eit = null;
        if(it.Inventory.InventoryTYPE==InventoryType.Equip)
        {
            if(isLeft)
            {
                itui = o[2] as InventoryItemUI;
                
            }else
            {
                eit=o[2] as KnapsackRoleEquipItem;
            }

            equipPopup.Show(it, itui, eit,isLeft);
            inventoryPopup.Close();
        }
        else 
        {
            itui = o[2] as InventoryItemUI;
            inventoryPopup.Show(it, itui);
            equipPopup.Close();
        }

        //可以出售的情况
        if (isLeft == true)
        {
            EnableSellBtn();
            this.itui = o[2] as InventoryItemUI;

            sellPriceLabel.text = (this.itui.it.Inventory.Price*this.itui.it.Count).ToString();
        }
    }

    void OnSellClick()
    {
        int price = int.Parse(sellPriceLabel.text);
        PlayerInfo._Instance.AddCoin(price);
        InventoryManager._Instance.DelInventory(itui.it);
        itui.Clear();
        equipPopup.Close();
        inventoryPopup.Close();

        MessageManager._Instance.ShowMessage("出售成功 共计"+price+"个金币");
        DisableSellBtn();
    }
    
    public void Show()
    {
        tween.PlayForward();
    }

    public void Hide()
    {
        tween.PlayReverse();
    }
}
