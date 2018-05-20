using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Script_MeleeEnemyWalk: MonoBehaviour {
    public float walkSpeed;
    public float stopRange;
    public List<GameObject> players;
    public GameObject target;
    public GameObject upperBody;
    public bool canAttack;

    private NavMeshAgent navAgent;

	void Start() {
        navAgent = GetComponent<NavMeshAgent>();

        if (players.Count > 0) {
            var chooseTarget = Random.Range(0, players.Count-1);
            target = players[chooseTarget];
        }
	}
	
	void Update() {
        navAgent.destination = target.transform.position;
        if(Vector3.Distance(target.transform.localPosition,
							transform.localPosition
							) <= stopRange) {
            navAgent.speed = 0;
            transform.LookAt(target.transform.position);
            upperBody.GetComponent<GenericMeleeAttack>().MeleeAttack();
        }
<<<<<<< HEAD
        else
        {

            canAttack = true;
=======
		
        else {
>>>>>>> master
            navAgent.speed = walkSpeed;
            transform.LookAt(new Vector3(transform.position.x + navAgent.desiredVelocity.x, 0, transform.position.z + navAgent.desiredVelocity.z));
        }

	}
}
