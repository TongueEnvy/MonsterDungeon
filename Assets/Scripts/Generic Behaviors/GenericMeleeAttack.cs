using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD:Assets/Scripts/Generic Behaviors/GenericMeleeAttack.cs
public class GenericMeleeAttack : MonoBehaviour {

=======
public class GenericMeleeAttack: MonoBehaviour {
    public bool canAttack;
>>>>>>> master:Assets/GenericMeleeAttack.cs
    public Animator animator;
    public List<AnimationClip> attacks;
    public AnimationClip idle;

    private int currentAttack = 0;

<<<<<<< HEAD:Assets/Scripts/Generic Behaviors/GenericMeleeAttack.cs
=======
    public void MeleeAttack() {
        canAttack = false;
>>>>>>> master:Assets/GenericMeleeAttack.cs
        animator.Play(attacks[currentAttack].name);
        currentAttack += 1;
        
		if (currentAttack > (attacks.Count - 1)) {
            currentAttack = 0;
        }
    }
}
