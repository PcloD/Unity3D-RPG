using UnityEngine;
using System.Collections;

public class PlayerStatusBar : MonoBehaviour
{

    private UISprite headSprite;
    private UILabel levelLabel;
    private UILabel nameLabel;
    private UILabel powerLabel;
    private UILabel diamondLabel;
    private UILabel coinLabel;

    private UIButton renameBtn;

    private UISlider expSlider;
    private UILabel expLabel;

    private UILabel energyLabel;
    private UILabel energyReLabel;
    private UILabel energyAllReLabel;

    private UILabel toughenLabel;
    private UILabel toughenReLabel;
    private UILabel toughenAllReLabel;

    
    public TweenScale renameTween;

    void Awake()
    {
        headSprite = transform.Find("SpritePlayerHead").GetComponent<UISprite>();
        levelLabel = transform.Find("LabelLevel").GetComponent<UILabel>();
        nameLabel = transform.Find("LabelPlayerName").GetComponent<UILabel>();
        powerLabel = transform.Find("LabelPower").GetComponent<UILabel>();
        diamondLabel = transform.Find("Diamond/Label").GetComponent<UILabel>();
        coinLabel = transform.Find("Coin/Label").GetComponent<UILabel>();

        renameBtn = transform.Find("BtnRename").GetComponent<UIButton>();

        expSlider = transform.Find("ExpBg/SliderExp").GetComponent<UISlider>();
        expLabel = transform.Find("ExpBg/SliderExp/Label").GetComponent<UILabel>();

        energyLabel = transform.Find("Energy/LabelEnergy").GetComponent<UILabel>();
        energyReLabel = transform.Find("Energy/LabelRenew").GetComponent<UILabel>();
        energyAllReLabel = transform.Find("Energy/LabelAllRenew").GetComponent<UILabel>();

        toughenLabel = transform.Find("Toughen/LabelToughen").GetComponent<UILabel>();
        toughenReLabel = transform.Find("Toughen/LabelRenew").GetComponent<UILabel>();
        toughenAllReLabel = transform.Find("Toughen/LabelAllRenew").GetComponent<UILabel>();

        PlayerInfo._Instance.OnPlayerInfoChangedEvent += this.OnPlayerInfoChanged;


    }

    void Start()
    {
        gameObject.SetActive(false);
    }

    void OnDestory()
    {
        PlayerInfo._Instance.OnPlayerInfoChangedEvent -= this.OnPlayerInfoChanged;
    }

    void OnPlayerInfoChanged(PlayerInfoType infoType)
    {
        switch (infoType)
        {
            case PlayerInfoType.Name:
                UpdateShowPlayerName();
                break;
            case PlayerInfoType.Head:
                UpdateShowPlayerHead();
                break;
            case PlayerInfoType.Level:
                UpdateShowPlayerLevel();
                break;
            case PlayerInfoType.Power:
                UpdateShowPlayerPower();
                break;
            case PlayerInfoType.Exp:
                UpdateShowPlayerExp();
                break;
            case PlayerInfoType.Energy:
                UpdateShowPlayerEnergy();
                break;
            case PlayerInfoType.Toughen:
                UpdateShowPlayerToughen();
                break;
            case PlayerInfoType.Coin:
                UpdateShowPlayerCoin();
                break;
            case PlayerInfoType.Diamond:
                UpdateShowPlayerDiamond();
                break;

            case PlayerInfoType.All:
                UpdateShowPlayerAll();
                break;
        }
    }

    private void UpdateShowPlayerPower()
    {
        //Debug.Log(PlayerInfo._Instance.Power);
        powerLabel.text = PlayerInfo._Instance.Power.ToString();
    }

    private void UpdateShowPlayerExp()
    {
        int requirdExp = GameController.GetRequireExpByLevel(PlayerInfo._Instance.Level + 1);
        expLabel.text = PlayerInfo._Instance.Exp + "/" + requirdExp;
        expSlider.value = (float)PlayerInfo._Instance.Exp / (float)requirdExp;
    }

    void UpdateShowPlayerName()
    {
        //Debug.Log(PlayerInfo._Instance.Name);
        nameLabel.text = PlayerInfo._Instance.Name;
    }

    void UpdateShowPlayerHead()
    {
        headSprite.spriteName = PlayerInfo._Instance.Head;
    }

    void UpdateShowPlayerLevel()
    {
        levelLabel.text = PlayerInfo._Instance.Level.ToString();
    }

