using UnityEngine;
using System.Collections;

public class Touch : MonoBehaviour {

	Ray ray; 
	GameObject selectedObject;
	RaycastHit hit;
	public Material selectedMat; 



	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
					
		if (Input.GetMouseButtonDown(0)) {
					
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(ray, out hit, 100))

				print(hit.collider.gameObject.transform.parent.name);

			if (hit.collider.gameObject.tag == "Building") { 
				selectedObject = hit.collider.gameObject;
			}


			Renderer[] renderSelected; 
			Shader shader; 


			renderSelected = selectedObject.GetComponentsInChildren<Renderer>();

			for (int i = 0; i < renderSelected.Length; i++) {
				renderSelected[i].material = selectedMat;
			}
		}
	}
}
