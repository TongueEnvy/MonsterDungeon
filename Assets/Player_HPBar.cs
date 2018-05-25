using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_HPBar : MonoBehaviour {

    Vector3 startPos;
    public GameObject HPBar;

	// Use this for initialization
	void Start () {
        


	}
	
	// Update is called once per frame
	void Update () {

        var currentHP = gameObject.GetComponent<Script_HP>().HP;
        var maxHP = gameObject.GetComponent<Script_HP>().maxHP;

        HPBar.transform.localPosition = new Vector3(0 , -1 + (currentHP / maxHP), 0);


    }
}
