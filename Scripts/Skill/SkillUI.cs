using UnityEngine;
using System.Collections;

public class SkillUI : MonoBehaviour
{
    public static SkillUI _Instance;

    private UILabel nameLabel;
    private UILabel desLabel;
    private UIButton upgradeBtn;
    private UILabel upgradeBtnLabel;
    private TweenPosition tween;

    private Skill skill;//当选中的技能
    void Awake()
    {
        _Instance = this;

        nameLabel = transform.Find("Bg/NameLabel").GetComponent<UILabel>();
        desLabel = transform.Find("Bg/DesLabel").GetComponent<UILabel>();
        upgradeBtnLabel = transform.Find("UpgradeBtn/Label").GetComponent<UILabel>();
        upgradeBtn = transform.Find("UpgradeBtn").GetComponent<UIButton>();
        tween = GetComponent<TweenPosition>();
        nameLabel.text = "";
        desLabel.text = "";
        DisableUpgradeBtn("选择技能");

    }

    void DisableUpgradeBtn(string labelText = "")
    {
        upgradeBtn.SetState(UIButtonColor.State.Disabled, true);
        upgradeBtn.GetComponent<Collider>().enabled = false;
        if (labelText != "")
        {
            upgradeBtnLabel.text = labelText;
        }
    }

    void EnableUpgradeBtn(string labelText = "")
    {
        upgradeBtn.SetState(UIButtonColor.State.Normal, true);
        upgradeBtn.GetComponent<Collider>().enabled = true;
        if (labelText != "")
        {
            upgradeBtnLabel.text = labelText;
        }
    }

    void OnSkillClick(Skill skill)
    {
        this.skill = skill;

        int needGold = (skill.Level + 1) * 500;
        if (needGold<=PlayerInfo._Instance.Coin)
        {
            if (skill.Level<=PlayerInfo._Instance.Level)
            {
                EnableUpgradeBtn("升级");
            }
            else
            {
                DisableUpgradeBtn("等级不足");
            }
            
        }
        else
        {
            DisableUpgradeBtn("金币不足");
        }
        

        nameLabel.text = skill.Name + " Lv." + skill.Level;
        desLabel.text = "当前技能的攻击力:" + skill.Damage * skill.Level + '\n'
    + "升级所需的金币:" + needGold;

        
    }

    public void OnUpgradeClick()
    {
        
        int needSkill = skill.Level;
        
        if (needSkill<=PlayerInfo._Instance.Level)
        {
            int needGold = (skill.Level + 1) * 500;
            bool isSuccess = PlayerInfo._Instance.GetCoin(needGold);
            if (isSuccess)
            {
               
                skill.UpgradeSkill();
                OnSkillClick(skill);
            }
            else
            {
                DisableUpgradeBtn("金币不足");
            }
        }
        else
        {
            DisableUpgradeBtn("等级不足");
        }
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
}
