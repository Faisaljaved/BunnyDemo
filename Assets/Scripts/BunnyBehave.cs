using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyBehave : MonoBehaviour {
	private Rigidbody2D myRigidBunny;
	public float jumpForce = 500f;
	// Use this for initialization
	void Start () {
		myRigidBunny = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonUp ("jump")) {
			myRigidBunny.AddForce (transform.up * jumpForce);
		}
	}
}
