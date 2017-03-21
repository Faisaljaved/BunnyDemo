using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuController : MonoBehaviour {

	public GameObject audioOn;
	public GameObject audioOff;
	public Text bestScore;
	// Use this for initialization
	void Start () {
		SoundState ();
		bestScore.text = PlayerPrefs.GetFloat ("BestScore", 0).ToString ("0.0");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit();
		} 
	}
	public void StartGame(){
		SceneManager.LoadScene ("MainGame");
	}
	public void ToggleSound(){
	
		if (PlayerPrefs.GetInt ("Muted", 0) == 0) {
			PlayerPrefs.SetInt ("Muted", 1);
		}
		else {
			PlayerPrefs.SetInt ("Muted", 0);
		}
		SoundState ();
	}
	public void SoundState()
	{
		if (PlayerPrefs.GetInt ("Muted", 0) == 0) {
		
			AudioListener.pause = false;
			audioOn.SetActive (true);
			audioOff.SetActive (false);
		}
		else
		{
			AudioListener.pause = true;
			audioOn.SetActive (false);
			audioOff.SetActive (true);
		}

	}
}
