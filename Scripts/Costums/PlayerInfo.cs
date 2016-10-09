using UnityEngine;
using System.Collections;


public enum PlayerInfoType
{
    Name,
    Head,
    Level,
    Exp,
    Coin,
    Diamond,
    Energy,
    Toughen,
    Power,
    Hp,
    Damage,
    Equip,
    All
}

public enum PlayerType
{
    Warrior,
    FemaleAssassin
}

public class PlayerInfo : MonoBehaviour
{
    public static PlayerInfo _Instance;

    [HideInInspector]
    public float timer_energy = 0;
    [HideInInspector]
    public float timer_toughen = 0;

    #region unity event
    void Awake()
    {
        _Instance = this;
    }

    void Start()
    {
        Init();
    }

    void Update()
    {

        //如果体力没有满,则需要回复体力
        if (this.Energy < MAXEnergy)
        {
            timer_energy += Time.deltaTime;
            //Debug.Log(timer_energy);

            OnPlayerInfoChangedEvent(PlayerInfoType.Energy);
            //Debug.Log(timer_energy);
            if (timer_energy > GameDefine.TIMEREENERGY)
            {
                timer_energy = 0;
                this.Energy += 1;
                OnPlayerInfoChangedEvent(PlayerInfoType.Energy);


            }

        }
        else
        {

            timer_energy = 0;
        }

        if (this.Toughen < MAXToughen)
        {
            timer_toughen += Time.deltaTime;
            OnPlayerInfoChangedEvent(PlayerInfoType.Toughen);
            if (timer_toughen > GameDefine.TIMERETOUGHEN)
            {
                timer_toughen = 0;
                this.Toughen += 1;
                OnPlayerInfoChangedEvent(PlayerInfoType.Toughen);


            }

        }
        else
        {
            timer_toughen = 0;
        }
    }
    #endregion

    #region property

    private string _name;
    private string _head;
    private int _level = 1;
    private int _power = 1;
    private int _exp = 0;
    private int _diamond = 0;
    private int _coin = 0;
    private int _energy;
    private int _toughen;
    private int MAXEnergy = 100;
    private int MAXToughen = 50;
    private int _hp;
    private int _damage;
    private PlayerType playerType;

    private InventoryItem _headItem;
    private InventoryItem _clothItem;
    private InventoryItem _weaponItem;
    private InventoryItem _shoesItem;
    private InventoryItem _necklaceItem;
    private InventoryItem _braceletItem;
    private InventoryItem _ringItem;
    private InventoryItem _wingItem;
    #endregion


    #region get set methd
    public string Name
    {
        get
        {
            return _name;
        }

        set
        {
            _name = value;
            this.OnPlayerInfoChangedEvent(PlayerInfoType.Name);
        }
    }

    public string Head
    {
        get
        {
            return _head;
        }


        set
        {
            _head = value;
        }

    }

    public int Level
    {
        get
        {
            return _level;
        }


        set
        {
            _level = value;
        }

    }

    public int Power
    {
        get
        {
            return _power;
        }


        set
        {
            _power = value;
        }

    }

    public int Exp
    {
        get
        {
            return _exp;
        }


        set
        {
            _exp = value;
        }

    }

    public int Diamond
    {
        get
        {
            return _diamond;
        }


        set
        {
            _diamond = value;
        }

    }

    public int Coin
    {
        get
        {
            return _coin;
        }


        set
        {
            _coin = value;
        }

    }

    public int Energy
    {
        get
        {
            return _energy;
        }


        set
        {
            _energy = value;
        }

    }

    public int Toughen
    {
        get
        {
            return _toughen;
        }


        set
        {
            _toughen = value;
        }

    }

    public int MAXENERGY
    {
        get
        {
            return MAXEnergy;
        }


        set
        {
            MAXEnergy = value;
        }

    }

    public int MAXTOUGHEN
    {
        get
        {
            return MAXToughen;
        }


        set
        {
            MAXToughen = value;
        }

    }

