using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericSlashAttack : MonoBehaviour {

    public Animator animator;
    public List<AnimationClip> attacks;
    public AnimationClip idle;

    public GameObject projectile;
    public GameObject cursor;

    public float minDamage;
    public float maxDamage;
    public float slashLifeSpan;
    public float slashSpeed;

    public bool createSlash;

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

    private void LateUpdate()
    {
        
        if(createSlash == true)
        {

            var newSlash = Instantiate<GameObject>(projectile);
            newSlash.GetComponent<Script_ProjectileMove>().lifeSpan = slashLifeSpan;
            newSlash.GetComponent<Script_ProjectileMove>().autoDestroy = true;
            newSlash.GetComponent<Script_ProjectileMove>().speed = slashSpeed;
            newSlash.GetComponent<Script_DealDamage>().destroyOnHit = false;
            newSlash.GetComponent<Script_DealDamage>().minDamage = minDamage;
            newSlash.GetComponent<Script_DealDamage>().maxDamage = maxDamage;
            newSlash.transform.parent = gameObject.transform;
            newSlash.transform.localPosition = Vector3.zero;
            newSlash.transform.parent = null;
            newSlash.transform.LookAt(cursor.transform.position);
            createSlash = false;

        }

    }

}