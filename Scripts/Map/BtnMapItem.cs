using UnityEngine;
using System.Collections;

public class BtnMapItem : MonoBehaviour {

    public int id;
    public int needLevel;
    public string sceneName;
    public string des = "欢迎挑战副本";

    void OnClick()
    {
        Debug.Log(transform.parent.parent);

        //弹出副本提示信息
        transform.parent.parent.Find("Dialog").SendMessage("ShowMapDialog", this);

    }
}
