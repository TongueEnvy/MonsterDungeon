using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generic_ShootatPlayer : MonoBehaviour {

    public string playerName;
    GameObject player;
    public GameObject bullet;
    public float shotSpeed;
    public float shotDelay;
    float shotCounter;

	// Use this for initialization
	void Start () {

        player = GameObject.Find(playerName);
        shotCounter = shotDelay;

	}
	
	// Update is called once per frame
	void Update () {

        shotCounter -= Time.deltaTime;

        if(shotCounter <= 0)
        {

            var newBullet = Instantiate<GameObject>(bullet);
            newBullet.transform.localPosition = new Vector3(transform.position.x, .5f, transform.position.z);
            newBullet.transform.LookAt (new Vector3(player.transform.position.x,.5f, player.transform.position.z));
            newBullet.GetComponent<Script_ProjectileMove>().speed = shotSpeed;
            shotCounter = shotDelay;

        }

	}
}
