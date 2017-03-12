using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour {
	private float nextSpawn= 0;
	public Transform prefabSpawn;
	public AnimationCurve spawnCurve;
	public float curveInSeconds= 30f ;
	private float startTime;
	public float jitter = 0.25f;
	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextSpawn) {
			Instantiate (prefabSpawn, transform.position, Quaternion.identity);
			//nextSpawn = Time.time + spawnRate + Random.Range (0, randomDelay);
			float curvePos = (Time.time - startTime) / curveInSeconds;
			if (curvePos > 1f) {
				curvePos = 1f;
				startTime = Time.time;
			}
			nextSpawn = Time.time + spawnCurve.Evaluate (curvePos) + Random.Range(-jitter,jitter);
		}
	}
}
