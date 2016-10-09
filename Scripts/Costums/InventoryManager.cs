using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour {

    public static InventoryManager _Instance;

    public TextAsset _inventoryList;
    //所有物品信息
    public Dictionary<int, Inventory> InventoryDict = new Dictionary<int, Inventory>();
    //拥有的物品信息
    //public Dictionary<int, InventoryItem> InventoryItemDict = new Dictionary<int, InventoryItem>();
    public List<InventoryItem> InventoryItemList = new List<InventoryItem>();

    public delegate void OnInventoryChange();
    public event OnInventoryChange OnInventoryChangeEvent; 

    void Awake()
    {
        _Instance = this;

        ReadInventoryInfo();

        

        //Debug.Log(InventoryDict.Count);
    }

    void Start()
    {
        ReadInventoryItemInfo();
        
        //for(int i=0;i<InventoryItemList.Count;i++)
        //{
        //    print(InventoryItemList[i].Inventory.Icon);
        //}
    }

    void ReadInventoryItemInfo()
    {
        //TODO 链接服务器 取得拥有的物品信息

        InventoryItemList.Clear();
        //随机生成拥有的物品
        for(int i=0;i<20;i++)
        {

            //随机ID
            int id = Random.Range(1001, 1020);

            Inventory ii = null;
            //从道具词典里取出道具
            InventoryDict.TryGetValue(id, out ii);

            //每个装备占用一格
            if (ii.InventoryTYPE == InventoryType.Equip)
            {
                //王背包中添加数据
                InventoryItem it = new InventoryItem();
                it.Inventory = ii;
                it.Level = Random.Range(1, 10);
                it.Count = 1;
                //InventoryItemDict.Add(id, it);
                InventoryItemList.Add(it);
            }
            else
            {
                InventoryItem it = null;
                //先判断背包里面是否已经存在
                //bool isExit = InventoryItemDict.TryGetValue(id, out it);
                bool isExit = false;

                for (int j = 0; j < InventoryItemList.Count;j++ )
                {
                    if (id == InventoryItemList[j].Inventory.ID)
                    {
                        isExit = true;
                        it = InventoryItemList[j];
                        break;
                    }
                }


                if(isExit)
                {
                    
                    it.Count++;
                }
                else
                {
                    it = new InventoryItem();
                    it.Inventory = ii;
                    it.Count = 1;
                    InventoryItemList.Add(it);
                }
            }

            OnInventoryChangeEvent();

        }
    }

    void ReadInventoryInfo()
    {
        string str=_inventoryList.ToString();
        string[] items=str.Split('\n');

        for(int i=0;i<items.Length;i++)
        {
            string[] itemInfos = items[i].Split('|');

            
            Inventory item = new Inventory();

            item.ID = int.Parse(itemInfos[0]);
            item.Name = itemInfos[1];
            item.Icon = itemInfos[2];
            switch (itemInfos[3])
            {
                case "Equip":
                    item.InventoryTYPE = InventoryType.Equip;
                    break;
                case "Drug":
                    item.InventoryTYPE = InventoryType.Drug;
                    break;
                case "Box":
                    item.InventoryTYPE = InventoryType.Box;
                    break;
            }

            if (item.InventoryTYPE == InventoryType.Equip)
            {
                switch (itemInfos[4])
                {
                    case "Helm":
                        item.EquipTYPE = EquipType.Head;
                        break;

                    case "Cloth":
                        item.EquipTYPE = EquipType.Cloth;
                        break;

                    case "Weapon":
                        item.EquipTYPE = EquipType.Weapon;
                        break;

                    case "Shoes":
                        item.EquipTYPE = EquipType.Shoes;
                        break;

                    case "Necklace":
                        item.EquipTYPE = EquipType.Necklace;
                        break;

                    case "Bracelet":
                        item.EquipTYPE = EquipType.Bracelet;
                        break;

                    case "Ring":
                        item.EquipTYPE = EquipType.Ring;
                        break;

                    case "Wing":
                        item.EquipTYPE = EquipType.Wing;
                        break;
                }
            }

            ////ID 名称 图标 类型（Equip，Drug） 装备类型(Helm,Cloth,Weapon,Shoes,Necklace,Bracelet,Ring,Wing) 售价 星级 品质 伤害 生命 战斗力 作用类型 作用值 描述

            item.Price = int.Parse(itemInfos[5]);
            if (item.InventoryTYPE == InventoryType.Equip)
            {
                
                item.StarGrade = int.Parse(itemInfos[6]);
                item.Quality = int.Parse(itemInfos[7]);
                item.Damage = int.Parse(itemInfos[8]);
                item.Addhp = int.Parse(itemInfos[9]);
                item.Power = int.Parse(itemInfos[10]);
            }

            if (item.InventoryTYPE == InventoryType.Drug)
            {
                //item.InfoType 11
                item.ApplyValue = int.Parse(itemInfos[12]);
            }


            item.Des = itemInfos[13];
            InventoryDict.Add(item.ID, item);
        }
    }


    public void DelInventory(InventoryItem it)
    {
        this.InventoryItemList.Remove(it);
    }

}
