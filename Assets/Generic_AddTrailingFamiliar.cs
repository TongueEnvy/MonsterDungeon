using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Generic_AddTrailingFamiliar : MonoBehaviour {

    public GameObject familiar;
    public List<GameObject> intendedLeaders;

	public void AddFamiliar()
    {

        var newFamiliar = Instantiate<GameObject>(familiar);
        var leader = intendedLeaders[Random.Range(0, intendedLeaders.Count)];
        leader.GetComponent<Generic_FamiliarTrail>().followers.Add(newFamiliar);
        newFamiliar.GetComponent<NavMeshAgent>().enabled = false;
        newFamiliar.transform.position = leader.transform.position;
        newFamiliar.GetComponent<NavMeshAgent>().enabled = true;

    }
}
