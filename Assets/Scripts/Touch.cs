using UnityEngine;
using System.Collections;

public class Touch : MonoBehaviour {

	Ray ray; 
	GameObject selectedObject;
	RaycastHit hit;
	public Material selectedMat; 
	public bool endGame = false;
	public AudioClip pickup; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		if (Input.GetKeyDown(KeyCode.Q)) {
			endGame = !endGame;
		}

		if (endGame) {
		selectBuilding();
		}

		selectCollectable();

	}

	void selectBuilding() {

		if (Input.GetMouseButtonDown(0)) {

			if (Physics.Raycast(ray, out hit, 200))
				
				print (hit.collider.gameObject);
			
			if (hit.collider.gameObject.tag == "Building") { 
				selectedObject = hit.collider.gameObject;
				
				Renderer[] renderSelected; 

				renderSelected = selectedObject.GetComponentsInChildren<Renderer>();
				
				for (int i = 0; i < renderSelected.Length; i++) {
					renderSelected[i].material = selectedMat;
				}
			}
		}
	}

	void selectCollectable() {

		if (Input.GetMouseButtonDown(0)) {

			if (Physics.Raycast(ray, out hit, 200))

		if (hit.collider.gameObject.tag == "Collectable") { 
			selectedObject = hit.collider.gameObject;
				GameObject.Find("GameController").GetComponent<Game_Controller>().score += 1;

				//Play sound
				AudioSource.PlayClipAtPoint(pickup,GameObject.FindGameObjectWithTag("Puppet").transform.position);
			
				Renderer[] renderSelected; 

				Destroy (selectedObject);
			
				renderSelected = selectedObject.GetComponentsInChildren<Renderer>();
			
				for (int i = 0; i < renderSelected.Length; i++) {
					renderSelected[i].material = selectedMat;
				}
			}
		}
	}
}
