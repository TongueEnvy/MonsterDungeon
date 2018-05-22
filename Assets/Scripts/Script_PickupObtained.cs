using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_PickupObtained: MonoBehaviour {
    public int redHealthValue;
    public int tempHealthValue;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && other.gameObject.GetComponent<Script_PlayerHP>())
        {
            other.gameObject.GetComponent<Script_PlayerHP>().currentRedHealth += redHealthValue;

            if(tempHealthValue > 0)
            {
                var playerTempHealthFloat = other.gameObject.GetComponent<Script_PlayerHP>().currentTempHealth;
                if ((tempHealthValue + playerTempHealthFloat / 2 > other.gameObject.GetComponent<Script_PlayerHP>().currentTempHearts))
                {
                    other.gameObject.GetComponent<Script_PlayerHP>().currentTempHearts += 1;
                }

            other.gameObject.GetComponent<Script_PlayerHP>().currentTempHealth += tempHealthValue;
            }

            Destroy(gameObject);
        }
    }
}
