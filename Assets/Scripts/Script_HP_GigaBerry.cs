using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_HP_GigaBerry : MonoBehaviour {

    public float HP;
    public bool canBeHurt;
    public List<GameObject> granules;
    public List<GameObject> berries;
    float burstGranule;
    [HideInInspector] public float trackDamage;
    public float damageTimer;
    [HideInInspector] public float damageCounter;

	// Use this for initialization
	void Start () {

        burstGranule = HP / (granules.Count);

	}
	
	// Update is called once per frame
	void Update () {

        while(trackDamage > burstGranule)
        {

            trackDamage -= burstGranule;
            var berryToSpawn = Random.Range(0, berries.Count);
            var newBerry = Instantiate<GameObject>(berries[berryToSpawn]);
            newBerry.transform.parent = gameObject.transform;
            newBerry.transform.localPosition = new Vector3(0, 0, 0);
            newBerry.transform.parent = null;
            newBerry.GetComponent<Script_AddEnemyToRoom>().currentRoom = gameObject.GetComponent<Script_AddEnemyToRoom>().currentRoom;
            gameObject.GetComponent<Script_AddEnemyToRoom>().currentRoom.GetComponent<Script_RoomManager>().enemies.Add(newBerry);
            var granuleToBurst = granules[Random.Range(0, granules.Count)];
            granules.Remove(granuleToBurst);
            Destroy(granuleToBurst);

        }

        damageCounter -= 1;

        if(damageCounter <= 0)
        {

            canBeHurt = true;

        } 

        if (HP  <= 0)
        {

            gameObject.GetComponent<Script_destroyed>().enabled = true;

        }

	}
}
