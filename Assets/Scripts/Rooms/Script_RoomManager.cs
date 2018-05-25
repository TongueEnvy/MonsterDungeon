using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Script_RoomManager: MonoBehaviour {
    public List<GameObject> enemies;
    public List<GameObject> spawners;
    public List<GameObject> doors;
    public bool isWideRoom;
    public bool isTallRoom;
    public AnimationClip doorsOpen;
    public AnimationClip doorsClose;
    public bool enemiesHaveSpawned;
    public List<Light> sceneLights;

    private void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.GetComponent<script_testMeleePlayerMove>())
        {
            
            if (other.gameObject.GetComponent<script_testMeleePlayerMove>().currentRoom != gameObject)
            {

                if (other.gameObject.GetComponent<script_testMeleePlayerMove>().currentRoom != null && other.gameObject.GetComponent<script_testMeleePlayerMove>().currentRoom.GetComponent<Script_RoomManager>().sceneLights.Count > 0) {
                    foreach (Light item in other.gameObject.GetComponent<script_testMeleePlayerMove>().currentRoom.GetComponent<Script_RoomManager>().sceneLights)
                    {

                        item.enabled = false;

                    }
                }

                foreach (GameObject item in other.gameObject.GetComponent<Generic_FamiliarTrail>().followers)
                {

                    item.GetComponent<NavMeshAgent>().enabled = false;
                    item.transform.position = gameObject.transform.position;
                    item.GetComponent<NavMeshAgent>().enabled = true;

                }
            }

            other.gameObject.GetComponent<script_testMeleePlayerMove>().currentRoom = gameObject;

            if (sceneLights.Count > 0)
            {
                foreach (Light item in sceneLights)
                {

                    item.enabled = true;

                }
            }

            if (isWideRoom == true)
            {

                other.gameObject.GetComponent<script_testMeleePlayerMove>().inWideRoom = true;

            }
            else
            {

                other.gameObject.GetComponent<script_testMeleePlayerMove>().inWideRoom = false;

            }

            if (isTallRoom == true)
            {

                other.gameObject.GetComponent<script_testMeleePlayerMove>().inTallRoom = true;

            }
            else
            {

                other.gameObject.GetComponent<script_testMeleePlayerMove>().inTallRoom = false;

            }
        }

        foreach(GameObject item in spawners)
        {
            if (item.GetComponent<Generic_SpawnEnemy>().canSpawnEnemy == true)
            {
                item.gameObject.GetComponent<Generic_SpawnEnemy>().SpawnEnemy();
                item.gameObject.GetComponent<Generic_SpawnEnemy>().spawnedEnemy.gameObject.GetComponent<Script_AddEnemyToRoom>().currentRoom = gameObject;
                enemies.Add(item.gameObject.GetComponent<Generic_SpawnEnemy>().spawnedEnemy);
            }
        }

        if(enemies.Count > 0)
        {
            foreach (GameObject item in doors)
            {
                item.gameObject.GetComponent<Animator>().Play(doorsClose.name);
            }

            enemiesHaveSpawned = true;
        }
    }

    private void LateUpdate()
    {
        if(enemies.Count == 0)
        {
            foreach (GameObject item in doors)
            {
                item.gameObject.GetComponent<Animator>().Play(doorsOpen.name);
            }

            if (enemiesHaveSpawned == true)
            {
                foreach (GameObject item in spawners)
                {

                    item.GetComponent<Generic_SpawnEnemy>().canSpawnEnemy = false;

                }
            }
        }
    }
}
