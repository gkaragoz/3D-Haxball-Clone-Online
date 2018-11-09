using System.Collections.Generic;

public class Team {

    public List<Player> allPlayers { get; set; }

    private int _maxCapacity;
    private int _currentCapacity;
    private int _score;
    private bool _isStarter;

    public int Score {
        get { return _score; }
        set { _score = value; }
    }

    public bool IsStarter {
        get { return _isStarter; }
        set { _isStarter = value; }
    }

    public int CurrentCapactiy {
        get { return _currentCapacity; }
        set { _currentCapacity = value; }
    }

    public Team(List<Player> allPlayers, int score, bool isStarter, int maxCapacity) {
        this.allPlayers = allPlayers;
        this.Score = score;
        this.IsStarter = isStarter;
        this._maxCapacity = maxCapacity;
        this.CurrentCapactiy = 0;
    }

    public void AddPlayer(Player player) {
        allPlayers.Add(player);
        CurrentCapactiy++;
    }

    public void RemovePlayer(Player player) {
        allPlayers.Remove(player);
        CurrentCapactiy--;
    }

    public int GetTotalPlayers() {
        return allPlayers.Count;
    }

    public bool IsTeamFull() {
        return _currentCapacity >= _maxCapacity ? true : false;
    }

    public int GetMaxCapacity() {
        return _maxCapacity;
    }

}
