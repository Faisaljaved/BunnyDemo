using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BunnyBehave : MonoBehaviour {
	private Rigidbody2D myRigidBunny;
	public float jumpForce = 500f;
	private Animator myAnim;
	// Use this for initialization
	void Start () {
		myRigidBunny = GetComponent<Rigidbody2D> ();
		myAnim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonUp ("jump")) {
			myRigidBunny.AddForce (transform.up * jumpForce);
		}
		myAnim.SetFloat ("vVelocity", myRigidBunny.velocity.y);

	}
	void OnCollisionEnter2D(Collision2D bCollision)
	{
		if (bCollision.collider.gameObject.layer == LayerMask.NameToLayer ("Enemy")) {
			SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
		}
	}
}