using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour {

    public Image imgShot;
    public Canvas canvas;

    private PlayerController _playerController;

    private void Start() {
        _playerController = GetComponent<PlayerController>();
        _playerController.onMultiplierThresholdChangedCallback += UpdateAim;
    }

    private void UpdateAim(float fillAmount, float rotationAmount) {
        imgShot.fillAmount = fillAmount / 10f;
        imgShot.rectTransform.localEulerAngles = Vector3.forward * rotationAmount;
    }

    public void EnableAim() {
        canvas.gameObject.SetActive(true);
    }

    public void DisableAim() {
        canvas.gameObject.SetActive(false);
    }
}
