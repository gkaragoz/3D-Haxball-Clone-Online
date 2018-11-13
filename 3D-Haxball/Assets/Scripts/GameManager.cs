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
    public Room currentRoom;

    private void Start() {
        player = CreatePlayer();
        SceneInitializer.instance.InitializePreview(player);
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
        Enums.CharacterModel characterModelID = Enums.CharacterModel.Cowboy;

        float movementSpeed = 8f;
        float currentSpeed = movementSpeed;
        float kickForce = 75f;

        Player newPlayer = new Player(name, gold, specialMoney, totalGames, winGames, lostGames, characterModelID, movementSpeed, currentSpeed, kickForce);
        newPlayer.IsMe = true;

        return newPlayer;
        //}
    }

    public void StartGame() {
        Room willJoinRoom = RoomManager.instance.GetAvailableRoom();

        if (willJoinRoom == null) {
            string roomName = player.Name;
            int maxCapacity = 12;
            int raundTime = 100;
            int maxRaund = 3;

            willJoinRoom = RoomManager.instance.CreateRoom(roomName, maxCapacity, raundTime, maxRaund);
        }

        RoomManager.instance.AddPlayer(player, willJoinRoom);
        
        currentRoom = willJoinRoom;

        SceneController.instance.LoadScene("GamePlay");
    }

}
