using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour {

    public Image imgShot;
    public Canvas canvas;

    private PlayerController _playerController;

    private void Start() {
        _playerController = GetComponent<PlayerController>();
    //    _playerController.onMultiplierThresholdChangedCallback += UpdateAim;
    }

    public void UpdateAim( Transform target) {
        // imgShot.fillAmount = fillAmount / 10f;
        var lookPos = target.position - canvas.transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        canvas.transform.rotation = rotation;    
    }

    public void EnableAim() {
        canvas.gameObject.SetActive(true);
    }

    public void DisableAim() {
        canvas.gameObject.SetActive(false);
    }
}
