using UnityEngine;
using System.Collections;

public class Character_Controller : MonoBehaviour {

	private Animator animator;

	public float speed = 0.5f; 
	public float scale;
	private Transform rig; 

	SpriteRenderer[] legSprite = new SpriteRenderer[4];

	bool postTransition;
	bool check;

	// USE THIS FOR INITIALIZATION
	void Start () {

		rig = GameObject.Find ("CharacterRig").transform;

		animator = GetComponentInChildren<Animator>();

		//Initialize leg-sprites
		legSprite[0] = GameObject.Find("Left_leg_run").GetComponent<SpriteRenderer>();
		legSprite[1] = GameObject.Find("Right_leg_run").GetComponent<SpriteRenderer>();
		legSprite[2] = GameObject.Find("Left_leg_idle").GetComponent<SpriteRenderer>();
		legSprite[3] = GameObject.Find("Right_leg_idle").GetComponent<SpriteRenderer>();

		//Hide leg-sprites that are not needed
		legSprite [0].enabled = false; 
		legSprite [1].enabled = false;

		}

	// UPDATE IS CALLED ONCE PER FRAME
	void Update () {
	
		controller ();
		animate ();

	}


	//CONTROLLER METHOD FOR THE PLAYER-OBJECT  
	void controller() {

		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical"); 



		//print (vertical*speed);

		Vector3 movement = new Vector3 (horizontal*speed, 0, vertical*speed);
		
		transform.Translate (movement); 
		
		if (horizontal > 0) {
			rig.transform.localScale = new Vector3(-scale,scale,scale);
		}
		
		if (horizontal < 0 ) {
			rig.transform.localScale = new Vector3(scale,scale,scale);
		}
	}

	//ANIMATION METHOD FOR THE PLAYER-OBJECT 
	void animate() {

		if (animator.IsInTransition(0) == true) {
			postTransition = true; 
		}

		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)) {

			animator.SetBool ("running", true);

			//Display running sprites
			legSprite [0].enabled = true;
			legSprite [1].enabled = true;
			legSprite [2].enabled = false;
			legSprite [3].enabled = false;

		} 	else if (animator.IsInTransition(0) && postTransition) {
				
				check = true;
		} 	else {
			animator.SetBool ("running", false);
		}
			
			if (check && !animator.IsInTransition(0)) {
				
				//Display idle sprites
				legSprite [0].enabled = false;
				legSprite [1].enabled = false;
				legSprite [2].enabled = true;
				legSprite [3].enabled = true;
				
				check = false;
			}



	}


}
