using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NPCManager : MonoBehaviour {

    public static NPCManager _Instance;

    public GameObject[] npcList;
    private Dictionary<int, GameObject> npcDict = new Dictionary<int, GameObject>();

    //副本位置
    public Transform transport;
    void Awake()
    {
        _Instance = this;
        Init();
    }

    void Init()
    {
        for (int i = 0; i < npcList.Length;i++ )
        {
            int id=int.Parse(npcList[i].name.Substring(0, 4));
            npcDict.Add(id, npcList[i]);
        }
    }

    public GameObject GetNpcById(int id)
    {
        GameObject go = null;
        npcDict.TryGetValue(id, out go);
        return go;
    }
}
