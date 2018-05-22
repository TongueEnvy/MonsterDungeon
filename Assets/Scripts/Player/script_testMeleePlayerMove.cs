using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_testMeleePlayerMove : MonoBehaviour {

    public GameObject cursor;
    public GameObject model;
    public GameObject camAnchor;
    public bool inWideRoom;
    public bool inTallRoom;
    public GameObject currentRoom;
    public float moveSpeed;
    public float cursorSpeed;
    public float cursorRange;
    public float camSpeed;

    LineRenderer line;
    Rigidbody movement;


    // Use this for initialization
    void Start() {

        camAnchor.transform.parent = null;
        movement = gameObject.GetComponent<Rigidbody>();
        line = gameObject.GetComponent<LineRenderer>();

        }

    // Update is called once per frame
    void Update()
    {
        var camPos = transform.position;
        camPos.y = currentRoom.transform.position.y;

        if (inWideRoom == true)
        {

            if (transform.position.x > (currentRoom.transform.position.x + 14))
            {

                camPos.x = currentRoom.transform.position.x + 14;

            }
            else if (transform.position.x < (currentRoom.transform.position.x - 14))
            {

                camPos.x = currentRoom.transform.position.x - 14;

            }

            if (inTallRoom == false)
            {

                camPos.z = currentRoom.transform.position.z;

            }

        }

        if (inTallRoom == true)
        {

            if (transform.position.z > (currentRoom.transform.position.z + 10))
            {

                camPos.z = currentRoom.transform.position.z + 10;

            }
            else if (transform.position.z < (currentRoom.transform.position.z - 10))
            {

                camPos.z = currentRoom.transform.position.z - 10;

            }

            if (inWideRoom == false)
            {

                camPos.x = currentRoom.transform.position.x;

            }

        }

        if (inWideRoom == false && inTallRoom == false)
        {
            camPos = currentRoom.transform.position;
        }

        camAnchor.transform.position = Vector3.Lerp(camAnchor.transform.position, camPos, Time.deltaTime * camSpeed);

        var move = new Vector3(Input.GetAxisRaw("Move Horizontal") * moveSpeed, 0, Input.GetAxisRaw("Move Vertical") * moveSpeed);
        movement.velocity = new Vector3(move.x, movement.velocity.y, move.z);
        var moveCursor = new Vector3(Input.GetAxisRaw("Aim Horizontal") * cursorSpeed, 0, Input.GetAxisRaw("Aim Vertical") * cursorSpeed);
        cursor.transform.position += moveCursor;
        var cursorDist = Vector3.Distance(transform.position, cursor.transform.position);

        if (cursorDist > cursorRange) {
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
