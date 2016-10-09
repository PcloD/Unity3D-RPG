using UnityEngine;
using System.Collections;

public enum TaskType
{
    Main,//主线
    Reward,//赏金
    Daily//日常
}

public enum TaskProcess
{
    NoStart,
    Accept,
    Complete,
    Reword
}


public class Task
{

    private int id;
    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    private TaskType taskType;
    public TaskType TaskType
    {
        get { return taskType; }
        set { taskType = value; }
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

    private string des;
        public string Des
    {
        get { return des; }
        set { des = value; }
    }

    private int coin;
    public int Coin
    {
        get { return coin; }
        set { coin = value; }
    }

    private int diamond;
        public int Diamond
    {
        get { return diamond; }
        set { diamond = value; }
    }

    private string talkNpc;
        public string TalkNpc
    {
        get { return talkNpc; }
        set { talkNpc = value; }
    }

    private int idNpc;
        public int IdNpc
    {
        get { return idNpc; }
        set { idNpc = value; }
    }

    private int idTranscript;
    public int IdTranscript
    {
        get { return idTranscript; }
        set { idTranscript = value; }
    }

    private TaskProcess taskProcess = TaskProcess.NoStart;
    public TaskProcess TaskProcess
    {
        get { return taskProcess; }
        set { 
            if (taskProcess!=value)
            {
                taskProcess = value;
                this.OnTaskChangeEvent();
            }

            
        }
    }

    public delegate void OnTaskChange();
    public event OnTaskChange OnTaskChangeEvent;
}
