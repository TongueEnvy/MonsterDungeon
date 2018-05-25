using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_ProjectileMove: MonoBehaviour {
    [HideInInspector] public float speed;
    Rigidbody rb;
    public bool autoDestroy;
    public float lifeSpan;
    float lifeCounter;
    
	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody>();
        lifeCounter = lifeSpan;
    }
	

	// Update is called once per frame
	void Update () {
        rb.velocity = (transform.forward * speed);
        lifeCounter -= Time.deltaTime;

        if(lifeCounter <= 0 && autoDestroy == true)
        {
            Destroy(gameObject);
        }
	}
}
