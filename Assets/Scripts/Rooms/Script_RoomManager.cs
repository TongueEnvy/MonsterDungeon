using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_RoomManager: MonoBehaviour {
    public List<GameObject> enemies;
    public List<GameObject> spawners;
    public List<GameObject> doors;
    public AnimationClip doorsOpen;
    public AnimationClip doorsClose;

    private void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.GetComponent<script_testMeleePlayerMove>())
        {
            other.gameObject.GetComponent<script_testMeleePlayerMove>().currentRoom = gameObject;
        }

        foreach(GameObject item in spawners)
        {
            item.gameObject.GetComponent<Generic_SpawnEnemy>().SpawnEnemy();
            item.gameObject.GetComponent<Generic_SpawnEnemy>().spawnedEnemy.gameObject.GetComponent<Script_AddEnemyToRoom>().currentRoom = gameObject;
            enemies.Add(item.gameObject.GetComponent<Generic_SpawnEnemy>().spawnedEnemy);
        }

        if(enemies.Count > 0)
        {
            foreach (GameObject item in doors)
            {
                item.gameObject.GetComponent<Animator>().Play(doorsClose.name);
            }
        }
    }

    private void Update()
    {
        if(enemies.Count == 0)
        {
            foreach (GameObject item in doors)
            {
                item.gameObject.GetComponent<Animator>().Play(doorsOpen.name);
            }
        }
    }
}
