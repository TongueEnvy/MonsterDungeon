using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_AddEnemyToRoom : MonoBehaviour {

    public GameObject currentRoom;

	// Use this for initialization
	void Start () {

        currentRoom.gameObject.GetComponent<Script_RoomManager>().enemies.Add(gameObject);

	}

    // Update is called once per frame
    private void OnDestroy()
    {

        currentRoom.gameObject.GetComponent<Script_RoomManager>().enemies.Remove(gameObject);

    }
}
