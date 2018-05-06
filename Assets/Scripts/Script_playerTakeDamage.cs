using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_playerTakeDamage : MonoBehaviour {

    public int damageValue;

    public bool destroyOnHit;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.tag == "Player")
        {

            var checkDamage = damageValue;

            if(collision.gameObject.GetComponent<Script_PlayerHP>().currentTempHealth > 0)
            {

                for (var i = 0; i < damageValue; i += 1)
                {

                    if(collision.gameObject.GetComponent<Script_PlayerHP>().currentTempHealth > 0)
                    {

                        collision.gameObject.GetComponent<Script_PlayerHP>().currentTempHealth -= 1;
                        checkDamage -= 1;

                    }
                    else
                    {

                        break;

                    }

                }

            }

        if(checkDamage > 0)
            {

                for (var i = 0; i < damageValue; i += 1)
                {

                    collision.gameObject.GetComponent<Script_PlayerHP>().currentRedHealth -= 1;
                    checkDamage -= 1;

                    if(checkDamage <= 0)
                    {

                        break;

                    }

                }

            }

        }

    if(destroyOnHit == true)
        {

            Destroy(gameObject);

        }
    }
}
