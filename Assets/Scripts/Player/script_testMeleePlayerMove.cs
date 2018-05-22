using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_testMeleePlayerMove : MonoBehaviour {

    LineRenderer line;
    Rigidbody movement;

    public float moveSpeed;
    public GameObject cursor;
    public GameObject model;
    public GameObject camAnchor;
    public GameObject currentRoom;
    public float cursorSpeed;
    public float cursorRange;

    // Use this for initialization
    void Start () {

        movement = gameObject.GetComponent<Rigidbody>();
        line = gameObject.GetComponent<LineRenderer>();

    }
	
	// Update is called once per frame
	void Update () {

        camAnchor.transform.position = currentRoom.transform.position;

        var move = new Vector3(Input.GetAxisRaw("Move Horizontal") * moveSpeed, 0, Input.GetAxisRaw("Move Vertical") * moveSpeed);

        movement.velocity = new Vector3(move.x, movement.velocity.y, move.z);

        var moveCursor = new Vector3(Input.GetAxisRaw("Aim Horizontal") * cursorSpeed, 0, Input.GetAxisRaw("Aim Vertical") * cursorSpeed);

        cursor.transform.position += moveCursor;

        var cursorDist = Vector3.Distance(transform.position, cursor.transform.position);

        if (cursorDist > cursorRange)
        {

            var vect = transform.position - cursor.transform.position;
            vect = vect.normalized;
            vect *= (cursorDist - cursorRange);
            cursor.transform.position += vect;

        }

        line.SetPosition(0, model.transform.position + new Vector3(0, .5f, 0));
        line.SetPosition(1, cursor.transform.position);

        model.transform.LookAt(cursor.transform.position);

    }
}
