using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

	public static GameControl instance;
	public GameObject gameOverText;
	public Text scoreText;
	public bool gameOver = false;
	public float scrollSpeed = -1.5f;

	private int score = 0;
	private float time = 0;

	void Awake () {
		
		if (instance == null) {
			
			instance = this;

		} else if (instance != this) {
			
			Destroy (gameObject);
		}
	}

	void Update () {

		if (gameOver) {

			time += Time.deltaTime;

			if (Input.GetMouseButtonDown(0) && time > 0.4f) {

				SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
			}
		}

		if (Input.GetKeyDown(KeyCode.Escape)) {

			Application.Quit ();
		}
	}

	public void BirdDied () {
		gameOver = true;
		gameOverText.SetActive (true);
	}

	public void BirdScored () {

		if (!gameOver) {
			score++;
			scoreText.text = "Score: " + score.ToString ();
		}
	}
}
