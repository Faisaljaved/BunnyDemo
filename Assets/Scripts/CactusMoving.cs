﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusMoving : MonoBehaviour {
	public float speed = 5;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += Vector3.left * speed * Time.deltaTime;
	}
}
