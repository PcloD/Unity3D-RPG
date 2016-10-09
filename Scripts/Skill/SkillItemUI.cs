using UnityEngine;
using System.Collections;

public class SkillItemUI : MonoBehaviour
{

    public PosType posType;

    private Skill skill;
    public bool isSelect;
    private UISprite sprite;
    private UISprite Sprite
    {
        get
        {
            if (sprite == null)
            {
                sprite = GetComponent<UISprite>();
            }
            return sprite;
        }
    }

    private UIButton button;
    private UIButton Button
    {
        get
        {
            if (button==null)
            {
                button = GetComponent<UIButton>();
            }
            return button;
        }
    }

    void Start()
    {
        UpdateShow();
        if (isSelect)
        {
            OnClick();
        }
    }

    void UpdateShow()
    {
        skill = SkillManager._Instance.GetSkillByPostype(posType);

        if (skill != null)
        {
            Sprite.spriteName = skill.Icon;
            Button.normalSprite = skill.Icon;
        }
    }

    void OnClick()
    {

        transform.parent.parent.SendMessage("OnSkillClick", skill);

    }
}
