using UnityEngine;
using System.Collections;

public class KnapsackRole : MonoBehaviour {

    private KnapsackRoleEquipItem helmSprite;
    private KnapsackRoleEquipItem clothSprite;
    private KnapsackRoleEquipItem weaponSprite;
    private KnapsackRoleEquipItem shoesSprite;
    private KnapsackRoleEquipItem necklaceSprite;
    private KnapsackRoleEquipItem braceletSprite;
    private KnapsackRoleEquipItem ringSprite;
    private KnapsackRoleEquipItem wingSprite;

    private UILabel hpLabel;
    private UILabel damageLabel;
    private UILabel expLabel;

    private UISlider expSlider;

    void Awake()
    {
        helmSprite = transform.Find("HeadSprite").GetComponent<KnapsackRoleEquipItem>();
        clothSprite = transform.Find("ClothSprite").GetComponent<KnapsackRoleEquipItem>();
        weaponSprite = transform.Find("WeaponSprite").GetComponent<KnapsackRoleEquipItem>();
        shoesSprite = transform.Find("ShoesSprite").GetComponent<KnapsackRoleEquipItem>();
        necklaceSprite = transform.Find("NecklaceSprite").GetComponent<KnapsackRoleEquipItem>();
        braceletSprite = transform.Find("BraceletSprite").GetComponent<KnapsackRoleEquipItem>();
        ringSprite = transform.Find("RingSprite").GetComponent<KnapsackRoleEquipItem>();
        wingSprite = transform.Find("WingSprite").GetComponent<KnapsackRoleEquipItem>();

        expSlider = transform.Find("ExpSlider").GetComponent<UISlider>();

        hpLabel = transform.Find("HpLabel/Label").GetComponent<UILabel>();
        damageLabel = transform.Find("DamageLabel/Label").GetComponent<UILabel>();
        expLabel = expSlider.transform.Find("Label").GetComponent<UILabel>();

        
    }

    void Start()
    {
        PlayerInfo._Instance.OnPlayerInfoChangedEvent += OnPlayerInfoChanged;
    }

    void OnDestory()
    {
        PlayerInfo._Instance.OnPlayerInfoChangedEvent -= OnPlayerInfoChanged;
    }

    void OnPlayerInfoChanged(PlayerInfoType infotype)
    {
        switch(infotype)
        {
            case PlayerInfoType.All:
                UpdateShowPlayerAll();
                break;
            case PlayerInfoType.Exp:
                UpdateShowPlayerExp();
                break;
            case PlayerInfoType.Equip:
                UpdateShowPlayerEquip();
                break;
            case PlayerInfoType.Damage:
                UpdateShowPlayerDamage();
                break;
            case PlayerInfoType.Hp:
                UpdateShowPlayerHp();
                break;
        }
    }

    private void UpdateShowPlayerAll()
    {
        UpdateShowPlayerExp();
        UpdateShowPlayerEquip();
        UpdateShowPlayerDamage();
        UpdateShowPlayerHp();
    }

    private void UpdateShowPlayerExp()
    {
        int requirdExp = GameController.GetRequireExpByLevel(PlayerInfo._Instance.Level + 1);
        expLabel.text = PlayerInfo._Instance.Exp + "/" + requirdExp;
        expSlider.value = (float)PlayerInfo._Instance.Exp / (float)requirdExp;
    }

    private void UpdateShowPlayerEquip()
    {

        helmSprite.SetInventoryItem(PlayerInfo._Instance.HeadIitem);
        clothSprite.SetInventoryItem(PlayerInfo._Instance.ClothItem);
        weaponSprite.SetInventoryItem(PlayerInfo._Instance.WeaponItem);
        shoesSprite.SetInventoryItem(PlayerInfo._Instance.ShoesItem);
        necklaceSprite.SetInventoryItem(PlayerInfo._Instance.NecklaceItem);
        braceletSprite.SetInventoryItem(PlayerInfo._Instance.BraceletItem);
        ringSprite.SetInventoryItem(PlayerInfo._Instance.RingItem);
        wingSprite.SetInventoryItem(PlayerInfo._Instance.WingItem);
    }

    private void UpdateShowPlayerDamage()
    {
        damageLabel.text = PlayerInfo._Instance.Damage.ToString();
    }

    private void UpdateShowPlayerHp()
    {
        hpLabel.text = PlayerInfo._Instance.Hp.ToString();
    }
}
