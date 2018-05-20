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
        Destroy(gameObject);

    }

    // Update is called once per frame
    void Update () {
		
	}

}
