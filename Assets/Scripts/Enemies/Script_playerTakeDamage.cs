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

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {

            if (other.gameObject.GetComponent<player_TrackSpecialEffects>().hasBentleysTumor == true)
            {

                GameObject.Find("familiar_Bentley'sTumor").GetComponent<Script_HP>().HP -= 1;

            }
            else
            {

                var checkDamage = damageValue;

                if (other.gameObject.GetComponent<Script_PlayerHP>().currentTempHealth > 0)
                {

                    for (var i = 0; i < damageValue; i += 1)
                    {

                        if (other.gameObject.GetComponent<Script_PlayerHP>().currentTempHealth > 0)
                        {

                            other.gameObject.GetComponent<Script_PlayerHP>().currentTempHealth -= 1;
                            checkDamage -= 1;

                        }
                        else
                        {

                            break;

                        }

                    }

                }

                if (checkDamage > 0)
                {

                    for (var i = 0; i < damageValue; i += 1)
                    {

                        other.gameObject.GetComponent<Script_PlayerHP>().currentRedHealth -= 1;
                        checkDamage -= 1;

                        if (checkDamage <= 0)
                        {

                            break;

                        }

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
