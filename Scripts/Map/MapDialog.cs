using UnityEngine;
using System.Collections;

public class MapDialog : MonoBehaviour
{

    public static MapDialog _Instance;

    private TweenPosition tween;
    private UILabel desLabel;
    private UILabel energyTagLabel;
    private UILabel energyLabel;
    private UIButton enterBtn;

    void Awake()
    {
        _Instance = this;

        tween = GetComponent<TweenPosition>();
        desLabel = transform.Find("Sprite/DesLabel").GetComponent<UILabel>();
        energyTagLabel = transform.Find("Sprite/EnergyTagLabel").GetComponent<UILabel>();
        energyLabel = transform.Find("Sprite/EnergyLabel").GetComponent<UILabel>();
        enterBtn = transform.Find("Sprite/EnterBtn").GetComponent<UIButton>();

    }

    public void Show()
    {
        tween.PlayForward();
    }

    public void Hide()
    {

        tween.PlayReverse();

    }

    public void OnCloseClick()
    {
        Hide();
    }

    void ShowMapDialog(BtnMapItem bmt)
    {
        if (bmt.needLevel > PlayerInfo._Instance.Level)
        {
            ShowWarning();
        }
        else
        {
            Show();
            energyLabel.enabled = true;
            energyTagLabel.enabled = true;
            enterBtn.SetState(UIButton.State.Normal, true);
            enterBtn.GetComponent<Collider>().enabled = true;

            desLabel.text = bmt.des;
            energyLabel.text = 3 + "";
        }




        //desLabel.text=bmt.
    }

    public void OnEnterClick()
    {

    }

    void ShowWarning()
    {
        energyLabel.enabled = false;
        energyTagLabel.enabled = false;
        enterBtn.SetState(UIButton.State.Disabled, true);
        enterBtn.GetComponent<Collider>().enabled = false;
        desLabel.text = "当前等级无法进入地下城";

        Show();
    }




}
