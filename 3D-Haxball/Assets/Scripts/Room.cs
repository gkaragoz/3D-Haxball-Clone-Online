using System.Collections.Generic;

public class Room {

    public string Name { get; set; }
    public int MaxCapacity { get; set; }
    public int CurrentCapacity { get; set; }
    public int MaxRound { get; set; }
    public Raund[] AllRaunds { get; set; }
    public Raund CurrentRaund { get; set; }
    public Team RedTeam { get; set; }
    public Team BlueTeam { get; set; }
    public bool IsPlaying { get; set; }

    public Room(string name, int maxCapacity, 
        int currentCapacity, int maxRound, Raund[] allRaunds, int raundTime, Team redTeam, Team blueTeam) {

        this.Name = name;
        this.MaxCapacity = maxCapacity;
        this.CurrentCapacity = currentCapacity;
        this.MaxRound = maxRound;
        this.AllRaunds = allRaunds;
        this.CurrentRaund = new Raund(raundTime);
        this.RedTeam = redTeam;
        this.BlueTeam = blueTeam;
        this.IsPlaying = false;
    }

    public void KickPlayer(Team team, Player player) {
        team.RemovePlayer(player);
    }

    public void PlayerJoin(Team team, Player player) {
        team.AddPlayer(player);
    }

    public void StartRound() {
        IsPlaying = true;
    }

    public void StopRaund() {
        IsPlaying = false;
    }

    public void NextRaund() {
        for (int ii = 0; ii < AllRaunds.Length; ii++) {

        }
    }
}
