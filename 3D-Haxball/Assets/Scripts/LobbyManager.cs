using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class LobbyManager : MonoBehaviour
{
    public RectTransform ListElement;
    public GameObject LobbyListPrefab;

    private List<LobbyListValues> _listValues;
    private List<GameObject> _lobbyList;

    private class LobbyListValues
    {
        private string _name;
        private string _players;
        private string _pass;
        private string _distance;

        public LobbyListValues(string name, string players, string pass, string distance)
        {
            _name = name;
            _players = players;
            _pass = pass;
            _distance = distance;
        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public string Players
        {
            get
            {
                return _players;
            }

            set
            {
                _players = value;
            }
        }

        public string Pass
        {
            get
            {
                return _pass;
            }

            set
            {
                _pass = value;
            }
        }

        public string Distance
        {
            get
            {
                return _distance;
            }

            set
            {
                _distance = value;
            }
        }

    }
    private void Start()
    {

        _listValues = new List<LobbyListValues>();
        _listValues.Add(new LobbyListValues("Cihat", "15/16", "Yes", "15"));
        _listValues.Add(new LobbyListValues("Behçet", "15/16", "Yes", "15"));
        _listValues.Add(new LobbyListValues("Gökhan", "15/16", "Yes", "15"));
        _listValues.Add(new LobbyListValues("Tunay", "15/16", "No", "15"));
        _listValues.Add(new LobbyListValues("DEnme", "15/16", "No", "15"));
        _listValues.Add(new LobbyListValues("Zibil", "15/16", "No", "15"));
        _listValues.Add(new LobbyListValues("Cihat6", "15/16", "Yes", "15"));

        RefreshList(_listValues);
       

    }
    
    public void SortName()
    {
        var sortedList = _listValues.OrderBy(go => go.Name).ToList();

        RefreshList(sortedList);
       
    }

    private void RefreshList(List<LobbyListValues> sortedList)
    {
      
        foreach (var item in _listValues)
        {
            GameObject LobbyList = (GameObject)Instantiate(LobbyListPrefab);
            LobbyList.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = item.Name;
            LobbyList.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = item.Players;
            LobbyList.transform.GetChild(0).GetChild(2).GetComponent<Text>().text = item.Pass;
            LobbyList.transform.GetChild(0).GetChild(3).GetComponent<Text>().text = item.Distance;

            LobbyList.name = item.Name;
            LobbyList.transform.SetParent(ListElement);

            LobbyList.GetComponent<Toggle>().onValueChanged.AddListener(ifselect => { if (ifselect) OnToggleValueChanged(LobbyList.GetComponent<Toggle>()); });

            //_lobbyList.Add(LobbyList);
        }
    }

    private void OnToggleValueChanged(Toggle item)
    {
             Debug.Log("Name 一：" + item.name);
    }
    
}
