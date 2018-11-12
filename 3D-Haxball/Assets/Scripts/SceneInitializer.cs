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

    public void InstantiatePlayer() {
        foreach (Player player in GameManager.instance.currentRoom.GetAllPlayers()) {
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

    private void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        if (scene.buildIndex == 0) {
            return;
        }

        InstantiatePlayer();

        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

}
