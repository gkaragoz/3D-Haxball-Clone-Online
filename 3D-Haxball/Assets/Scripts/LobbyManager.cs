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
        private int _currentPlayers;
        private int _maxplayers;
        private bool _pass;
        private int _distance;

        public LobbyListValues(string name, int currentPlayers, int maxplayers, bool pass, int distance)
        {
            _name = name;
            _currentPlayers = currentPlayers;
            _maxplayers = maxplayers;
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

        public int CurrentPlayers
        {
            get
            {
                return _currentPlayers;
            }

            set
            {
                _currentPlayers = value;
            }
        }

        public int Maxplayers
        {
            get
            {
                return _maxplayers;
            }

            set
            {
                _maxplayers = value;
            }
        }

        public bool Pass
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

        public int Distance
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
        _lobbyList = new List<GameObject>();

        _listValues.Add(new LobbyListValues("Cihat",1,2, true, 15));
        _listValues.Add(new LobbyListValues("Behçet", 1,5, true, 0));
        _listValues.Add(new LobbyListValues("Gökhan", 2,10, true, 62));
        _listValues.Add(new LobbyListValues("Tunay", 1,16, false, 37));
        _listValues.Add(new LobbyListValues("DEnme", 1,20, false, 2));
        _listValues.Add(new LobbyListValues("Zibil", 2,4, true, 17));
        _listValues.Add(new LobbyListValues("Cihat6",1,15, true, 27));

        RefreshList();
       
    }
    
    public void SortName()
    {
        var sortedList = _listValues.OrderBy(go => go.Name).ToList();
        if (_listValues.SequenceEqual(sortedList))
        {
            _listValues = _listValues.OrderByDescending(go => go.Name).ToList();
        }
        else {
            _listValues = sortedList;
        }
        RefreshList();
    }
    public void SortPlayer()
    {
      
        var sortedList = _listValues.OrderBy(go => (float)go.CurrentPlayers / (float)go.Maxplayers).ToList();
        if (_listValues.SequenceEqual(sortedList))
        {
            _listValues = _listValues.OrderByDescending(go => (float)go.CurrentPlayers / (float)go.Maxplayers).ToList();
        }
        else
        {
            _listValues = sortedList;
        }
        RefreshList();
    }

    public void SortPass()
    {
        var sortedList = _listValues.OrderBy(go => go.Pass).ToList();
        if (_listValues.SequenceEqual(sortedList))
        {
            _listValues = _listValues.OrderByDescending(go => go.Pass).ToList();
        }
        else
        {
            _listValues = sortedList;
        }
        RefreshList();
    }

    public void SortDistance()
    {
        var sortedList = _listValues.OrderBy(go => go.Distance).ToList();
        if (_listValues.SequenceEqual(sortedList))
        {
            _listValues = _listValues.OrderByDescending(go => go.Distance).ToList();
        }
        else
        {
            _listValues = sortedList;
        }
        RefreshList();
    }

    private void RefreshList()
    {

        foreach (var item in _lobbyList)
        {
            Destroy(item);
        }
        foreach (var item in _listValues)
        {
            GameObject LobbyList = (GameObject)Instantiate(LobbyListPrefab);
            LobbyList.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = item.Name;
            LobbyList.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = item.CurrentPlayers+"/"+item.Maxplayers;
            LobbyList.transform.GetChild(0).GetChild(2).GetComponent<Text>().text = item.Pass.ToString();
            LobbyList.transform.GetChild(0).GetChild(3).GetComponent<Text>().text = item.Distance+" km";

            LobbyList.name = item.Name;
            LobbyList.transform.SetParent(ListElement);

            LobbyList.GetComponent<Toggle>().onValueChanged.AddListener(ifselect => { if (ifselect) OnToggleValueChanged(LobbyList.GetComponent<Toggle>()); });

            _lobbyList.Add(LobbyList);
        }
    }

    private void OnToggleValueChanged(Toggle item)
    {
             Debug.Log("Name 一：" + item.name);
    }
    
}
