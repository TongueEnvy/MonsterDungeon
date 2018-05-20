using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generic_LimitVelocity : MonoBehaviour {

    public float maxVelocity;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if(gameObject.GetComponent<Rigidbody>().velocity.magnitude > maxVelocity)
        {

            gameObject.GetComponent<Rigidbody>().velocity = gameObject.GetComponent<Rigidbody>().velocity.normalized * maxVelocity;

        }

	}
}
