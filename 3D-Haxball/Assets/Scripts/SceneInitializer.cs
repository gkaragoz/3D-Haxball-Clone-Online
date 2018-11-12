using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneInitializer : MonoBehaviour {

    public GameObject playerObject;
    public GameObject playerPrefab;
    public Transform playerSpawnPoint;

    public GameObject[] modelPrefabs;

    private void Start() {
        InstantiatePlayer(GameManager.instance.player);
    }

    public void InstantiatePlayer(Player player) {
        playerObject = Instantiate(playerPrefab, playerSpawnPoint.position, Quaternion.identity);
        playerObject.GetComponent<PlayerController>().player = player;

        SetModel(playerObject, GameManager.instance.player.CharacterModel);
        CameraControlller.instance.SetTarget(playerObject);
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

}
