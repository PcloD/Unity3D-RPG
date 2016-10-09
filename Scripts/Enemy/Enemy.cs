using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public GameObject damageEffectPrefeb;
    public Transform bloodPoint;
    private Animation animation;

    public int HP = 50;

    void Start()
    {
        animation = GetComponent<Animation>();
    }

    //受到攻击
    //1.收到多少伤害
    //2后退 特效
    //3浮空
    void TakeDamage(string args)
    {
        if (HP<=0)
        {
            return;
        }
        Debug.Log("111");
        string[] attackInfos = args.Split(',');
        int damage = int.Parse(attackInfos[0]);
        float moveback = float.Parse(attackInfos[1]);
        float height = float.Parse(attackInfos[2]);

        //播放收到攻击的动画
        animation.Play("takedamage");

        //后退
        iTween.MoveBy(this.gameObject,//
            transform.InverseTransformDirection(TranscriptManager._Instance.player.transform.forward)*moveback+Vector3.up*height,//
            0.2f);

        //出血特效
        GameObject.Instantiate(damageEffectPrefeb, bloodPoint.position, Quaternion.identity);

        //减去伤害
        HP -= damage;
        if (HP<=0)
        {
            Dead();
        }

    }

    //死亡的处理
    void Dead()
    {
        animation.Play("die");
    }
}
