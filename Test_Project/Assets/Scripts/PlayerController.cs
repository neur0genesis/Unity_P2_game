using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Rigidbody rb;

	void Start() {
		// Setup the reference to the alarm light.
		rb = GetComponent<Rigidbody> ();
		}

	// Update is called once before physics calculations
	void FixedUpdate () {

		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal,0,moveVertical);
		rb.AddForce(movement);

	}
}
