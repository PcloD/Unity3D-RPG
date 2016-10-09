using UnityEngine;
using System.Collections;

public enum SkillType
{
    Basic,
    Skill
}

public enum PosType
{
    Basic,
    One,
    Two,
    Three
}

public class Skill {

    private int id;
    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    private string name;
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    private string icon;
    public string Icon
    {
        get { return icon; }
        set { icon = value; }
    }

    private PlayerType playerType;
    public PlayerType PlayerType
    {
        get { return playerType; }
        set { playerType = value; }
    }

    private SkillType skillType;
    public SkillType SkillType
    {
        get { return skillType; }
        set { skillType = value; }
    }

    private PosType posType;
    public PosType PosType
    {
        get { return posType; }
        set { posType = value; }
    }

    private int coldTime;
    public int ColdTime
    {
        get { return coldTime; }
        set { coldTime = value; }
    }

    private int damage;
    public int Damage
    {
        get { return damage; }
        set { damage = value; }
    }

    private int level = 1;
    public int Level
    {
        get { return level; }
        set { level = value; }
    }
	
    public void UpgradeSkill()
    {
        Level++;
    }
}
