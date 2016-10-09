using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{

    public static int GetRequireExpByLevel(int _level)
    {
        int exp = (_level - 1) * (100 + (100 + 10 * (_level - 2))) / 2;
        return exp;
    }
}
