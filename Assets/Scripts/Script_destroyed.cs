using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_destroyed : MonoBehaviour {



	// Use this for initialization
	void Start () {

        

	}

    private void OnEnable()
    {

        Destroy(gameObject);

    }

    // Update is called once per frame
    void Update () {
		
	}

}
