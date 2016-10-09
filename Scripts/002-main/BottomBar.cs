using UnityEngine;
using System.Collections;

public class BottomBar : MonoBehaviour {

    public void OnInventoryClick()
    {
        Knapsack._Instance.Show();
    }

    public void OnTaskClick()
    {
        TaskUI._Instance.Show();
    }

    public void OnSkillClick()
    {
        SkillUI._Instance.Show();
    }

    public void OnShopClick()
    {

    }

    public void OnSystemClick()
    {

    }

    public void OnFightClick()
    {

    }
}
