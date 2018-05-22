using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_RoomManager: MonoBehaviour {
    public List<GameObject> enemies;
    public List<GameObject> spawners;
    public List<GameObject> doors;
    public bool isWideRoom;
    public bool isTallRoom;
    public AnimationClip doorsOpen;
    public AnimationClip doorsClose;
    public bool enemiesHaveSpawned;

    private void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.GetComponent<script_testMeleePlayerMove>())
        {
            other.gameObject.GetComponent<script_testMeleePlayerMove>().currentRoom = gameObject;
<<<<<<< HEAD:Assets/Scripts/Script_RoomManager.cs
            if(isWideRoom == true)
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

=======
>>>>>>> d88c5238c80bc271e7169dbf236ee73fa3ca17e1:Assets/Scripts/Rooms/Script_RoomManager.cs
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
