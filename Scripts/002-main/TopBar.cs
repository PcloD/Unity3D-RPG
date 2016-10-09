using UnityEngine;
using System.Collections;

public class TopBar : MonoBehaviour {

    private UILabel coinLabel;
    private UILabel diamondLabel;
    private UIButton coinPlusBtn;
    private UIButton diamondPlusBtn;


    void Awake()
    {
        diamondLabel = transform.Find("DiamondBg/Label").GetComponent<UILabel>();
        coinLabel = transform.Find("CoinBg/Label").GetComponent<UILabel>();

        diamondPlusBtn = transform.Find("DiamondBg/BtnPlus").GetComponent<UIButton>();
        coinPlusBtn = transform.Find("CoinBg/BtnPlus").GetComponent<UIButton>();


        PlayerInfo._Instance.OnPlayerInfoChangedEvent += this.OnPlayerInfoChanged;
    }

    void OnDestory()
    {
        PlayerInfo._Instance.OnPlayerInfoChangedEvent -= this.OnPlayerInfoChanged;
    }

    void OnPlayerInfoChanged(PlayerInfoType infoType)
    {
        switch (infoType)
        {

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

    private void UpdateShowPlayerCoin()
    {
        coinLabel.text = PlayerInfo._Instance.Coin.ToString();
    }

    private void UpdateShowPlayerDiamond()
    {
        diamondLabel.text = PlayerInfo._Instance.Diamond.ToString();
    }

    private void UpdateShowPlayerAll()
    {
        UpdateShowPlayerCoin();
        UpdateShowPlayerDiamond();
    }


}
