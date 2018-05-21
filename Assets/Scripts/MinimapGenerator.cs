using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapGenerator: MonoBehaviour {
	public GameObject room;
	public GameObject door;
	public GameObject playerPosition;
	
	private bool[,] grid = new bool[5, 5];
	
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
					Instantiate(room,
								new Vector3((-30f * (float)i),
											(-30f * (float)j),
											0f),
								transform.rotation);
				}
			}
		}
	}
	
	public void genMapButton() {
		generateSpeckles();
		createMinimap();
	}
}
