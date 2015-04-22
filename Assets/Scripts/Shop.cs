using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Shop : MonoBehaviour {
	
	private Transform puppetTransform; 
	public Renderer[] buildingRenderer; 
	public Color[] originalColor;
	private Vector3 originalScale;  
	public static GameObject[] order = new GameObject[5]; 
	public static Text remaining; 

	float scaleValue;
	bool entered;
	float distance;
	static int num;
	public AudioClip alarmClip; 

	GameObject puppet; 
	
	/* This script is used to control how the puppet
	 * object interacts with the buildings in the game. 
	 * The puppet object should e.g. only be able to
	 * enter a building, if he is standing next to a
	 * building.
	*/
	
	
	// Use this for initialization
	void Start () {

		remaining = GameObject.Find("Remaining").GetComponent<Text>();
		
		puppetTransform = GameObject.FindWithTag ("Puppet").transform;
		originalScale = transform.localScale; 
		
		buildingRenderer = GetComponentsInChildren<Renderer>();
		
		originalColor = new Color[buildingRenderer.Length];
		
		for (int i = 0; i < buildingRenderer.Length; i++) {
			originalColor[i] = buildingRenderer[i].sharedMaterial.color;
		}

		puppet = GameObject.FindGameObjectWithTag("Puppet");

		remaining.text = "" + order.Length + "/" + order.Length + " remaining";



		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		Vector3 relativePos = puppetTransform.position - transform.position;
		distance = relativePos.magnitude;
		
		if (distance < 10 && Input.GetKeyDown(KeyCode.R) && this.entered == false) {
			this.entered = true; 
			print (this.gameObject);

			if (num < order.Length - 1) {
			order[num] = this.gameObject;
			num++;
				remaining.text = "" + (order.Length - num) + "/" + order.Length + " remaining";
			}

			puppet.gameObject.GetComponent<Puppet_Controller>().visible = false;
			puppet.gameObject.GetComponent<Puppet_Controller>().visibility(); 

			AudioSource.PlayClipAtPoint(alarmClip,transform.position);

		} else if (this.entered == true && Input.GetKeyDown(KeyCode.R)) {
			this.entered = false;
			puppet.gameObject.GetComponent<Puppet_Controller>().visible = true;
			puppet.gameObject.GetComponent<Puppet_Controller>().visibility(); 
		}

		if (entered == true) {
			animate();
		} else {
			reset(); //Optimize this part later, so it doesn't evaluate when not needed
		}

		//This part of the code logs the buildings into an array list

	}
	
	void animate() {
			for (int i = 0; i < buildingRenderer.Length; i++) {
				buildingRenderer[i].material.color = Color.Lerp(Color.red,Color.white,0.5f);
			}
			scaleValue += 5f * Time.deltaTime;
			transform.localScale += new Vector3 (Mathf.Cos(scaleValue)/10,Mathf.Cos(scaleValue)/10,Mathf.Cos(scaleValue)/10);
	}

	void reset() {
			for (int i = 0; i < buildingRenderer.Length; i++) {
				buildingRenderer[i].material.color = originalColor[i];
			}
			
			transform.localScale = originalScale;
	}
}
