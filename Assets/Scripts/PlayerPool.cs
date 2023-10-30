using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPool : MonoBehaviour
{
    
    int playerCount = default;
    int alienCount = default;
    public int AlienCount
    {
        get { return alienCount; }
        set { alienCount = value; }
    }
    public int PlayerCount
    {
        get { return playerCount; }
        set { playerCount = value; }
    }
    
}
