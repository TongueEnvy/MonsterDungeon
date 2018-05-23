using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Generic_FamiliarTrail : MonoBehaviour {

    public GameObject leader;
    public List<GameObject> followers;

	// Use this for initialization
	void Start () {

        leader = gameObject;

	}
	
	// Update is called once per frame
	void Update () {
		
        if (followers.Count > 0)
        {

            followers[0].GetComponent<NavMeshAgent>().destination = leader.transform.position;

        }

        if(followers.Count > 1)
        {

            for (var i = 1; i < followers.Count; i += 1)
            {

                followers[i].GetComponent<NavMeshAgent>().destination = followers[i - 1].transform.position;

            }

        }

	}
}
