﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Reseed : MonoBehaviour {

	// Use this for initialization
	void Start () {

        Random.InitState((int)System.DateTime.Now.Ticks);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}