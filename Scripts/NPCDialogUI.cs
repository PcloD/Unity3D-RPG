using UnityEngine;
using System.Collections;

public class NPCDialogUI : MonoBehaviour {

    public static NPCDialogUI _Instance;

    private TweenPosition tween;
    private UISprite headSprite;
    private UILabel desLabel;

    void Awake()
    {
        _Instance = this;

        tween = GetComponent<TweenPosition>();

        headSprite = transform.Find("HeadSprite").GetComponent<UISprite>();
        desLabel = transform.Find("DesLabel").GetComponent<UILabel>();

        
    }

    public void Show(string des)
    {

        desLabel.text = des;
        tween.PlayForward();
    }

    public void Hide()
    {

        tween.PlayReverse();
    }

    public void OnAcceptClick()
    {
        //通知任务管理器已经接受
        TaskManager._Instance.OnAcceptTask();

        Hide();
    }
}
