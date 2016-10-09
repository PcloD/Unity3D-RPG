using UnityEngine;
using System.Collections;

public class EquipPopup : MonoBehaviour {
    private InventoryItem it;
    private InventoryItemUI itui;
    private KnapsackRoleEquipItem eitem;

    private UISprite iconSprite;
    private UILabel nameLabel;
    private UILabel qualityLabel;
    private UILabel damageLabel;
    private UILabel hpLabel;
    private UILabel levlLabel;
    private UILabel powerLabel;
    private UILabel desLabel;
    private UILabel equipBtnLabel;

    private bool isLeft = true;
    void Awake()
    {
        iconSprite = transform.Find("Bg/IconSprite/Sprite").GetComponent<UISprite>();

        nameLabel = transform.Find("Bg/NameLabel").GetComponent<UILabel>();
        qualityLabel = transform.Find("Bg/QualityLabel/Label").GetComponent<UILabel>();
        damageLabel = transform.Find("Bg/DamageLabel/Label").GetComponent<UILabel>();
        hpLabel = transform.Find("Bg/HpLabel/Label").GetComponent<UILabel>();
        levlLabel = transform.Find("Bg/LevelLabel/Label").GetComponent<UILabel>();
        powerLabel = transform.Find("Bg/PowerLabel/Label").GetComponent<UILabel>();
        desLabel = transform.Find("Bg/DesLabel").GetComponent<UILabel>();
        equipBtnLabel = transform.Find("Bg/EquipBtn/Label").GetComponent<UILabel>();
    }

    public void Show(InventoryItem it, InventoryItemUI itui, KnapsackRoleEquipItem eitem,bool isleft = true)
    {
        if (it == null)
            return;


        if(gameObject.active==false)
        {
            //Debug.Log("false");
            gameObject.active = true;
        }


        this.it = it;
        this.itui = itui;
        this.isLeft = isleft;
        this.eitem = eitem;
        Vector3 pos =transform.localPosition;

        //Debug.Log(isleft);
        
        if (isleft)
        {

            //transform.localPosition = new Vector3(-Mathf.Abs(pos.x), pos.y, pos.z);
            transform.localPosition = new Vector3(0, pos.y, pos.z);
            equipBtnLabel.text = "装备";
        }else{
            //Debug.Log(-Mathf.Abs(pos.x));
            transform.localPosition = new Vector3(320, pos.y, pos.z);
            equipBtnLabel.text = "卸下";
        }
        
        iconSprite.spriteName = this.it.Inventory.Icon;
        nameLabel.text = this.it.Inventory.Name;
        qualityLabel.text = this.it.Inventory.Quality.ToString();
        damageLabel.text = this.it.Inventory.Damage.ToString();
        hpLabel.text = this.it.Inventory.ApplyValue.ToString();
        levlLabel.text = this.it.Level.ToString();
        powerLabel.text = this.it.Inventory.Power.ToString();
        desLabel.text = this.it.Inventory.Des;

       
            
    }

    public void Close()
    {
        gameObject.SetActive(false);
        it = null;
        itui = null;
        eitem = null;
    }

    public void OnClose()
    {
        transform.parent.SendMessage("DisableSellBtn");

        Close();
    }

    public void OnEquip()
    {

        int startPower = PlayerInfo._Instance.GetOverAllPower();

        if(it!=null&&isLeft)//穿上
        {
            PlayerInfo._Instance.DressOn(it);
            //物品栏清空
            itui.Clear();
        }
        else
        {
            //print("卸下");
                        
            PlayerInfo._Instance.DressOff(it);
            //装备栏清空
            eitem.Clear();
        }
            

        OnClose();

        int endPower = PlayerInfo._Instance.GetOverAllPower();
        PowerShow._Instance.ShowPowerChanged(startPower, endPower);

        transform.parent.SendMessage("DisableSellBtn");
        KnapsackInventory._Instance.UpdateLabel();
    }

    public void OnUpgrade()
    {
        //所需要的金币
        int coinNeed = (it.Level + 1) * it.Inventory.Price;
        bool isSuccess=PlayerInfo._Instance.GetCoin(coinNeed);
        if (isSuccess)
        {
            
            //金币数足够升级
            it.Level += 1;
            levlLabel.text = it.Level.ToString();

            
        }
        else
        {
            //金币不足,给出提示
            MessageManager._Instance.ShowMessage("金币不足");
        }
    }
}
