using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_MeleeMonsterAttack: MonoBehaviour {
    public Animator animator;
    public List<AnimationClip> attacks;
    public bool canAttack;

	private int currentAttack = 0;
	
	public void Attack() {
        animator.Play(attacks[currentAttack].name);
        currentAttack += 1;
		
        if (currentAttack > (attacks.Count - 1)) {
            currentAttack = 0;
        }
    }
}
