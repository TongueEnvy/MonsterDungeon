using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_testMeleePlayerAttack : MonoBehaviour {

    Animator animator;

    public bool canAttack;
    public List<AnimationClip> attacks;
    int currentAttack;

	// Use this for initialization
	void Start () {
        
        currentAttack = 0;

	}
	
	// Update is called once per frame
	void Update () {
		
        if(Input.GetAxisRaw("Attack 1") > 0 && canAttack == true){

            canAttack = false;
            animator.Play(attacks[currentAttack].name);
            currentAttack += 1;
            if (currentAttack > (attacks.Count - 1))
            {

                currentAttack = 0;

            }

        }
	}
}
