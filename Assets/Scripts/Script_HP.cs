using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_HP : MonoBehaviour {

    public float HP;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if (HP  <= 0)
        {

            gameObject.GetComponent<Script_destroyed>().enabled = true;

        }

	}
}
