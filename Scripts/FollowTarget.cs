using UnityEngine;
using System.Collections;

public class FollowTarget : MonoBehaviour {


    public Vector3 offset;
    private Transform player;
    public bool isFollowBip=false;

	// Use this for initialization
	void Start () {
        
        if (isFollowBip)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }else
        {
            player = GameObject.FindGameObjectWithTag("Player").transform.Find("Boy/Boy Pelvis/Boy Spine");
        }
        
        //offset = transform.position - player.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = player.position + offset;
	}
}
