using UnityEngine;
using System.Collections;

public class TaskItemUI : MonoBehaviour {

    private UISprite taskTypeSprite;
    private UISprite iconSprite;
    private UILabel nameLabel;
    private UILabel desLabel;

    private UISprite reward1Sprite;
    private UILabel reward1Label;

    private UISprite reward2Sprite;
    private UILabel reward2Label;

    private UIButton combatBtn;//接受任务
    private UIButton rewardBtn;//领取奖励 

    private UILabel combatBtnLabel;

    private Task task;


    void Awake()
    {
        taskTypeSprite = transform.Find("TaskTypeSprite").GetComponent<UISprite>();
        iconSprite = transform.Find("IconBg/Sprite").GetComponent<UISprite>();

        nameLabel = transform.Find("NameLabel").GetComponent<UILabel>();
        desLabel = transform.Find("DesLabel").GetComponent<UILabel>();

        reward1Sprite = transform.Find("CoinSprite").GetComponent<UISprite>();
        reward1Label = transform.Find("CoinLabel").GetComponent<UILabel>();

        reward2Sprite = transform.Find("DiamondSprite").GetComponent<UISprite>();
        reward2Label = transform.Find("DiamondLabel").GetComponent<UILabel>();

        combatBtn = transform.Find("CombatBtn").GetComponent<UIButton>();
        rewardBtn = transform.Find("RewardBtn").GetComponent<UIButton>();
    
        combatBtnLabel=combatBtn.transform.Find("Label").GetComponent<UILabel>();
    }


    public void SetTask(Task task)
    {
        this.task = task;
        task.OnTaskChangeEvent += this.OnTaskChange;

        UpdateShow(task);

        
        
    }

    private void UpdateShow(Task task)
    {
        switch (task.TaskType)
        {
            case TaskType.Main:
                taskTypeSprite.spriteName = "pic_主线";
                break;

            case TaskType.Reward:
                taskTypeSprite.spriteName = "pic_奖赏";
                break;

            case TaskType.Daily:
                taskTypeSprite.spriteName = "pic_日常";
                break;
        }


        iconSprite.spriteName = task.Icon;
        nameLabel.text = task.Name;
        desLabel.text = task.Des;

        if (task.Coin > 0 && task.Diamond > 0)
        {
            reward1Sprite.spriteName = "金币";
            reward1Label.text = "X" + task.Coin;
            reward2Sprite.spriteName = "钻石";
            reward2Label.text = "X" + task.Diamond;
        }
        else if (task.Coin > 0)
        {
            reward1Sprite.spriteName = "金币";
            reward1Label.text = "X" + task.Coin;

            reward2Sprite.gameObject.SetActive(false);
            reward2Label.gameObject.SetActive(false);
        }
        else if (task.Diamond > 0)
        {
            reward1Sprite.spriteName = "钻石";
            reward1Label.text = "X" + task.Diamond;

            reward2Sprite.gameObject.SetActive(false);
            reward2Label.gameObject.SetActive(false);
        }

        switch (task.TaskProcess)
        {
            case TaskProcess.NoStart:
                combatBtnLabel.text = "下一步";
                rewardBtn.gameObject.SetActive(false);
                break;

            case TaskProcess.Accept:
                combatBtnLabel.text = "战斗";
                rewardBtn.gameObject.SetActive(false);
                break;

            case TaskProcess.Complete:
                combatBtn.gameObject.SetActive(false);
                rewardBtn.gameObject.SetActive(true);
                break;


        }
    }

   
    /// <summary>
    /// 处理接受任务
    /// </summary>
    public void OnCombatClick()
    {
        TaskManager._Instance.OnExcuteTask(task);
        TaskUI._Instance.Hide();
    }

    /// <summary>
    /// 获取奖励
    /// </summary>
    public void OnRewardClick()
    {

    }

    void OnTaskChange()
    {
        UpdateShow(task);
    }

    
}
