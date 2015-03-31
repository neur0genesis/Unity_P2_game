using UnityEngine;
using System.Collections;

public class Character_Controller : MonoBehaviour {

	public Animator animator;

	public SpriteRenderer a;
	public SpriteRenderer b; 
	public SpriteRenderer c; 
	public SpriteRenderer d;

	// Use this for initialization
	void Start () {


		}



	// Update is called once per frame
	void Update () {

		float horizontal = Input.GetAxis ("Horizontal");


		if (horizontal != 0) {
			animator.SetBool ("running", true);
		} else {
			animator.SetBool ("running", false);


		}

		if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.D)) {
			a.enabled = false;
			b.enabled = false;
			c.enabled = true;
			d.enabled = true;
		} else {
			a.enabled = true;
			b.enabled = true;
			c.enabled = false;
			d.enabled = false;
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
