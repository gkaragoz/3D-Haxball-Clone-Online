using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour {

    public static RoomManager instance;

    private void Awake() {
        if (instance == null)
            instance = this;
    }
<<<<<<< HEAD
=======

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

        ball.GetComponent<BallController>().SetStartPosition();
        //  player1.GetComponent<PlayerController>().SetStartPosition();
        player1.GetComponent<PlayerController>().SetStartPosition();
        player2.GetComponent<PlayerController>().SetStartPosition();
        sonplayer.SetStartPosition();
    }
>>>>>>> 72738b6854dcf22502b32a30873dd5b36ba1fd20
}
