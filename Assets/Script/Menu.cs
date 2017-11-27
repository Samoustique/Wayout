using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	void Start(){
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}

	public void Play () {
		SceneManager.LoadScene("level1");
	}
	
	public void Exit () {
		Application.Quit();
	}
}
