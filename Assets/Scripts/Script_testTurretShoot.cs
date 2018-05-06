using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_testTurretShoot : MonoBehaviour {

    public GameObject bullet;
    public GameObject bulletSource;

    public int bulletDamage;

    public float bulletSpeed;
    public float shotDelay;

    float shotTimer;

	// Use this for initialization
	void Start () {

        shotTimer = shotDelay;

	}
	
	// Update is called once per frame
	void Update () {

        shotTimer -= Time.deltaTime;

        if(shotTimer <= 0) {

            var newBullet = Instantiate<GameObject>(bullet);
            newBullet.transform.position = bulletSource.transform.position;
            newBullet.transform.rotation = bulletSource.transform.rotation;

            newBullet.GetComponent<Script_ProjectileMove>().speed = bulletSpeed;
            newBullet.GetComponent<Script_playerTakeDamage>().damageValue = bulletDamage;
            newBullet.GetComponent<Script_playerTakeDamage>().destroyOnHit = true;

            shotTimer = shotDelay;

        }

	}
}
