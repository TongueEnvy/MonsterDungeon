using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericMeleeAttack : MonoBehaviour {

    public Animator animator;
    public List<AnimationClip> attacks;
    public AnimationClip idle;

    int currentAttack;

    public void MeleeAttack()
    {

        animator.Play(attacks[currentAttack].name);
        currentAttack += 1;
        if (currentAttack > (attacks.Count - 1))
        {

            currentAttack = 0;

        }

    }
}
