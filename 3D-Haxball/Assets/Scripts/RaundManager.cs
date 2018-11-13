using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class RaundManager : MonoBehaviour {

    #region Singleton

    public static RaundManager instance;

    private void Awake() {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    #endregion

    [Header("Initializer")]
    public float delayBetweenRaunds = 1f;
    public GameObject HUD;

    [Header("Properties")]
    [SerializeField]
    private int _currentRaund;
    [SerializeField]
    private Room _room;
    private RaundTimer _raundTimer;

    public int CurrentRaund {
        get { return _currentRaund; }
        set { _currentRaund = value; }
    }

    private void Start() {
        _raundTimer = GetComponent<RaundTimer>();
        HUD.SetActive(false);
    }

    public void StartRaund() {
        if (!_raundTimer.isRunning) {
            SetNextRaund();

            if (!IsGameFinished()) {
                _room.IsPlaying = true;
                Debug.Log("Raund " + CurrentRaund + "/" + _room.MaxRaund + " has started.");
                _raundTimer.StartTimer();
            } else {
                Debug.Log("Game has been finished.");
                _room.IsPlaying = false;
            }
        }
    }

    public IEnumerator StartNextRaund(float delay) {
        Debug.Log("Next raund will start in " + delay);
        yield return new WaitForSeconds(delay);

        StartRaund();
    }

    public void SetNextRaund() {
        CurrentRaund++;
        ResetRaundTime();
    }

    public bool IsGameFinished() {
        return CurrentRaund > _room.MaxRaund ? true : false;
    }

    private void OnTimerEnded() {
        Debug.Log("Raund " + CurrentRaund + "/" + _room.MaxRaund + " ended.");
        StartCoroutine(StartNextRaund(delayBetweenRaunds));
    }

    private void ResetRaundTime() {
        _raundTimer.SetTime(_room.RaundTime);
    }

    private void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        if (scene.buildIndex == 0)
            return;

        _room = GameManager.instance.currentRoom;
        
        _raundTimer.onTimerEndedCallback += OnTimerEnded;
        ResetRaundTime();

        HUD.SetActive(true);

        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnDisable() {
        _raundTimer.onTimerEndedCallback -= OnTimerEnded;
    }

}
