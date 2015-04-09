using UnityEngine;
using System.Collections;

public class Shop : MonoBehaviour {

	private Transform player; 
	private MeshRenderer renderer; 

	// Use this for initialization
	void Start () {

		player = GameObject.FindWithTag ("Player").transform;
		renderer = GetComponent<MeshRenderer>();


	}
	
	// Update is called once per frame
	void Update () {

		Vector3 relativePos = player.position - transform.position;
		float distance = relativePos.magnitude;

		print(distance);

		if (distance < 20) {
			print("Enter shop");
			renderer.material.color = Color.red;
		} else {
			renderer.material.color = Color.white;

		}



	}
}
