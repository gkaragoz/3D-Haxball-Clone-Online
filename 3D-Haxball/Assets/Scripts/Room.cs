using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class Room {

    [Header("Room Properties")]
    [SerializeField]
    private string _name;
    [SerializeField]
    private int _maxCapacity;
    [SerializeField]
    private int _currentCapacity;
    [SerializeField]
    private int _raundTime;
    [SerializeField]
    private int _maxRaund;
    [SerializeField]
    private Team _redTeam;
    [SerializeField]
    private Team _blueTeam;
    [SerializeField]
    private bool _isPlaying;

    public string Name {
        get { return _name; }
        set { _name = value; }
    }

    public int MaxCapacity {
        get { return _maxCapacity; }
        set { _maxCapacity = value; }
    }

    public int CurrentCapacity {
        get { return _currentCapacity; }
        set { _currentCapacity = value; }
    }

    public int RaundTime {
        get { return _raundTime; }
        set { _raundTime = value; }
    }

    public int MaxRaund {
        get { return _maxRaund; }
        set { _maxRaund = value; }
    }

    public Team RedTeam {
        get { return _redTeam; }
        set { _redTeam = value; }
    }

    public Team BlueTeam {
        get { return _blueTeam; }
        set { _blueTeam = value; }
    }

    public bool IsPlaying {
        get { return _isPlaying; }
        set { _isPlaying = value; }
    }

    public Room(string name, int maxCapacity, int raundTime, int maxRaund) {
        this.Name = name + "'s Room";
        this.MaxCapacity = maxCapacity;
        this.RaundTime = raundTime;
        this.MaxRaund = maxRaund;
        this.CurrentCapacity = 0;
        this.RedTeam = new Team("Red", true, maxCapacity);
        this.BlueTeam = new Team("Blue", false, maxCapacity);
        this.IsPlaying = false;
    }

    public void KickPlayer(Team team, Player player) {
        player.Room = null;
        team.RemovePlayer(player);
        CurrentCapacity--;
    }

    public void JoinPlayer(Team team, Player player) {
        player.Room = this;
        team.AddPlayer(player);
        CurrentCapacity++;
    }

    public bool IsAvailable() {
        return CurrentCapacity >= MaxCapacity ? false : true;
    }

    public Team GetAvailableTeam() {
        if (BlueTeam.CurrentCapacity >= RedTeam.CurrentCapacity && !RedTeam.IsTeamFull()) {
            return RedTeam;
        } else if (!BlueTeam.IsTeamFull()){
            return BlueTeam;
        } else {
            return null;
        }
    }

    public List<Player> GetAllPlayers() {
        return new List<Player>().Concat(RedTeam.AllPlayers)
                                    .Concat(BlueTeam.AllPlayers)
                                    .ToList();
    }

}
