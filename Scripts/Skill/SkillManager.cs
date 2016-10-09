using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SkillManager : MonoBehaviour {

    public static SkillManager _Instance;

    public TextAsset skillText;

    //private Dictionary<int, Skill> skillDict = new Dictionary<int, Skill>();
    private List<Skill> skillList = new List<Skill>();

    void Awake()
    {

        _Instance = this;

        InitSkillInfo();

        //Debug.Log(skillDict.Count);

    }

    void InitSkillInfo()
    {
        string[] skills = skillText.ToString().Split('\n');

        for (int i = 0; i < skills.Length; i++)
        {
            string[] skillInfos = skills[i].Split(',');

            Skill skill = new Skill();
            skill.Id = int.Parse(skillInfos[0]);
            skill.Name = skillInfos[1];
            skill.Icon = skillInfos[2];

            switch (skillInfos[3])
            {
                case "Warrior":
                    skill.PlayerType = PlayerType.Warrior;
                    break;
                case "FemaleAssassin":
                    skill.PlayerType = PlayerType.FemaleAssassin;
                    break;
            }

            switch (skillInfos[4])
            {
                case "Basic":
                    skill.SkillType = SkillType.Basic;
                    break;

                case "Skill":
                    skill.SkillType = SkillType.Skill;
                    break;
            }

            switch (skillInfos[5])
            {
                case "Basic":
                    skill.PosType = PosType.Basic;
                    break;
                case "One":
                    skill.PosType = PosType.One;
                    break;
                case "Two":
                    skill.PosType = PosType.Two;
                    break;
                case "Three":
                    skill.PosType = PosType.Three;
                    break;
            }

            skill.ColdTime = int.Parse(skillInfos[6]);
            skill.Damage = int.Parse(skillInfos[7]);

            //skillDict.Add(skill.Id, skill);
            skillList.Add(skill);
        }
    }


    public Skill GetSkillByPostype(PosType posType)
    {
        for (int i = 0; i < skillList.Count; i++)
        {
            if (skillList[i].PlayerType == PlayerInfo._Instance.PlayerType && skillList[i].PosType == posType)
            {
                return skillList[i];
            }
            
        }


        return null;
    }

}
