using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoomManager : MonoBehaviour {

    #region Singleton

    public static RoomManager instance;

    private void Awake() {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(instance);
    }

    #endregion

    public List<Room> allRooms = new List<Room>();

    public Room CreateRoom(string name, 
                           int maxCapacity,
                           int maxRaund, 
                           int raundTime = 3) {

        Room room = new Room(name, maxCapacity, maxRaund, raundTime);
        allRooms.Add(room);

        return room; 
    }

    public void AddPlayer(Player player, Room room) {
        Team team = room.GetAvailableTeam();
        if (team == null) {
            //Add as a spectator.
        } else {
            room.JoinPlayer(team, player);
        }
    }

    public Room GetAvailableRoom() {
        foreach (Room room in allRooms) {
            if (room.IsAvailable()) {
                return room;
            }
        }
        return null;
    }

}
