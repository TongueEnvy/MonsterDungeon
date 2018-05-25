using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_HP : MonoBehaviour {

    public float maxHP;
    public float HP;
    public bool canBeHurt;
    public float damageTimer;
    [HideInInspector] public float damageCounter;

	// Use this for initialization
	void Start () {
		
        

	}
	
	// Update is called once per frame
	void Update () {

        damageCounter -= 1;

        if(damageCounter <= 0)
        {

            canBeHurt = true;

        } 

        if (HP > maxHP){

            HP = maxHP;

        }

        if (HP  <= 0)
        {

            gameObject.GetComponent<Script_destroyed>().enabled = true;

        }

	}
}
