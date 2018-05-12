using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_characterNewtonAttack : MonoBehaviour {

    Animator animator;

    public bool canAttack;
    public List<AnimationClip> attacks;
    int currentAttack;

	// Use this for initialization
	void Start () {

        animator = gameObject.GetComponent<Animator>();
        currentAttack = 0;

	}
	
	// Update is called once per frame
	void Update () {
		
        if(Input.GetAxisRaw("Attack 1") > 0 && canAttack == true){

            gameObject.GetComponent<GenericMeleeAttack>();

        }
	}
}
