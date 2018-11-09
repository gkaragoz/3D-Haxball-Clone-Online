﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour {

    public static RoomManager instance;

    private void Awake() {
        if (instance == null)
            instance = this;
    }
}
