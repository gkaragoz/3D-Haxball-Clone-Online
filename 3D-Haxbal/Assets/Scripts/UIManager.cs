using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Slider aimSlider;

    public static UIManager instance;

    private void Awake() {
        if (instance == null)
            instance = this;
    }

}
