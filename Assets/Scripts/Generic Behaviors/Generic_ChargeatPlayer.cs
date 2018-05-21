using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generic_ChargeatPlayer : MonoBehaviour {

    public string playerName;
    GameObject player;
    public float chargeSpeed;
    public float chargeDelay;
    float chargeCounter;

	// Use this for initialization
	void Start () {

        player = GameObject.Find(playerName);
        chargeCounter = chargeDelay;

	}
	
	// Update is called once per frame
	void Update () {

        chargeCounter -= Time.deltaTime;

        if(chargeCounter <= 0)
        {

            var chargeDir = player.transform.position - transform.position;
            gameObject.GetComponent<Rigidbody>().velocity = (chargeDir.normalized * chargeSpeed);
            chargeCounter = chargeDelay;

        }

	}
}
