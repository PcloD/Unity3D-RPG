using UnityEngine;
using System.Collections;

public class PlayerAnim : MonoBehaviour {

    public static PlayerAnim _Instance;

    private Animator anim;

    void Awake()
    {
        _Instance = this;
    }

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void PlayIdleAnim()
    {
       
        anim.SetBool("Run", false);
    }

    public void PlayRunAnim()
    {
        anim.SetBool("Run", true);
    }

    public void PlayAttackAnim()
    {
        //TranscriptManager._Instance.player.GetComponent<PlayerMove>().canMove = false;
        anim.SetTrigger("Attack");
    }

    public void PlaySkillOne()
    {
        
        TranscriptManager._Instance.player.GetComponent<PlayerMove>().SetCanMove(false);
        anim.SetBool("Skill1",true);
    }

    public void PlaySkillTwo()
    {
        TranscriptManager._Instance.player.GetComponent<PlayerMove>().SetCanMove(false);
        anim.SetBool("Skill2", true);
    }

    public void PlaySkillThree()
    {
        TranscriptManager._Instance.player.GetComponent<PlayerMove>().SetCanMove(false);
        anim.SetBool("Skill3", true);
    }

    public void StopSkill()
    {
        TranscriptManager._Instance.player.GetComponent<PlayerMove>().SetCanMove(true);
        anim.SetBool("Skill1", false);
        anim.SetBool("Skill2", false);
        anim.SetBool("Skill3", false);
    }

}
