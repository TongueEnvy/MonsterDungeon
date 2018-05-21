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

        if (other.gameObject.GetComponent<Rigidbody>())
        {

            var newVelocity = ((other.transform.position - transform.position).normalized *gameObject.GetComponent<Rigidbody>().velocity.magnitude);
            other.gameObject.GetComponent<Rigidbody>().AddForce(newVelocity, ForceMode.Impulse);

        }

        if (other.gameObject.GetComponent<Script_HP>())
        {

            if (other.gameObject.GetComponent<Script_HP>().canBeHurt == true)
            {
                other.gameObject.GetComponent<Script_HP>().canBeHurt = false;

                other.gameObject.GetComponent<Script_HP>().damageCounter = other.gameObject.GetComponent<Script_HP>().damageTimer;

                for (var i = 0; i <= possibleTargets.Count - 1; i += 1)
                {

                    if (possibleTargets[i] == other.gameObject.tag)
                    {

                        other.gameObject.GetComponent<Script_HP>().HP -= Random.Range(minDamage, maxDamage);

                        if (destroyOnHit == true)
                        {

                            Destroy(gameObject);

                        }

                        break;

                    }

                }

            }
        }

        if (other.gameObject.GetComponent<Script_HP_GigaBerry>())
        {

            if (other.gameObject.GetComponent<Script_HP_GigaBerry>().canBeHurt == true)
            {
                other.gameObject.GetComponent<Script_HP_GigaBerry>().canBeHurt = false;

                other.gameObject.GetComponent<Script_HP_GigaBerry>().damageCounter = other.gameObject.GetComponent<Script_HP_GigaBerry>().damageTimer;

                for (var i = 0; i <= possibleTargets.Count - 1; i += 1)
                {

                    if (possibleTargets[i] == other.gameObject.tag)
                    {

                        var damageDealt = Random.Range(minDamage, maxDamage);

                        other.gameObject.GetComponent<Script_HP_GigaBerry>().HP -= damageDealt;

                        other.gameObject.GetComponent<Script_HP_GigaBerry>().trackDamage += damageDealt;

                        if (destroyOnHit == true)
                        {

                            Destroy(gameObject);

                        }

                        break;

                    }

                }

            }
        }
    }

}
