using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KnapsackInventory : MonoBehaviour {

    public static KnapsackInventory _Instance;

    public List<InventoryItemUI> itemlist = new List<InventoryItemUI>();//物品格子

    private UILabel inventoryLabel;
   

    private int count = 0;

    void Awake()
    {
        _Instance = this;

        inventoryLabel = transform.Find("InventoryLabel").GetComponent<UILabel>();
        

        InventoryManager._Instance.OnInventoryChangeEvent += this.OnInventoryChange;
    }

    void OnDestory()
    {
        InventoryManager._Instance.OnInventoryChangeEvent -= this.OnInventoryChange;
    }
    
    void OnInventoryChange()
    {
        UpdateShow();
    }

    void UpdateShow()
    {
        int temp = 0;

        for(int i=0;i<InventoryManager._Instance.InventoryItemList.Count;i++)
        {
            InventoryItem it = InventoryManager._Instance.InventoryItemList[i];

            if (it.IsDress==false)
            {
                itemlist[temp].SetInventoryItem(it);
                temp++;
            }
            
            
        }

        count = temp;//格子数量
        for (int i = temp; i < itemlist.Count; i++)
        {
            itemlist[i].Clear();
        }

        //更新格子数量信息
        inventoryLabel.text = count + "/" + itemlist.Count;
    }

    //添加一个物品
    public void AddInventoryItem(InventoryItem it)
    {
        foreach(InventoryItemUI itui in itemlist)
        {
            if(itui.it==null)//如果是空格子
            {
                //空格子 可以放入
                itui.SetInventoryItem(it);
                //Debug.Log("AddInventoryItem");
                count++;
                //itemlist.Add(itui);
                break;
            }
        }

        inventoryLabel.text = count + "/" + itemlist.Count;
    }

    //整理按钮点击事件
    public void OnCleanClick()
    {
        UpdateShow();
    }

    public void UpdateLabel()
    {
        count = 0;
        foreach (InventoryItemUI itui in itemlist)
        {
            if (itui.it != null)//如果是空格子
            {
                count++;
            }
        }
        //Debug.Log(count);

        inventoryLabel.text = count + "/" + itemlist.Count;
    }

}
