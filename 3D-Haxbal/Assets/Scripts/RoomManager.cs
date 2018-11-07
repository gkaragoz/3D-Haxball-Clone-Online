using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour {

    public static RoomManager instance;

    public bool onGame;
    public float _kalanSure;
    public int _rount;


    public GameObject player1;
    public GameObject player2;
    public GameObject ball;

    private UIManager _uIManager;

    private int Takim1GolSayisi=0;
    private int Takim2GolSayisi=0;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Start () {

       
        _uIManager = UIManager.instance;
  

    }

    void Update () {

        if (onGame)
        {
            _kalanSure -= Time.deltaTime;
            _uIManager.timeRefresh(_kalanSure);

            if (_kalanSure < 0)
            {
                _uIManager.timeRefresh("Sureniz Bitti");
                onGame = false;
            }

        }
	}

    public void Goal(PlayerController sonplayer,int GoalPostNo)
    {
        if (GoalPostNo == 1)
        {
            Takim1GolSayisi++;
        }
        else if (GoalPostNo == 2)
        {
            Takim2GolSayisi++;
        }

        _uIManager.sonucRefresh(Takim1GolSayisi,Takim2GolSayisi);

        if (sonplayer.TakimNo == GoalPostNo)
        {
            _uIManager.BilgiRefresh(sonplayer.Name+" Karşı Takıma Gol Attı");
        }
        else
        {
            _uIManager.BilgiRefresh(sonplayer.Name + " Kendi Kalesine Gol Attı");
        }



    }
}
