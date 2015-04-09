using UnityEngine;
using System.Collections;

public class Character_Controller : MonoBehaviour {

	public Animator animator;

	SpriteRenderer[] legSprite = new SpriteRenderer[4];

	bool greenLight;
	bool done = false;
	bool check;

	// Use this for initialization
	void Start () {

		legSprite[0] = GameObject.Find("Left_leg_run").GetComponent<SpriteRenderer>();
		legSprite[1] = GameObject.Find("Right_leg_run").GetComponent<SpriteRenderer>();
		legSprite[2] = GameObject.Find("Left_leg_idle").GetComponent<SpriteRenderer>();
		legSprite[3] = GameObject.Find("Right_leg_idle").GetComponent<SpriteRenderer>();

		}



	// Update is called once per frame
	void Update () {

		float horizontal = Input.GetAxis ("Horizontal");


		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) {
			animator.SetBool ("running", true);
		} else {
			animator.SetBool ("running", false);
		}



		if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.D)) {
				legSprite[2].enabled = false;
				legSprite[3].enabled = false;
		} 

		if (animator.IsInTransition(0) == true) {
			greenLight = true; 
		}

		if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.D)) {

			print ("BOOOOOOOOOOOM");


			//Display run sprites
			legSprite [0].enabled = true;
			legSprite [1].enabled = true;
			legSprite [2].enabled = false;
			legSprite [3].enabled = false;

		} else if (greenLight == true) {

			print("Trans: " +animator.IsInTransition(0));
			print("Greenlight: " + greenLight);



			if (animator.IsInTransition(0) && greenLight) {
				//Hvis animatoren er i transition mens greenlight er sand så 
				// skal vi finde ud af hvornår animatoren ikke længere er 
				// i transistion og så køre koden. Derefter er greenlight ikke 
				// sand

				check = true;
			}

			if (check && !animator.IsInTransition(0)) {
				print("HEEEEEEEEEEEEEEEEEEEEY");

				//Display idle sprites
				legSprite [0].enabled = false;
				legSprite [1].enabled = false;
				legSprite [2].enabled = true;
				legSprite [3].enabled = true;

				check = false;
			}
		} 

		if (Input.GetKeyUp (KeyCode.A) || Input.GetKeyUp (KeyCode.D)) {
			greenLight = true;
		}

		Vector2 movement = new Vector3 (horizontal/2, 0, 0);

		transform.Translate (movement); 


		if (horizontal > 0) {
			transform.localScale = new Vector3(-1,1,1);
					}

		if (horizontal < 0) {
			transform.localScale = new Vector3(1,1,1);
		}
	}
}
