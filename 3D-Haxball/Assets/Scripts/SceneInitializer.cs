using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneInitializer : MonoBehaviour {

    #region Singleton

    public static SceneInitializer instance;

    private void Awake() {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    #endregion

    [Header("Initializers")]
    public GameObject playerPrefab;
    public GameObject[] modelPrefabs;
    public GameObject cameraPrefab;

    private RaundTimer _raundTimer;
    private Room _room;

    private void Start() {
        _raundTimer = GetComponent<RaundTimer>();
    }

    public void Init(Room room) {
        SceneManager.sceneLoaded += OnSceneLoaded;
        this._room = room;
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void InstantiatePlayer() {
        foreach (Player player in _room.GetAllPlayers()) {
            GameObject playerObject = Instantiate(playerPrefab, new Vector3(-10, 0, 0), Quaternion.identity);
            playerObject.GetComponent<PlayerController>().player = player;
            playerObject.name = "(Player) " + player.Name;

            SetModel(playerObject, GameManager.instance.player.CharacterModel);

            if (player.IsMe) {
                playerObject.GetComponent<PlayerController>().enabled = true;
                CameraControlller.instance.SetTarget(playerObject);
            }
        }
    }

    public void SetRaundTime() {
        _raundTimer.SetTime(_room.RaundTime);
    }

    public void SetModel(GameObject playerObject, Enums.CharacterModel model) {
        switch (model) {
            case Enums.CharacterModel.Cowboy:
            Transform parentTransform = playerObject.transform.GetChild(0);
            Instantiate(GetModelByName(model), parentTransform);
            break;
            case Enums.CharacterModel.None:
            break;
            default:
            break;
        }
    }

    private GameObject GetModelByName(Enums.CharacterModel model) {
        string modelName = model.ToString();
        foreach (GameObject prefab in modelPrefabs) {
            if (prefab.name == modelName)
                return prefab;
        }

        return modelPrefabs[0];
    }

    void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        if (scene.buildIndex == 0) {
            return;
        }

        SetRaundTime();

        InstantiatePlayer();
    }

}
