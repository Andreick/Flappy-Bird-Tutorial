using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnsPool : MonoBehaviour {

	public int columnPoolSize = 5;
	public GameObject columnPrefab;
	public float spawnRate = 4f;
	public float columnMin = -1f;
	public float columnMax = 3.5f;

	private GameObject[] columns;
	private Vector2 objectPoolPosition;
	private float timeSinceLastSpawned;
	private float spawnXPosition;
	private float spawnYPosition;
	private int currentColumn;

	void Start () {

		columns = new GameObject[columnPoolSize];
		objectPoolPosition = new Vector2 (-15f, 0);
		timeSinceLastSpawned = spawnRate - 2f;
		spawnXPosition = 5f;
		currentColumn = 0;

		for (int i = 0; i < columnPoolSize; i++) {

			columns [i] = (GameObject)Instantiate (columnPrefab, objectPoolPosition, Quaternion.identity);
		}
	}
	
	void Update () {

		timeSinceLastSpawned += Time.deltaTime;

		if (!GameControl.instance.gameOver && timeSinceLastSpawned >= spawnRate) {
			
			timeSinceLastSpawned = 0;
			spawnYPosition = Random.Range (columnMin, columnMax);
			columns [currentColumn++].transform.position = new Vector2 (spawnXPosition, spawnYPosition);

			if (currentColumn >= columnPoolSize) {
				currentColumn = 0;
			}
		}
	}
}
