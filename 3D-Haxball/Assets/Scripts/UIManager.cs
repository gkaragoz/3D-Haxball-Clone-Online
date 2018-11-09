using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public static UIManager instance;

    public Image imgShot;

    private PlayerController playerController;

    private void Awake() {
        if (instance == null)
            instance = this;
    }

    private void Start() {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        playerController.onMultiplierThresholdChangedCallback += UpdateAim;
    }

    private void UpdateAim(float fillAmount, float rotationAmount) {
        imgShot.fillAmount = fillAmount / 10f;
        imgShot.rectTransform.localEulerAngles = Vector3.forward * rotationAmount;
    }

    public void EnableAim() {
        imgShot.gameObject.SetActive(true);
    }

    public void DisableAim() {
        imgShot.gameObject.SetActive(false);
    }
}
