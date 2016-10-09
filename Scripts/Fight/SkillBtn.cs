using UnityEngine;
using System.Collections;

public class SkillBtn : MonoBehaviour {

    public PosType posType = PosType.Basic;

    private PlayerAttack playerAttack;
    public float coldTime = 4f;
    private float coldTimer = 0f;//表示剩余时间
    private UISprite maskSprite;
    private UIButton btn;
    void Awake()
    {
        if (transform.Find("Mask"))
        {
            maskSprite = transform.Find("Mask").GetComponent<UISprite>();
            maskSprite.spriteName = this.GetComponent<UISprite>().spriteName;
        }

        btn = GetComponent<UIButton>();
       
    }

    void Start()
    {
        playerAttack = TranscriptManager._Instance.player.GetComponent<PlayerAttack>();
    }

    void OnPress(bool isPress)
    {
        if (isPress&&maskSprite!=null)
        {
            playerAttack.OnAttackClick(posType);
            //释放当前技能

            if (coldTimer<=0)
            {
                //开始冷却
                coldTimer = coldTime;
                DisableBtn();
            }      
        }else if (isPress)
        {
            playerAttack.OnAttackClick(posType);
        }
        else
        {
            //PlayerAnim._Instance.StopSkill();
        }
    }

    void Update()
    {
        if (maskSprite==null)
        {
            return;
        }
       
        if (coldTimer>0)
        {
            coldTimer -= Time.deltaTime;
            maskSprite.fillAmount = coldTimer / coldTime;
            //Debug.Log(coldTimer);
            if (coldTimer<=0)
            {
                EnableBtn();
            }

        }
        else
        {
            
            maskSprite.fillAmount = 0;
        }
    }

    void DisableBtn()
    {
        btn.GetComponent<Collider>().enabled = false;
        btn.SetState(UIButtonColor.State.Disabled, true);
    }

    void EnableBtn()
    {
        btn.GetComponent<Collider>().enabled = true;
        btn.SetState(UIButtonColor.State.Normal, true);
    }
}
