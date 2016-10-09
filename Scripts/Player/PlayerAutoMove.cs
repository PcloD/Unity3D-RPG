using UnityEngine;
using System.Collections;

public class PlayerAutoMove : MonoBehaviour {

    private NavMeshAgent agent;
    public bool isNaving = false;
    public float minDistnce = 2f;
	// Use this for initialization
	void Start () {
        agent = this.GetComponent<NavMeshAgent>();
	}
	
    /// <summary>
    /// 设置目标
    /// </summary>
    public void SetDestination(Vector3 targetPos)
    {
        //print("run");

        PlayerAnim._Instance.PlayRunAnim();
        isNaving = true;
        agent.enabled = true;
        agent.SetDestination(targetPos);

        //Debug.Log(targetPos);
    }

    /// <summary>
    /// 到达目标位置
    /// </summary>
    public void ArraiveStopDestination()
    {
        if (agent.enabled&&isNaving==true)
        {
            //正在寻路
            if (agent.remainingDistance < minDistnce&&agent.remainingDistance!=0)
            {
                //Debug.Log(agent.remainingDistance);

                PlayerAnim._Instance.PlayIdleAnim();
                TaskManager._Instance.OnArrived();
                //停止导航
                agent.Stop();
                MessageManager._Instance.ShowMessage("到达目标位置");
                isNaving = false;
                agent.enabled = false;
            }

        }
    }

    public void StopAutoMove()
    {
        if (agent.enabled)
        {
            MessageManager._Instance.ShowMessage("停止寻路");
            agent.Stop();
            isNaving = false;
            agent.enabled = false;
        }
    }

	// Update is called once per frame
	void Update () {
        if (isNaving)
        {
            ArraiveStopDestination();
        }

         float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if (Mathf.Abs(h)>0.05f||Mathf.Abs(v)>0.05f)
        {
            StopAutoMove();
        }
        


        //if (Input.GetMouseButtonDown(0))
        //{
        //    Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hit;

        //    Vector3 pos=Vector3.zero;

        //    if (Physics.Raycast(ray,out hit,1000))
        //    {
        //        //Debug.Log(hit.transform.tag);
        //        //Debug.DrawLine(ray.origin, hit.point, Color.red, 2);

        //        if (hit.transform.tag=="Ground")
        //        {
        //            pos=hit.point;
        //            SetDestination(pos);
        //        }
                
        //    }
           
        //}
        
        
	}
}
