using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TranscriptManager : MonoBehaviour {

    public static TranscriptManager _Instance;

	[HideInInspector]
    public GameObject player;

    public List<GameObject> enemyList = new List<GameObject>();

    void Awake()
    {
        _Instance = this;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
       
    }
}
