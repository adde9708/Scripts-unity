//------------------------
// My Ideas
// Endless runner
// Avoid obstacles(Trees, you bounce back a bit if you hit it)
// Pickup objects
// Powerups(faster, higher highscore)
// powerdowns( slower, less highscore, restart, reverse controlls)
// or use the trees as real obstacles?
// High score
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerscript_2dplatformer: MonoBehaviour {
	public GUIText countext;
	public 	GUIText wintext;
	private int count;
	public float speed = 0.3f;
	public float jump = 1.0f;
	public Transform startposition;
	public int wincount = 4;

          // Use this for initialization
          void Start() {
            print("Hej");
            count = 0;
            SetCountText();
            wintext.text = "";
          }

          // Update is called once per frame
          void Update() {


 }

          void FixedUpdate() {
            PlayerMovement();
            QuitApp();
          }

        public void PlayerMovement() {
            if (Input.anyKey) {

              if (Input.GetKeyDown(KeyCode.W)) {
                // print ("W is pressed");
                this.transform.Translate(new Vector2(0, jump));
              }

              if (Input.GetKey(KeyCode.A)) {
                // print ("A is pressed");
                this.transform.Translate(new Vector2(-speed, 0));
              }

              if (Input.GetKey(KeyCode.S)) {
                // print ("S is pressed");
                this.transform.Translate(new Vector2(0, -speed));
              }

              if (Input.GetKey(KeyCode.D)) {
                // print ("D is pressed");
                this.transform.Translate(new Vector2(speed, 0));
              }

              if (Input.GetKey(KeyCode.R)) {
	//reset to startposition aka origo.
	this.transform.position = startposition.position;
   this.transform.rotation = startposition.rotation;
   // print ("R is pressed");

              }
            } else {
               print ("nothing is pressed");
            }

            // print ("Goodbye");
          }
          void QuitApp() {
            if (Input.GetKeyDown(KeyCode.Escape)) {
              Application.Quit();
            }
          }
          // On Collision something something
          void OnCollisionEnter(Collision collision) {
            if (collision.gameObject.tag == "wall") {

              print("Collision has been dectected");
            }
            if (collision.gameObject.tag == "Checkpoint") {
              print("Checkpoint has been dectected");
            }
            if (collision.gameObject.tag == "start") {
              print("start has been dectected");
            }
            if (collision.gameObject.tag == "end") {
              print("end has been dectected");
            }
          }
          void OnTriggerStay(Collider trigger) {
            if (trigger.gameObject.tag == "Ladder") {
              print("Ladder is enabled.");
            }
          }

          void OnTriggerEnter(Collider other) {

            if (other.gameObject.tag == "Pickup") {
              print("Picked up object");
              other.gameObject.SetActive(false);
              count = count + 1;
              SetCountText();
            }
        if (other.gameObject.tag == "Speedboost") {
		 StartCoroutine(StopSpeedBoost());
		 print("SpeedBoost");

            }
          }
	 void SetCountText() {

      countext.text = "Count" + count.ToString();
   if (count >= wincount) {
       wintext.text = "You win!";
       Application.LoadLevel("level02");
            }
          }

IEnumerator StopSpeedBoost() {
 speed=1.0F;
 yield return new WaitForSeconds(3F);
 speed=0.3;
 print("speedboost over");
          }
  }
