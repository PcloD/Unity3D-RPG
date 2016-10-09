using UnityEngine;
using System.Collections;

public class InventoryItem  {

    private Inventory inventory;
    private int level;
    private int count;
    private bool isDress=false;

    public Inventory Inventory
    {
        set { inventory = value; }
        get { return inventory; }
    }

    public int Level {
        set { level = value; }
        get { return level; }
    }

    public int Count
    {
        set { count = value; }
        get { return count; }
    }

    public bool IsDress
    {
        set { isDress = value; }
        get { return isDress; }
    }
}
