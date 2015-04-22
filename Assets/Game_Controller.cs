using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Game_Controller : MonoBehaviour {

	public int score;
	public Text scoreText;

	// Use this for initialization
	void Awake () {

		scoreText.GetComponent<Text>();
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {

		ScoreManager();
	
	}

	void ScoreManager() {
		scoreText.text = "" + score;
	}

}
