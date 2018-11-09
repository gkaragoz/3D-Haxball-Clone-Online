using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public string Name { get; set; }
    public int Gold { get; set; }
    public int SpecialMoney { get; set; }
    public int TotalGames { get; set; }
    public int WinGames { get; set; }
    public int LostGames { get; set; }

    private float _winLoseRatio;
    public float WinLoseRatio {
        get { return WinGames / LostGames; }
        set { _winLoseRatio = value; }
    }

}
