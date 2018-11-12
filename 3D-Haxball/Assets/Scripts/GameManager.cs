using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
   
    #region Singleton

    public static GameManager instance;

    private void Awake() {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(instance);
    }

    #endregion

    public Player player;

    private void Start() {
        player = CreatePlayer();
    }

    public Player CreatePlayer() {
        //Get Player data from Network.

        //OnPlayerData {
        //string name = data.name;
        string name = "Cihat";
        int gold = 0;
        int specialMoney = 0;
        int totalGames = 0;
        int winGames = 0;
        int lostGames = 0;
        int characterModelID = 0;

        float movementSpeed = 15f;
        float currentSpeed = movementSpeed;
        float kickForce = 10f;
        return new Player(name, gold, specialMoney, totalGames, winGames, lostGames, characterModelID, movementSpeed, currentSpeed, kickForce);
        //}
    }

    public void StartGame() {
        Room willJoinRoom = RoomManager.instance.GetAvailableRoom();

        if (willJoinRoom == null) {
            int maxCapacity = 12;
            int maxRaund = 3;
            int raundTime = 1;

            willJoinRoom = RoomManager.instance.CreateRoom(player.Name, maxCapacity, maxRaund, raundTime);
        }

        RoomManager.instance.AddPlayer(player, willJoinRoom);
        SceneController.instance.LoadScene("GamePlay");
    }

}
