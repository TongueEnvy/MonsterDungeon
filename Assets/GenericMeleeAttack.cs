using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericMeleeAttack: MonoBehaviour {
    public bool canAttack;
    public Animator animator;
    public List<AnimationClip> attacks;

    private int currentAttack = 0;

    public void MeleeAttack() {
        canAttack = false;
        animator.Play(attacks[currentAttack].name);
        currentAttack += 1;
        
		if (currentAttack > (attacks.Count - 1)) {
            currentAttack = 0;
        }
    }
}
