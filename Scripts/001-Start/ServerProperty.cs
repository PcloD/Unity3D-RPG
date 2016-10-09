using UnityEngine;
using System.Collections;

public class ServerProperty : MonoBehaviour
{

    public string ip = "127.0.0.1:9080";
    //public string name = "2区 盘丝洞";
    public string name
    {
        set { transform.Find("Label_ServerName").GetComponent<UILabel>().text = value; }
    }
    public int count = 100; //在线人数


    //按下的时候出发一次 抬起的时候触发一次
    public void OnPress(bool isPress)
    {
        if(!isPress)
        {
            //选择了当前的服务器 
            Debug.Log("SendMessage");
            transform.root.GetComponentInChildren<StartMenuController>().SendMessage("OnServerSelected", this.gameObject);
            
        }
    }
}
