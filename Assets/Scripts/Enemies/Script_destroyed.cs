using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_destroyed : MonoBehaviour {
    

	// Use this for initialization
	void Start () {

        

	}

    private void OnEnable()
    {

        if (gameObject.GetComponent<Generic_RadialBurst>())
        {

            gameObject.GetComponent<Generic_RadialBurst>().RadialBurst();

        }

        if (gameObject.GetComponent<Generic_DropItem>())
        {

            gameObject.GetComponent<Generic_DropItem>().DropItems();

        }

        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update () {
		
	}

}
