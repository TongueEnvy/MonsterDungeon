using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generic_DropItem : MonoBehaviour {

    public List<GameObject> possibleItems;
    public GameObject assignedItem;
    public float itemChance;
    public int itemNumberMin;
    public int itemNumberMax;

	// Use this for initialization
	void Start () {

        var checkForItem = (Random.Range(0, 100));

        if(checkForItem < itemChance)
        {

            var itemToContain = (int)Random.Range(0, possibleItems.Count);
            assignedItem = possibleItems[itemToContain];

        }

	}

    // Update is called once per frame
    public void DropItems()
    {
        if (assignedItem != null)
        {
            var itemNumber = (int)Random.Range(itemNumberMin, itemNumberMax);
            for (var i = 0; i < itemNumber; i += 1)
            {

                var newItem = Instantiate<GameObject>(assignedItem);
                newItem.transform.parent = gameObject.transform;
                newItem.transform.localPosition = Vector3.zero;
                newItem.transform.parent = null;

            }
        }

    }
}
