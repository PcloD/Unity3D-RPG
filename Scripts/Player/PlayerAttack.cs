using UnityEngine;
using System.Collections;

public enum AttackRange
{
    Forward,
    Around
}


public class PlayerAttack : MonoBehaviour
{


    public float attackDistanceForward = 2f;
    public float attackDistanceAround = 2f;

    //public int[] AttackInfo = new int[] { 20,30,30,30};

    public void OnAttackClick(PosType posType)
    {
        //Debug.Log("OnAttackClick");

        if (posType == PosType.Basic)
        {
            PlayerAnim._Instance.PlayAttackAnim();
            //
        }
        else
        {
            if (posType == PosType.One)
            {
                PlayerAnim._Instance.PlaySkillOne();
                StartCoroutine(StopSkill());
            }
            else if (posType == PosType.Two)
            {
                PlayerAnim._Instance.PlaySkillTwo();
                StartCoroutine(StopSkill());
            }
            else if (posType == PosType.Three)
            {
                PlayerAnim._Instance.PlaySkillThree();
                StartCoroutine(StopSkill());
            }
        }
    }


    IEnumerator StopSkill()
    {
        yield return new WaitForSeconds(1.5f);
        PlayerAnim._Instance.StopSkill();
    }


    //0,sound name
    //1,moveforward 
    //2,类型
    void AttackEvent(string args)
    {
        //Debug.Log("Attack");

        string[] proArray = args.Split(',');

        string soundName = proArray[0];
        SoundManager._Instance.Play(soundName);

        float moveForward = float.Parse(proArray[1]);
        if (moveForward > 0.1f)
        {
            iTween.MoveBy(this.gameObject, Vector3.forward * moveForward, 0.3f);
        }

        string posType = proArray[2];

        int damage=20;//伤害
        float moveback = 1f;//后退距离
        float height = 3f;//浮空

        if (posType == "normal")
        {
            ArrayList array = GetEnemyInRange(AttackRange.Forward);
            foreach (GameObject go in array)
            {
                go.SendMessage("TakeDamage",damage+","+moveback+","+height);
            }
        }

    }

    //得到在攻击范围内的敌人
    ArrayList GetEnemyInRange(AttackRange attackRange)
    {
        ArrayList arrayList = new ArrayList();
        if (attackRange == AttackRange.Forward)
        {
            foreach (GameObject go in TranscriptManager._Instance.enemyList)
            {
                //将敌人的坐标转化为玩家的相对坐标
                Vector3 pos = transform.InverseTransformPoint(go.transform.position);
                if (pos.z > -0.5f)
                {
                    //敌人和主角的距离
                    float distance = Vector3.Distance(Vector3.zero, pos);
                    if (distance < attackDistanceForward)
                    {
                        arrayList.Add(go);
                    }
                }
            }
        }
        else if (attackRange == AttackRange.Around)
        {
            foreach (GameObject go in TranscriptManager._Instance.enemyList)
            {
                //将敌人的坐标转化为玩家的相对坐标
                Vector3 pos = transform.InverseTransformPoint(go.transform.position);

                //敌人和主角的距离
                float distance = Vector3.Distance(Vector3.zero, pos);
                if (distance < attackDistanceForward)
                {
                    arrayList.Add(go);
                }

            }
        }


        return arrayList;
    }

    void ShowEffectDevilHand()
    {

    }

}
