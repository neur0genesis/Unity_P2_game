using UnityEngine;
using System.Collections;

public class Character_Controller : MonoBehaviour {

	private Animator animator;
	SpriteRenderer[] sprites; 
	ParticleSystem[] lootEmitter = new ParticleSystem[2]; 
	
	public float speed = 0.5f; 
	public float scale;
	private Transform rig; 
	public Transform[] particleMoney = new Transform[2];

	SpriteRenderer[] legSprite = new SpriteRenderer[4];

	bool postTransition;
	bool check;
	bool hidden = false; 

	// USE THIS FOR INITIALIZATION
	void Start () {


		rig = GameObject.Find ("CharacterRig").transform;
		lootEmitter = GameObject.Find ("CharacterRig").GetComponentsInChildren<ParticleSystem>();

		lootEmitter[0].enableEmission = false; 
		lootEmitter[1].enableEmission = false; 

		animator = GetComponentInChildren<Animator>();

		sprites =  GetComponentsInChildren<SpriteRenderer> ();

		/*for (int i = 0; i < sprites.Length; i++) {
			sprites [i].enabled = false;
		}*/

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
		hidePlayer ();

		if (!hidden) {
			animate ();
		}

	}


	//CONTROLLER METHOD FOR THE PLAYER-OBJECT  
	void controller() {

		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical"); 

		//control loot drop
		if (Input.GetKeyDown(KeyCode.E)) {

			gameObject.GetComponent<Loot>().dropLoot = !gameObject.GetComponent<Loot>().dropLoot;
			lootEmitter[0].enableEmission = !lootEmitter[0].enableEmission;
			lootEmitter[1].enableEmission = !lootEmitter[1].enableEmission;
		}

		//print (vertical*speed);

		Vector3 movement = new Vector3 (horizontal*speed, 0, vertical*speed);
		
		transform.Translate (movement); 
		
		if (horizontal > 0) {
			rig.transform.localScale = new Vector3(-scale,scale,scale);
			particleMoney[0].localScale = new Vector3(-scale,scale,scale);
			particleMoney[1].localScale = new Vector3(-scale,scale,scale);

		}
		
		if (horizontal < 0 ) {
			rig.transform.localScale = new Vector3(scale,scale,scale);
			particleMoney[0].localScale = new Vector3(scale,scale,scale);
			particleMoney[1].localScale = new Vector3(scale,scale,scale);

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

	void hidePlayer() {
		//Hide sprites when entering building
		if (Input.GetKeyDown (KeyCode.R) && hidden == false) {
			
			hidden = true;
			
			for (int i = 0; i < sprites.Length; i++) {
				sprites [i].enabled = false;
			}
			for (int i = 0; i < legSprite.Length; i++) {
				legSprite [i].enabled = false;
			}
		} else if (Input.GetKeyDown (KeyCode.R) && hidden == true) {

			hidden = false;

			for (int i = 0; i < sprites.Length; i++) {
				sprites [i].enabled = true;
			}
			for (int i = 0; i < legSprite.Length; i++) {
				legSprite [i].enabled = true;
			}

			legSprite [0].enabled = false;
			legSprite [1].enabled = false;

		}
	}

}
