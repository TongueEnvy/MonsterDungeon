using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generic_RadialBurst : MonoBehaviour {

    public GameObject bullet;
    public int shotNumber;
    float shotAngle;
    public float bulletSpeed;

	// Use this for initialization
	void Start () {
        shotAngle = 360 / shotNumber;
	}
	
	public void RadialBurst()
    {

        var currentShotDir = 0f;
        for(var i = 0; i < shotNumber; i += 1)
        {

            var newBullet = Instantiate<GameObject>(bullet);
            newBullet.transform.eulerAngles = new Vector3(0, currentShotDir, 0);
            newBullet.transform.position = new Vector3(transform.position.x, 1f, transform.position.z);
            newBullet.GetComponent<Script_ProjectileMove>().speed = bulletSpeed;
            currentShotDir += shotAngle;

        }

    }
}