    void UpdateShowPlayerEnergy()
    {
        energyLabel.text = PlayerInfo._Instance.Energy.ToString() + "/" + PlayerInfo._Instance.MAXENERGY;


        if (PlayerInfo._Instance.Energy >= PlayerInfo._Instance.MAXENERGY)
        {
            energyReLabel.text = "00:00:00";
            energyAllReLabel.text = "00:00:00";
        }
        else
        {
            int time = GameDefine.TIMEREENERGY - (int)PlayerInfo._Instance.timer_energy;
            int min = (int)time / 60;
            int sec = (int)time % 60;
            string str_min = min > 9 ? min.ToString() : "0" + min;
            string str_sec = sec > 9 ? sec.ToString() : "0" + sec;
            energyReLabel.text = str_min + ":" + str_sec;

            sec = (PlayerInfo._Instance.MAXENERGY - PlayerInfo._Instance.Energy) * GameDefine.TIMEREENERGY - (int)PlayerInfo._Instance.timer_energy;

            int hour = sec / 60 / 60;

            min = (sec - hour * 60 * 60) / 60;
            sec -= (hour * 60 * 60 + min * 60);
            string str_hour = hour > 9 ? hour.ToString() : "0" + hour;
            str_min = min > 9 ? min.ToString() : "0" + min;
            str_sec = sec > 9 ? sec.ToString() : "0" + sec;

            energyAllReLabel.text = str_hour + ":" + str_min + ":" + str_sec;
        }
    }

    void UpdateShowPlayerToughen()
    {
        toughenLabel.text = PlayerInfo._Instance.Toughen.ToString() + "/" + PlayerInfo._Instance.MAXTOUGHEN;

        if (PlayerInfo._Instance.Toughen >= PlayerInfo._Instance.MAXENERGY)
        {
            toughenReLabel.text = "00:00:00";
            toughenAllReLabel.text = "00:00:00";
        }
        else
        {
            int time = GameDefine.TIMERETOUGHEN - (int)PlayerInfo._Instance.timer_toughen;
            int min = (int)time / 60;
            int sec = (int)time % 60;
            string str_min = min > 9 ? min.ToString() : "0" + min;
            string str_sec = sec > 9 ? sec.ToString() : "0" + sec;
            //string str_time = time > 60 ? min + ":" + sec : time + "";
            //Debug.Log(time);
            //Debug.Log(time % 60 + ":" + time / 60);
            toughenReLabel.text = str_min + ":" + str_sec;

            sec = (PlayerInfo._Instance.MAXTOUGHEN - PlayerInfo._Instance.Toughen) * GameDefine.TIMERETOUGHEN - (int)PlayerInfo._Instance.timer_energy;

            int hour = sec / 60 / 60;

            min = (sec - hour * 60 * 60) / 60;
            sec -= (hour * 60 * 60 + min * 60);
            //Debug.Log("hour" + hour);
            // Debug.Log("min" + min);
            //Debug.Log("sec" + sec);
            string str_hour = hour > 9 ? hour.ToString() : "0" + hour;
            str_min = min > 9 ? min.ToString() : "0" + min;
            str_sec = sec > 9 ? sec.ToString() : "0" + sec;

            toughenAllReLabel.text = str_hour + ":" + str_min + ":" + str_sec;

        }
    }

    void UpdateShowPlayerCoin()
    {
        coinLabel.text = PlayerInfo._Instance.Coin.ToString();
    }

    void UpdateShowPlayerDiamond()
    {
        diamondLabel.text = PlayerInfo._Instance.Diamond.ToString();
    }

    //全部刷新
    void UpdateShowPlayerAll()
    {
        UpdateShowPlayerName();

        UpdateShowPlayerHead();

        UpdateShowPlayerLevel();

        UpdateShowPlayerEnergy();

        UpdateShowPlayerToughen();

        UpdateShowPlayerExp();

        UpdateShowPlayerPower();

        UpdateShowPlayerCoin();

        UpdateShowPlayerDiamond();
    }

    public void OnCloseClick()
    {
        GetComponent<TweenPosition>().PlayReverse();
        StartCoroutine(EnactivePancel(gameObject));

    }

    IEnumerator EnactivePancel(GameObject go)
    {
        yield return new WaitForSeconds(0.3f);
        go.SetActive(false);
    }


    public void OnRenameShowClick()
    {
        renameTween.gameObject.SetActive(true);
        renameTween.PlayForward();
    }

    public void OnRenameClick()
    {

        string text=GetComponentInChildren<UIInput>().value;
        
        if(text!="")
        {
            
            PlayerInfo._Instance.Name = text;
            OnCancelClick();
           
        }
        
    }

    public void OnCancelClick()
    {
        renameTween.PlayReverse();
        StartCoroutine(EnactivePancel(renameTween.gameObject));
    }



}
