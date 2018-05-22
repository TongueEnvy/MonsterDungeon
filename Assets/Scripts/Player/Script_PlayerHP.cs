using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_PlayerHP: MonoBehaviour {
    public GameObject placeholderHeart;

    public int maxHeartContainers;
    public int MaxTempHealth;
    public int maxRedHealth;
    public int maxTempHealth;

    public int startingHeartContainers;
    public int startingTempHearts;
    public int startingRedHealth;
    public int startingTempHealth;

    public int currentHeartContainers;
    public int currentTempHearts;
    public int currentRedHealth;
    public int currentTempHealth;

    public List<GameObject> possibleHealth;

    public List<GameObject> redHearts;
    public List<GameObject> shadeHearts;

	private void Start() {
        currentRedHealth = startingRedHealth;
        currentTempHealth = startingTempHealth;
	}
	
	private void Update() {
        if(currentHeartContainers > 20) {
            currentHeartContainers = 20;
        }

        if(currentRedHealth > 40) {
            currentRedHealth = 40;
        }

        if(currentTempHealth > 20) {
            currentTempHealth = 20;
        }

        var checkRedHealth = currentRedHealth;

        for(var i = 0; i < currentHeartContainers; i += 1) {
            if(checkRedHealth >= 2) {
                var oldHeart = possibleHealth[i];
                var newHeart = Instantiate<GameObject>(redHearts[2]);

                newHeart.transform.parent = oldHeart.transform.parent;
                newHeart.transform.position = oldHeart.transform.position;
                newHeart.transform.rotation = oldHeart.transform.rotation;
                newHeart.transform.localScale = oldHeart.transform.localScale;

                possibleHealth[i] = newHeart;
                Destroy(oldHeart);
                checkRedHealth -= 2;
            }
			
            else if (checkRedHealth == 1) {
                var oldHeart = possibleHealth[i];
                var newHeart = Instantiate<GameObject>(redHearts[1]);

                newHeart.transform.parent = oldHeart.transform.parent;
                newHeart.transform.position = oldHeart.transform.position;
                newHeart.transform.rotation = oldHeart.transform.rotation;
                newHeart.transform.localScale = oldHeart.transform.localScale;

                possibleHealth[i] = newHeart;
                Destroy(oldHeart);
                checkRedHealth = 0;
            }
			
            else if (checkRedHealth <= 0) {
                var oldHeart = possibleHealth[i];
                var newHeart = Instantiate<GameObject>(redHearts[0]);

                newHeart.transform.parent = oldHeart.transform.parent;
                newHeart.transform.position = oldHeart.transform.position;
                newHeart.transform.rotation = oldHeart.transform.rotation;
                newHeart.transform.localScale = oldHeart.transform.localScale;

                possibleHealth[i] = newHeart;
                Destroy(oldHeart);
            }
        }

        var checkedTempHealth = currentTempHealth;

        for(var i = currentHeartContainers; i < currentHeartContainers + currentTempHearts; i += 1) {
            if (checkedTempHealth >= 2) {
                var oldHeart = possibleHealth[i];
                var newHeart = Instantiate<GameObject>(shadeHearts[1]);

                newHeart.transform.parent = oldHeart.transform.parent;
                newHeart.transform.position = oldHeart.transform.position;
                newHeart.transform.rotation = oldHeart.transform.rotation;
                newHeart.transform.localScale = oldHeart.transform.localScale;

                possibleHealth[i] = newHeart;
                Destroy(oldHeart);
                checkedTempHealth -= 2;
            }
			
            else if (checkedTempHealth == 1) {

                var oldHeart = possibleHealth[i];
                var newHeart = Instantiate<GameObject>(shadeHearts[0]);

                newHeart.transform.parent = oldHeart.transform.parent;
                newHeart.transform.position = oldHeart.transform.position;
                newHeart.transform.rotation = oldHeart.transform.rotation;
                newHeart.transform.localScale = oldHeart.transform.localScale;

                possibleHealth[i] = newHeart;
                Destroy(oldHeart);
                checkedTempHealth = 0;

            }
			
            else if (checkedTempHealth == 0) {
                var oldHeart = possibleHealth[i];
                var newHeart = Instantiate<GameObject>(placeholderHeart);

                newHeart.transform.parent = oldHeart.transform.parent;
                newHeart.transform.position = oldHeart.transform.position;
                newHeart.transform.rotation = oldHeart.transform.rotation;
                newHeart.transform.localScale = oldHeart.transform.localScale;

                possibleHealth[i] = newHeart;
                Destroy(oldHeart);
            }
        }
    }
}