    public int Hp
    {
        get { return _hp; }
        set { _hp = value; }
    }

    public int Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }

    public InventoryItem HeadIitem
    {
        get { return _headItem; }
        set { _headItem = value; }
    }

    public InventoryItem ClothItem
    {
        get { return _clothItem; }
        set { _clothItem = value; }
    }

    public InventoryItem WeaponItem
    {
        get { return _weaponItem; }
        set { _weaponItem = value; }
    }

    public InventoryItem ShoesItem
    {
        get { return _shoesItem; }
        set { _shoesItem = value; }
    }

    public InventoryItem NecklaceItem
    {
        get { return _necklaceItem; }
        set { _necklaceItem = value; }
    }

    public InventoryItem BraceletItem
    {
        get { return _braceletItem; }
        set { _braceletItem = value; }
    }

    public InventoryItem RingItem
    {
        get { return _ringItem; }
        set { _ringItem = value; }
    }

    public InventoryItem WingItem
    {
        get { return _wingItem; }
        set { _wingItem = value; }
    }

    public PlayerType PlayerType
    {
        get { return playerType; }
        set { playerType = value; }
    }

    #endregion

    void Init()
    {
        this.Coin = 1000;
        this.Diamond = 500;
        this.Energy = 13;
        this.Toughen = 27;
        this.Exp = 1;
        this.Head = "头像底板女性";
        this.Level = 1;
        this.Name = "王荣荣1";




        //随机穿戴装备
        //this.BraceletId = 1001;
        //this.WingId = 1002;
        //this.RingId = 1003;
        //this.ClothId = 1004;
        //this.HeadId = 1005;
        //this.WeaponId = 1006;
        //this.NecklaceId = 1007;
        //this.ShoesId = 1008;

        InitHpAndPower();

        OnPlayerInfoChangedEvent(PlayerInfoType.All);
    }


    public delegate void OnPlayerInfoChanged(PlayerInfoType infoType);
    public event OnPlayerInfoChanged OnPlayerInfoChangedEvent;

    void InitHpAndPower()
    {
        this.Hp = this.Level * 100;
        this.Damage = this.Level * 20;
        this.Power = this.Hp + this.Damage;

    }

    //穿上一个装备
    public void DressOn(InventoryItem it)
    {
        //
        it.IsDress = true;
        //首先检测有没有穿上相同部位的装备
        bool hasDressed = false;
        InventoryItem ItDressed = null;
        switch (it.Inventory.EquipTYPE)
        {
            case EquipType.Bracelet:
                if (BraceletItem != null)
                {
                    hasDressed = true;
                    ItDressed = BraceletItem;
                }
                BraceletItem = it;
                break;

            case EquipType.Cloth:
                if (ClothItem != null)
                {
                    hasDressed = true;
                    ItDressed = ClothItem;
                }
                ClothItem = it;
                break;

            case EquipType.Head:
                if (HeadIitem != null)
                {
                    hasDressed = true;
                    ItDressed = HeadIitem;
                }
                HeadIitem = it;
                break;

            case EquipType.Necklace:
                if (NecklaceItem != null)
                {
                    hasDressed = true;
                    ItDressed = NecklaceItem;
                }
                NecklaceItem = it;
                break;

            case EquipType.Ring:
                if (RingItem != null)
                {
                    hasDressed = true;
                    ItDressed = RingItem;
                }
                RingItem = it;
                break;

            case EquipType.Shoes:
                if (ShoesItem != null)
                {
                    hasDressed = true;
                    ItDressed = ShoesItem;
                }
                ShoesItem = it;
                break;

            case EquipType.Weapon:
                if (WeaponItem != null)
                {
                    hasDressed = true;
                    ItDressed = WeaponItem;
                }
                WeaponItem = it;
                break;

            case EquipType.Wing:
                if (WingItem != null)
                {
                    hasDressed = true;
                    ItDressed = WingItem;
                }
                WingItem = it;
                break;
        }
        //有       把之前的脱下放入到背包
        if (hasDressed)
        {
            ItDressed.IsDress = false;
            
            //放入装备
            //TODO
            KnapsackInventory._Instance.AddInventoryItem(ItDressed);

            //穿上装备
        }

        //没有     直接穿上


        OnPlayerInfoChangedEvent(PlayerInfoType.Equip);
    }

    //卸下装备
    public void DressOff(InventoryItem it)
    {
        //从身上脱掉
        switch (it.Inventory.EquipTYPE)
        {
            case EquipType.Bracelet:
                if (BraceletItem != null)
                {
                    BraceletItem = null;
                }

                break;

            case EquipType.Cloth:
                if (ClothItem != null)
                {
                    ClothItem = null;
                }

                break;

            case EquipType.Head:
                if (HeadIitem != null)
                {
                    HeadIitem = null;
                }

                break;

            case EquipType.Necklace:
                if (NecklaceItem != null)
                {
                    NecklaceItem = null;
                }

                break;

            case EquipType.Ring:
                if (RingItem != null)
                {
                    RingItem = null;
                }

                break;

            case EquipType.Shoes:
                if (ShoesItem != null)
                {
                    ShoesItem = null;
                }

                break;

            case EquipType.Weapon:
                if (WeaponItem != null)
                {
                    WeaponItem = null;
                }

                break;

            case EquipType.Wing:
                if (WingItem != null)
                {
                    WingItem = null;
                }

                break;
        }

        it.IsDress = false;
        KnapsackInventory._Instance.AddInventoryItem(it);

        OnPlayerInfoChangedEvent(PlayerInfoType.Equip);
    }

    public void InventoryUse(InventoryItem it, int count = 1)
    {
        //使用效果
        //TODO
        Debug.Log("使用效果");

        //处理物品使用后是否还存在
        it.Count -= count;
        if (it.Count <= 0)
        {
            InventoryManager._Instance.DelInventory(it);
        }

    }


    void PutOnEquip(int id)
    {
        if (id == 0) return;

        Inventory inventory = null;
        bool isExit = InventoryManager._Instance.InventoryDict.TryGetValue(id, out inventory);
        if (isExit && inventory.InventoryTYPE == InventoryType.Equip)
        {
            this.Hp += inventory.Addhp;
            this.Damage += inventory.Damage;
            this.Power += inventory.Power;


        }

    }

    void PutOffEquip(int id)
    {
        if (id == 0) return;

        Inventory inventory = null;
        InventoryManager._Instance.InventoryDict.TryGetValue(id, out inventory);
        if (inventory.InventoryTYPE == InventoryType.Equip)
        {
            this.Hp -= inventory.Addhp;
            this.Damage -= inventory.Damage;
            this.Power -= inventory.Power;
        }
    }

    //取得需要个数的金币数
    public bool GetCoin(int count)
    {
        if (Coin >= count)
        {
            //足够
            Coin -= count;

            OnPlayerInfoChangedEvent(PlayerInfoType.Coin);
            return true;
        }


        return false;
    }

    public void AddCoin(int count)
    {
        Coin += count;
        OnPlayerInfoChangedEvent(PlayerInfoType.Coin);
    }

    //获取综合战斗力
    public int GetOverAllPower()
    {
        float power = this.Power;

        power += SingleEquipPower(HeadIitem);
        power += SingleEquipPower(ClothItem);
        power += SingleEquipPower(WeaponItem);
        power += SingleEquipPower(ShoesItem);
        power += SingleEquipPower(WingItem);
        power += SingleEquipPower(RingItem);
        power += SingleEquipPower(NecklaceItem);
        power += SingleEquipPower(BraceletItem);


        return (int)power;
    }

    float SingleEquipPower(InventoryItem it)
    {
        if (it != null)
        {
            return it.Inventory.Power * (1 + (it.Level - 1) / 10f);
        }
        return 0f;
    }

}
