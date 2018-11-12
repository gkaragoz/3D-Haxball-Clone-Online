using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player : CharacterStats {

    [Header("Player Profile")]
    [SerializeField]
    private string _name;
    [SerializeField]
    private int _gold;
    [SerializeField]
    private int _specialMoney;
    [SerializeField]
    private int _totalGames;
    [SerializeField]
    private int _winGames;
    [SerializeField]
    private int _lostGames;
    [SerializeField]
    private float _winLoseRatio;
    [SerializeField]
    private int characterModelID;

    public string Name {
        get { return _name; }
        set { _name = value; }
    }

    public int Gold {
        get { return _gold; }
        set { _gold = value; }
    }
    
    public int SpecialMoney {
        get { return _specialMoney; }
        set { _specialMoney = value; }
    }

    public int TotalGames {
        get { return _totalGames; }
        set { _totalGames = value; }
    }

    public int WinGames {
        get { return _winGames; }
        set { _winGames = value; }
    }

    public int LostGames {
        get { return _lostGames; }
        set { _lostGames = value; }
    }

    public float WinLoseRatio {
        get { return WinGames / LostGames;}
        set { _winLoseRatio = value; }
    }

    public int CharacterModelID {
        get { return characterModelID; }
        set { characterModelID = value; }
    }

    public Player(string name, 
                        int gold, 
                        int specialMoney, 
                        int totalGames, 
                        int winGames, 
                        int lostGames,
                        int characterModelID,
                        float movementSpeed,
                        float currentSpeed,
                        float kickForce) : base (movementSpeed, currentSpeed, kickForce) {
        this.Name = name;
        this.Gold = gold;
        this.SpecialMoney = specialMoney;
        this.TotalGames = totalGames;
        this.WinGames = winGames;
        this.LostGames = lostGames;
        this.CharacterModelID = characterModelID;
    }
}
