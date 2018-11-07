using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

   // public Slider aimSlider;
    public Text timeText;
    public Text sonucText;
    public Text bilgi;
    public static UIManager instance;

    private void Awake() {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        timeText.text = "";
        sonucText.text = "";
        bilgi.text = "";
       
    }

    internal void timeRefresh(float kalanSure)
    {
        string minutes = Mathf.Floor(kalanSure / 60).ToString("00");
        string seconds = (kalanSure % 60).ToString("00");

        timeText.text= string.Format("{0}:{1}", minutes, seconds);
    }
    internal void timeRefresh(String kalanSure)
    {
        timeText.text = kalanSure;
    }

    internal void sonucRefresh(int takim1,int takim2)
    {
        sonucText.text = string.Format("{0} - {1}", takim1, takim2);
    }

    internal void BilgiRefresh(string v)
    {
        bilgi.text = v;
    }
}
