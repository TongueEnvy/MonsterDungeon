using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapGenerator: MonoBehaviour {
	public GameObject baseRoom;
	public GameObject baseDoor;
	public GameObject playerPosition;
	
	private bool[,] grid = new bool[5, 5];
	private List<GameObject> rooms = new List<GameObject>();
	//private GameObject newRoom;
	
	private void generateSpeckles() {
		for(int i = 0; i < 5; i++) {
			for(int j = 0; j < 5; j++) {
				if(Random.value >= 0.5) {
					grid[i, j] = true;
				}
				
				else {
					grid[i, j] = false;
				}
			}
		}
	}
	
	private void createMinimap() {
		for(int i = 0; i < 5; i++) {
			for(int j = 0; j < 5; j++) {
				if(grid[i, j] == true) {
					GameObject newRoom = Instantiate(baseRoom, baseRoom.transform.parent);
					rooms.Add(newRoom);
					rooms[rooms.Count - 1].GetComponent<RectTransform>().anchoredPosition =
						new Vector2(((-30f * (float)i) - 20f),
									((-30f * (float)j) - 20f));
				}
			}
		}
	}
	
	public void genMapButton() {
		foreach(GameObject deadRoom in rooms) {
			Destroy(deadRoom);
		}
		rooms = new List<GameObject>();
		generateSpeckles();
		createMinimap();
		Debug.Log(rooms.Count);
	}
}
