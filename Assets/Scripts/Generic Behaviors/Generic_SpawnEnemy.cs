using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generic_SpawnEnemy : MonoBehaviour {

    public List<GameObject> possibleEnemies;
    [HideInInspector] public GameObject spawnedEnemy;

    public bool canSpawnEnemy;

	public void SpawnEnemy()
    {

        var enemyToSpawn = (int)Random.Range(0, (possibleEnemies.Count));
        spawnedEnemy = Instantiate<GameObject>(possibleEnemies[enemyToSpawn]);
        spawnedEnemy.transform.parent = gameObject.transform;
        spawnedEnemy.transform.localPosition = Vector3.zero;
        spawnedEnemy.transform.parent = null;

    }
}
