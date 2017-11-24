using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerscript_topview: MonoBehaviour {

	public float speed = 0.3f;

	// Use this for initialization
	void Start () {
		print ("Hej");	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.anyKey) {


			if (Input.GetKey (KeyCode.W)) {
				print ("W is pressed");
				this.transform.Translate (new Vector2 (0, speed));
			}

			if (Input.GetKey (KeyCode.A)) {
				print ("A is pressed");
				this.transform.Translate (new Vector2 (-speed, 0));
			}

			if (Input.GetKey (KeyCode.S)) {
				print ("S is pressed");
				this.transform.Translate (new Vector2 (0, -speed));
			}

			if (Input.GetKey (KeyCode.D)) {
				print ("D is pressed");
				this.transform.Translate (new Vector2 (speed, 0));
			}

		} else {
			print ("nothing is pressed");
		}
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}
			print ("Goodbye");
	}
}
