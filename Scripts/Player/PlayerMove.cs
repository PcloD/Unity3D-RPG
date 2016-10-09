using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    public float moveSpeed = 5f;

    private Rigidbody rigidbody;

    public bool isInGame = false;
    public bool canMove=true;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update() 
    {
        if (canMove==false)
        {
           
            return; 
        }

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 vel = rigidbody.velocity;

        //Debug.Log(vel.y);

        //if (h!=0||v!=0||GetComponent<PlayerAutoMove>().isNaving==true)
        if (Mathf.Abs(h)>0.05f||Mathf.Abs(v)>0.05f)
        {
            //&& GetComponent<Animator>().GetCurrentAnimatorStateInfo(1).IsName("Empty State")
            if (isInGame )
            {
                //Debug.Log("InGame");
                transform.rotation = Quaternion.LookRotation(new Vector3(h, 0, v));
                rigidbody.velocity = new Vector3(h * moveSpeed, vel.y, v * moveSpeed);
                
            }
            else if(isInGame==false)
            {
                transform.rotation = Quaternion.LookRotation(new Vector3(-h, 0, -v));
                rigidbody.velocity = new Vector3(-h * moveSpeed, vel.y, -v * moveSpeed);
                
            }
            
            PlayerAnim._Instance.PlayRunAnim();
        }
        else
        {
            rigidbody.velocity = new Vector3(0, 0, 0);
            PlayerAnim._Instance.PlayIdleAnim();
        }
        
    }


    public void SetCanMove(bool canMove)
    {
        
        this.canMove = canMove;
        //Debug.Log(this.canMove);
    }
}
