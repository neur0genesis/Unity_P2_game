using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public float smooth = 1.5f;

	private Transform player; 
	private Vector3 relCameraPos;
	private float relCameraPosMag;
	private Vector3 newPos;

	void Awake() {

		player = GameObject.FindWithTag ("Player").transform;

		print ("It worked: " + player.position);

		relCameraPos = transform.position - player.position;
		relCameraPosMag = relCameraPos.magnitude - 0.5f;


	}
	
	// Update is called once per frame
	void FixedUpdate () {

		print (
			player.position
		);

		Vector3 standard = player.position + relCameraPos; 
		Vector3 abovePos = player.position + Vector3.up * relCameraPosMag; 
		Vector3[] checkPoint = new Vector3[5];
		checkPoint [0] = standard;
		checkPoint [1] = Vector3.Lerp (standard, abovePos, 0.25f);
		checkPoint [2] = Vector3.Lerp (standard, abovePos, 0.50f);
		checkPoint [3] = Vector3.Lerp (standard, abovePos, 0.75f);	
		checkPoint [4] = abovePos;

		for (int i = 0; i < checkPoint.Length; i++) {
			if(ViewPosCheck(checkPoint[i])) {
				break;
			}
		}

		transform.position = Vector3.Lerp (transform.position, newPos, smooth * Time.deltaTime); 
		SmoothLookAt();
		
	}

	bool ViewPosCheck(Vector3 checkPos) {
		RaycastHit hit; 
		if (Physics.Raycast(checkPos, player.position - checkPos, out hit, relCameraPosMag)) {
			if (hit.transform != player) {
				return false; 
			}
		}

		newPos = checkPos; 
		return true;
	}

	void SmoothLookAt() {
		Vector3 relPlayerPosition = player.position - transform.position; 
		Quaternion lookRotation = Quaternion.LookRotation (relPlayerPosition, Vector3.up);
		transform.rotation = Quaternion.Lerp (transform.rotation, lookRotation, smooth * Time.deltaTime);
	}

}
