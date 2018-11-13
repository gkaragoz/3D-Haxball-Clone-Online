using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RaundTimer : MonoBehaviour {

    public delegate void OnTimerEnded();
    public OnTimerEnded onTimerEndedCallback;

    [Header("Properties")]
    public int minutes = 0;
    public int seconds = 0;
    public bool isRunning = false;

    [Header("Initializers")]
    public Text _txtTime;

    private int _raundTime;
    private float _remaningTime;

    public void StartTimer() {
        if (!isRunning && _remaningTime != 0) {
            StartCoroutine(IStartTimer());
        }
    }

    public void SetTime(int seconds) {
        _raundTime = seconds;

        this.minutes = Mathf.FloorToInt(seconds / 60f);
        this.seconds = Mathf.FloorToInt(seconds % 60f);

        _remaningTime = GetInitialTime();
        _txtTime.text = this.minutes + ":" + this.seconds.ToString("00");
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

    private IEnumerator IStartTimer() {
        Debug.Log("Raund timer has been started: " + this.minutes + " minutes, " + this.seconds + " seconds");

        isRunning = true;
        _remaningTime = GetInitialTime();

        while (isRunning) {
            yield return new WaitForSeconds(1f);
            _remaningTime -= 1;

            if (_remaningTime > 0) {
                minutes = GetLeftMinutes();
                seconds = GetLeftSeconds();

                _txtTime.text = this.minutes + ":" + this.seconds.ToString("00");
            } else {
                _remaningTime = 0;
                isRunning = false;
            }

            yield return null;
        }

        if (onTimerEndedCallback != null)
            onTimerEndedCallback();
    }

}