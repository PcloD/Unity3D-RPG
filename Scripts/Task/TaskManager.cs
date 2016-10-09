using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TaskManager : MonoBehaviour {

    public static TaskManager _Instance;

    public TextAsset _taskText;

    private List<Task> taskList = new List<Task>();


    private Task currentTask;
    private PlayerAutoMove playerAutoMove;

    private PlayerAutoMove PlayerAutoMove
    {
        get {
            if (playerAutoMove == null)
            {
                playerAutoMove = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAutoMove>();
                
            }
            return playerAutoMove; 
        }
        
    }


    void Awake()
    {
        _Instance = this;

        ReadTaskList();
        //Debug.Log(taskList.Count);
    }

    void Start()
    {

    }

    /// <summary>
    /// 读取所有任务信息
    /// </summary>
    public void ReadTaskList()
    {
        string[] tasks = _taskText.ToString().Split('\n');
        for (int i = 0; i < tasks.Length;i++ )
        {
            string[] taskInfos=tasks[i].Split('|');

            Task task = new Task();

            task.Id = int.Parse(taskInfos[0]);

           
            switch (taskInfos[1])
            {
                case "Main":
                    task.TaskType = TaskType.Main;
                    break;

                case "Reward":
                    task.TaskType = TaskType.Reward;
                    break;

                case "Daily":
                    task.TaskType = TaskType.Daily;
                    break;
            }


            //名字
            task.Name = taskInfos[2];

            //图标
            task.Icon = taskInfos[3];

            //描述
            task.Des = taskInfos[4];


            //金币数量
            task.Coin = int.Parse(taskInfos[5]);

            //钻石数量
            task.Diamond = int.Parse(taskInfos[6]);

            task.TalkNpc = taskInfos[7];

            task.IdNpc = int.Parse(taskInfos[8]);

            task.IdTranscript = int.Parse(taskInfos[9]);

            taskList.Add(task);
        }
    }

    public List<Task> GetTaskList()
    {
        return taskList;
    }

    /// <summary>
    /// 执行某个任务
    /// </summary>
    /// <param name="task"></param>
    public void OnExcuteTask(Task task)
    {
        currentTask = task;

        if (task.TaskProcess==TaskProcess.NoStart)
        {
            //导航到npc 去接受任务
            PlayerAutoMove.SetDestination(NPCManager._Instance.GetNpcById(task.IdNpc).transform.position);

        }else if (task.TaskProcess==TaskProcess.Accept)
        {
            PlayerAutoMove.SetDestination(NPCManager._Instance.transport.transform.position);

        }
    }

    public void OnAcceptTask()
    {
        currentTask.TaskProcess = TaskProcess.Accept;

        //TODO 寻路到副本入口
        PlayerAutoMove.SetDestination(NPCManager._Instance.transport.transform.position);
    }

    public void OnArrived()
    {
        if (currentTask.TaskProcess == TaskProcess.NoStart)//到达NPC所在
        {
            

            NPCDialogUI._Instance.Show(currentTask.TalkNpc);
        }

        //到达副本入口
        
    }
}
