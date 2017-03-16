using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BunnyBehave : MonoBehaviour {
	private Rigidbody2D myRigidBunny;
	public float jumpForce = 500f;
	private Animator myAnim;
	private float bunnyHurtTime = -1;
	private Collider2D mycollider;
	public Text scoreText;
	private float startTime;
	private float jumpsLeft = 2;
	public AudioSource jumpSfx;
	public AudioSource deathSfx;
	// Use this for initialization
	void Start () {
		myRigidBunny = GetComponent<Rigidbody2D> ();
		myAnim = GetComponent<Animator> ();
		mycollider = GetComponent<Collider2D> ();
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			SceneManager.LoadScene ("Title");
		}


		if (bunnyHurtTime == -1) {
			if (Input.GetButtonUp ("jump") && jumpsLeft > 0) {
				if (myRigidBunny.velocity.y < 0) { 
					myRigidBunny.velocity = (Vector2.up);
				}	
				if (jumpsLeft == 1) {
					myRigidBunny.AddForce (transform.up * jumpForce * 0.75f);
				} else {
					myRigidBunny.AddForce (transform.up * jumpForce);
				}
					jumpsLeft--;
				jumpSfx.Play ();
			}
				myAnim.SetFloat ("vVelocity", myRigidBunny.velocity.y);
			scoreText.text = (Time.time - startTime).ToString ("0.0");
	} else {
			if (Time.time > bunnyHurtTime + 2) {
				SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
			}
		}
	}
	void OnCollisionEnter2D(Collision2D bCollision)
	{
		if (bCollision.collider.gameObject.layer == LayerMask.NameToLayer ("Enemy")) {

			foreach (CactusMoving cactusMover in FindObjectsOfType<CactusMoving>()) {
				cactusMover.enabled = false;
			}
			foreach (SpawnScript spawner in FindObjectsOfType<SpawnScript>()) {
				spawner.enabled = false;
			}
			bunnyHurtTime = Time.time;
			myAnim.SetBool ("bunnyHurt", true);
			myRigidBunny.velocity = Vector2.zero;
			myRigidBunny.AddForce (transform.up * jumpForce);
			mycollider.enabled = false;
			deathSfx.Play ();
		} 
		else if (bCollision.collider.gameObject.layer == LayerMask.NameToLayer ("Ground")) {
			jumpsLeft = 2;
		}
			
	}
}