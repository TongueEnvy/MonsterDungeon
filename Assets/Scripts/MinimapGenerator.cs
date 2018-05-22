using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapGenerator: MonoBehaviour {
	public GameObject baseRoom;
	public GameObject baseDoor;
	public GameObject spawnPoint;
	
	private bool[,] grid			= new bool[5, 5];
	private List<GameObject> rooms	= new List<GameObject>();
	private List<GameObject> doors	= new List<GameObject>();
	private GameObject playerPosition;
	private bool showMinimap		= true;
	//private GameObject newRoom;
	
	private void GenerateSpeckles() {
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
	
	/*	GenerateDungeon creates 9-15 rooms, which is the
	**		"healthy average".
	*/
	private void GenerateDungeon() {
		//int sourceNode	= 0;
		int addRooms		= 0;
		int buildDirection	= 0; //Note, perspective rotated 180 degrees.
		int i				= 0;
		int j				= 0;
		//int randomCounter	= 0;
		
		//sourceNode = (int)Random.Range(0f, 24f);
		addRooms = (int)Random.Range(8f, 14f);
		//i = sourceNode / 5;
		//j = sourceNode % 5;
		i = Mathf.FloorToInt(Random.value * 5);
		j = Mathf.FloorToInt(Random.value * 5);
		grid[i, j] = true;
		
		//Debug.Log(addRooms);
		while(addRooms > 0) {
			//Debug.Log(addRooms);
			buildDirection = Mathf.CeilToInt(Random.value * 4);
			switch(buildDirection) {
				//Build North
				case 1:
					if(i < 4) {
						if(grid[(i + 1), j] == false) {
							i++;
							grid[i, j] = true;
							addRooms--;
						}
						
						else {
							i++;
						}
					}
					
					break;

				//Build East
				case 2:
					if(j < 4) {
						if(grid[i, (j + 1)] == false) {
							j++;
							grid[i, j] = true;
							addRooms--;
						}
						
						else {
							j++;
						}
					}
					
					break;
				//Build South
				case 3:
					if(i > 0) {
						if(grid[(i - 1), j] == false) {
							i--;
							grid[i, j] = true;
							addRooms--;
						}
						
						else {
							i--;
						}
					}
					
					break;
				//Build West
				case 4:
					if(j > 0) {
						if(grid[i, (j - 1)] == false) {
							j--;
							grid[i, j] = true;
							addRooms--;
						}
						
						else {
							j--;
						}
					}
					
					break;
				//Build nowhere...?
				default:
					break;
			}
			
			/*
			randomCounter++;
			if(randomCounter > 255) {
				Debug.Log(addRooms);
				addRooms--;
			}
			*/
		}
	}
	
	private void CreateMinimap() {
		for(int i = 0; i < 5; i++) {
			for(int j = 0; j < 5; j++) {
				if(grid[i, j] == true) {
					GameObject newRoom = Instantiate(baseRoom, baseRoom.transform.parent);
					newRoom.SetActive(showMinimap);
					rooms.Add(newRoom);
					rooms[rooms.Count - 1].GetComponent<RectTransform>().anchoredPosition =
						new Vector2(((-30f * (float)i) - 20f),
									((-30f * (float)j) - 20f));
				}
			}
		}
		
		for(int i = 0; i < 4; i++) {
			for(int j = 0; j < 5; j++) {
				if((grid[i, j] == true) && (grid[(i + 1), j] == true)) {
					GameObject newDoor = Instantiate(baseDoor, baseDoor.transform.parent);
					newDoor.SetActive(showMinimap);
					doors.Add(newDoor);
					doors[doors.Count - 1].GetComponent<RectTransform>().anchoredPosition =
						new Vector2(((-30f * (float)i) - 35f),
									((-30f * (float)j) - 20f));
					doors[doors.Count - 1].GetComponent<RectTransform>().sizeDelta =
						new Vector2(9f, 15f);
				}
			}
		}
		
		for(int i = 0; i < 5; i++) {
			for(int j = 0; j < 4; j++) {
				if((grid[i, j] == true) && (grid[i, (j + 1)] == true)) {
					GameObject newDoor = Instantiate(baseDoor, baseDoor.transform.parent);
					newDoor.SetActive(showMinimap);
					doors.Add(newDoor);
					doors[doors.Count - 1].GetComponent<RectTransform>().anchoredPosition =
						new Vector2(((-30f * (float)i) - 20f),
									((-30f * (float)j) - 35f));
				}
			}
		}
		
		DefineSpawnPoint();
	}
	
	private void DefineSpawnPoint() {
		int i = 0, j = 0;
		bool spawnSet = false;
		
		while(spawnSet == false) {
			i = Mathf.FloorToInt(Random.value * 5);
			j = Mathf.FloorToInt(Random.value * 5);
			if(grid[i, j] == true) {
				playerPosition = Instantiate(spawnPoint, spawnPoint.transform.parent);
				playerPosition.SetActive(showMinimap);
				playerPosition.GetComponent<RectTransform>().anchoredPosition =
					new Vector2(((-30f * (float)i) - 20f),
								((-30f * (float)j) - 20f));
				spawnSet = true;
			}
		}
	}
	
	public void GenMapButton() {
		foreach(GameObject deadRoom in rooms) {
			Destroy(deadRoom);
		}
		
		foreach(GameObject deadDoor in doors) {
			Destroy(deadDoor);
		}
		
		Destroy(playerPosition);
		
		for(int i = 0; i < 5; i++) {
			for(int j = 0; j < 5; j++) {
				grid[i, j] = false;
			}
		}
		
		rooms = new List<GameObject>();
		doors = new List<GameObject>();
		GenerateDungeon();
		CreateMinimap();
		//Debug.Log(rooms.Count);
	}
	
	public void Update() {
		if(Input.GetButtonDown("Minimap")) {
			showMinimap = !showMinimap;
			
			foreach(GameObject room in rooms) {
				room.SetActive(showMinimap);
			}
		
			foreach(GameObject door in doors) {
				door.SetActive(showMinimap);
			}
			
			playerPosition.SetActive(showMinimap);
		}
	}
}
