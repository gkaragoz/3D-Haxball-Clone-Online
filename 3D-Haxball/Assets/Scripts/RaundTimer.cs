using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RaundTimer : MonoBehaviour {

    [Header("Properties")]
    public int minutes = 0;
    public int seconds = 0;
    public bool isRunning = false;

    [Header("Initializers")]
    public Text _txtTime;

    private float _remaningTime;
    private int _timeSeconds;

    public void StartTimer() {
        StartCoroutine(IStartTimer());
    }

    public IEnumerator IStartTimer() {
        Debug.Log("Raund timer has been started: " + minutes + " minutes, " + seconds + " seconds");

        isRunning = true;
        _remaningTime = GetInitialTime();

        while (isRunning && _remaningTime > 0f) {
            _remaningTime -= Time.deltaTime;
            minutes = GetLeftMinutes();
            seconds = GetLeftSeconds();

            if (_remaningTime > 0)
                _txtTime.text = minutes + ":" + seconds.ToString("00");

            yield return null;
        }

        _remaningTime = 0;
        isRunning = false;
    }

    public void SetTime(int seconds) {
        _timeSeconds = seconds;
        _remaningTime = _timeSeconds;

        minutes = Mathf.FloorToInt(seconds / 60f);
        seconds = Mathf.FloorToInt(seconds % 60f);
    }

    public bool IsTimerFinished() {
        return _remaningTime <= 0 ? true : false;
    }

    private float GetInitialTime() {
        return minutes * 60f + seconds;
    }

    private int GetLeftMinutes() {
        return Mathf.FloorToInt(_remaningTime / 60f);
    }

    private int GetLeftSeconds() {
        return Mathf.FloorToInt(_remaningTime % 60f);
    }
}