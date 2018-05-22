using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_characterNewtonAttack: MonoBehaviour {
    public bool canAttack;

	// Update is called once per frame
	void Update() {
        if((Input.GetAxisRaw("Attack 1") > 0) && (canAttack == true)) {
            gameObject.GetComponent<GenericSlashAttack>().MeleeAttack();
        }
	}
}
