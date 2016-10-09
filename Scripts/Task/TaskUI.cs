using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TaskUI : MonoBehaviour {

    public static TaskUI _Instance;

    private UIGrid taskListGrid;

    public GameObject taskItemPrefeb;
    private TweenPosition tween;

    void Awake()
    {
        _Instance = this;

        taskListGrid = transform.Find("Bg/Scroll View/Grid").GetComponent<UIGrid>();
        tween = GetComponent<TweenPosition>();
    }

    void Start()
    {
        InitTaskList();
    }

    /// <summary>
    /// 初始化任务列表信息
    /// </summary>
    void InitTaskList()
    {
        List<Task> tasks = TaskManager._Instance.GetTaskList();


        for (int i = 0; i < tasks.Count;i++ )
        {
            GameObject go=NGUITools.AddChild(taskListGrid.gameObject, taskItemPrefeb);
            taskListGrid.AddChild(go.transform);
            TaskItemUI ui = go.GetComponent<TaskItemUI>();
            ui.SetTask(tasks[i]);
        }
    }

    public void Show()
    {
        tween.PlayForward();
    }

    public void Hide()
    {
        tween.PlayReverse();
    }

    public void OnCloseClick()
    {
        Hide();
    }


}
