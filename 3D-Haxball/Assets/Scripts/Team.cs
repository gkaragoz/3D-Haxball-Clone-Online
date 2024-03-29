﻿using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Team {

    [Header("Team Properties")]
    [SerializeField]
    private List<Player> _allPlayers = new List<Player>();
    [SerializeField]
    private string _name;
    [SerializeField]
    private int _maxCapacity;
    [SerializeField]
    private int _currentCapacity;
    [SerializeField]
    private int _score;
    [SerializeField]
    private bool _isStarter;

    public List<Player> AllPlayers {
        get { return _allPlayers; }
        set { _allPlayers = value; }
    }
        
    public string Name {
        get { return _name; }
        set { _name = value; }
    }

    public int MaxCapacity {
        get { return _maxCapacity; }
        set { _maxCapacity = value; }
    }

    public int Score {
        get { return _score; }
        set { _score = value; }
    }

    public bool IsStarter {
        get { return _isStarter; }
        set { _isStarter = value; }
    }

    public int CurrentCapacity {
        get { return _currentCapacity; }
        set { _currentCapacity = value; }
    }

    public Team(string name, bool isStarter, int maxCapacity) {
        this.Name = name;
        this.AllPlayers = new List<Player>();
        this.Score = 0;
        this.IsStarter = isStarter;
        this.MaxCapacity = maxCapacity;
        this.CurrentCapacity = 0;
    }

    public void AddPlayer(Player player) {
        player.Team = this;
        AllPlayers.Add(player);
        CurrentCapacity++;
    }

    public void RemovePlayer(Player player) {
        player.Team = null;
        AllPlayers.Remove(player);
        CurrentCapacity--;
    }

    public int GetTotalPlayers() {
        return AllPlayers.Count;
    }

    public bool IsTeamFull() {
        return CurrentCapacity >= MaxCapacity ? true : false;
    }

    public int GetMaxCapacity() {
        return MaxCapacity;
    }

}
