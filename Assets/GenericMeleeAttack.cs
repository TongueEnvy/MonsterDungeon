﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericMeleeAttack : MonoBehaviour {

    public bool canAttack;
    public Animator animator;
    public List<AnimationClip> attacks;

    int currentAttack;

    public void MeleeAttack()
    {

        canAttack = false;
        animator.Play(attacks[currentAttack].name);
        currentAttack += 1;
        if (currentAttack > (attacks.Count - 1))
        {

            currentAttack = 0;

        }

    }
}
