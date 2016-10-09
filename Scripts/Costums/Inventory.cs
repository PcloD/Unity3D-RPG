using UnityEngine;
using System.Collections;

public enum InventoryType
{
    Equip,
    Drug,
    Box
}

public enum EquipType
{
    Head,
    Cloth,
    Weapon,
    Shoes,
    Necklace,
    Bracelet,
    Ring,
    Wing
}

public class Inventory  {

    private int id;                         //ID
    private string name;                    //名称
    private string icon;
    private InventoryType inventoryType;    //物品类型
    private EquipType equipType;            //装备类型
    //private int level=1;                    //装备等级
    //private int count=1;                    //物品个数
    private int price = 0;                  //价格
    private int stargrade=1;                //星级
    private int quality = 1;                //品质
    private int damage = 0;                 //伤害
    private int addhp = 0;      
    private int power = 0;
    private PlayerInfoType infoType;        //作用域
    private int applyValue;                 //作用值
    private string des;                     //描述

    #region SETGET
    public int ID
    {
        get { return id; }
        set { id = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Icon
    {
        get { return icon; }
        set { icon = value; }
    }

    public InventoryType InventoryTYPE
    {
        get { return inventoryType; }
        set { inventoryType = value; }
    }

    public EquipType EquipTYPE
    {
        get { return equipType; }
        set { equipType = value; }
    }

    //public int Level
    //{
    //    get { return level; }
    //    set { level = value; }
    //}

    //public int Count
    //{
    //    get { return count; }
    //    set { count = value; }
    //}

    public int Price
    {
        get { return price; }
        set { price = value; }
    }

    public int StarGrade
    {
        get { return stargrade; }
        set { stargrade = value; }
    }

    public int Quality
    {
        get { return quality; }
        set { quality = value; }
    }

    public int Damage
    {
        get { return damage; }
        set { damage = value; }
    }

    public int Addhp
    {
        get { return addhp; }
        set { addhp = value; }
    }

    public int Power
    {
        get { return power; }
        set { power = value; }
    }

    public PlayerInfoType InfoType
    {
        get { return infoType; }
        set { infoType = value; }
    }

    public int ApplyValue
    {
        get { return applyValue; }
        set { applyValue = value; }
    }

    public string Des
    {
        get { return des; }
        set { des = value; }
    }
    #endregion
}
