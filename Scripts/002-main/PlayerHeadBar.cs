using UnityEngine;
using System.Collections;

public class PlayerHeadBar : MonoBehaviour {

    private UISprite headSprite;
    private UILabel nameLabel;
    private UILabel levelLabel;
    private UILabel energyLabel;
    private UILabel toughenLabel;
    private UISlider energySlider;
    private UISlider toughenSlider;
    private UIButton energyPlusBtn;
    private UIButton toughenPlusBtn;

    public TweenPosition playerStatusBarTween;
    void Awake()
    {
        headSprite=transform.Find("SpritePlayerHead").GetComponent<UISprite>();
        nameLabel = transform.Find("LabelPlayerName").GetComponent<UILabel>();
        levelLabel = transform.Find("LabelLevel").GetComponent<UILabel>();
       
        energySlider = transform.Find("SliderEnergy").GetComponent<UISlider>();
        toughenSlider = transform.Find("SliderToughen").GetComponent<UISlider>();
        energyPlusBtn = transform.Find("BtnEnergyPlus").GetComponent<UIButton>();
        toughenPlusBtn = transform.Find("BtnToughenPlus").GetComponent<UIButton>();

        energyLabel = energySlider.transform.Find("Label").GetComponent<UILabel>();
        toughenLabel = toughenSlider.transform.Find("Label").GetComponent<UILabel>();

        //委托
        PlayerInfo._Instance.OnPlayerInfoChangedEvent += this.OnPlayerInfoChanged;
    }

    void Start()
    {
        
    }

    void OnDestory()
    {
        PlayerInfo._Instance.OnPlayerInfoChangedEvent -= this.OnPlayerInfoChanged;
    }

    void OnPlayerInfoChanged(PlayerInfoType infoType)
    {
        //如果是这些值得话
        //if(infoType==PlayerInfoType.Name||//
        //    infoType==PlayerInfoType.Head||//
        //    infoType==PlayerInfoType.Level||//
        //    infoType==PlayerInfoType.Energy||//
        //    infoType==PlayerInfoType.Toughen)
        //{

        //}

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
            case PlayerInfoType.Energy:
                UpdateShowPlayerEnergy();
                break;
            case PlayerInfoType.Toughen:
                UpdateShowPlayerToughen();
                break;
            case PlayerInfoType.All:
                UpdateShowPlayerAll();
                break;
        }


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
        //更新slider
        energySlider.value = (float)PlayerInfo._Instance.Energy / (float)PlayerInfo._Instance.MAXENERGY;
    }

    void UpdateShowPlayerToughen()
    {
        toughenLabel.text = PlayerInfo._Instance.Toughen.ToString() + "/" + PlayerInfo._Instance.MAXTOUGHEN;

        toughenSlider.value = (float)PlayerInfo._Instance.Toughen / (float)PlayerInfo._Instance.MAXTOUGHEN;
    }

    //全部刷新
    void UpdateShowPlayerAll()
    {
        UpdateShowPlayerName();

        UpdateShowPlayerHead();

        UpdateShowPlayerLevel();

        UpdateShowPlayerEnergy();

        UpdateShowPlayerToughen();
    }

    public void OnHeadClick()
    {
        playerStatusBarTween.gameObject.SetActive(true);
        playerStatusBarTween.PlayForward();
    }
}
