using UnityEngine;
using System.Collections;

public class CharacterShow : MonoBehaviour {

    public string anim_Attack;
    public string anim_Idle;
    private Animation animation;

    void Awake()
    {
        animation = GetComponent<Animation>();
    }


	public void OnPress(bool isPress)
    {
        //Debug.Log("onPress");
        if(isPress)
        {
            StartMenuController._Instance.OnCharacterSelect(gameObject);
            //TODO 显示角色攻击动画
            animation.CrossFade(anim_Attack);
            //TODO 角色攻击动画播放完毕后 再次播放Idle
            animation.PlayQueued(anim_Idle, QueueMode.CompleteOthers);

        }
    }
}
