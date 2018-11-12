using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour {

    #region Singleton

    public static SceneController instance;

    private void Awake() {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(instance);
    }

    #endregion

    public GameObject pnlLoading;
    public Slider sliderLoading;
    public Text txtLoadingPercentage;

    public void LoadScene(string scene) {
        StartCoroutine(LoadAsynchronously(scene));
    }

    private IEnumerator LoadAsynchronously(string scene) {
        pnlLoading.SetActive(true);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Single);

        while (!asyncLoad.isDone) {
            float progress = Mathf.Clamp01(asyncLoad.progress / .9f);

            sliderLoading.value = progress;
            txtLoadingPercentage.text = "Loading.. " + progress * 100f + "%";

            yield return null;
        }

        pnlLoading.SetActive(false);
    }

    public void Exit() {
        Application.Quit();
    }

}
