using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_DealDamage : MonoBehaviour
{

    public float minDamage;
    public float maxDamage;
    public bool destroyOnHit;
    public List<string> possibleTargets;

    // Use this for initialization
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {



    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.GetComponent<Script_HP>())
        {

            for (var i = 0; i <= possibleTargets.Count - 1; i += 1)
            {

                if (possibleTargets[i] == other.gameObject.tag)
                {

                    other.gameObject.GetComponent<Script_HP>().HP -= Random.Range(minDamage, maxDamage);

                    if(destroyOnHit == true)
                    {

                        Destroy(gameObject);

                    }

                    break;

                }

            }

        }
    }

}
