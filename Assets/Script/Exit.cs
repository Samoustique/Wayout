using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour {
	
	public AudioClip soundExit;
	public string levelToLoad;

	private GameObject player;
	private Mission missionScript;
	private AudioSource audioSource;
	private bool isStillPlaying = true;

	void Start(){
		audioSource = GetComponent<AudioSource> ();
		player = GameObject.Find("FPSController");
		missionScript = GameObject.Find("CanvasMission").GetComponent<Mission> ();
	}

	void OnTriggerEnter (Collider col) {
		if (col.gameObject == player) {
			if(missionScript.lockedDoor){
				missionScript.DisplayLockedDoor();
			} else if (isStillPlaying) {
				isStillPlaying = false;
				audioSource.PlayOneShot(soundExit);
				missionScript.MissionFinished();
				StartCoroutine(LoadingScene());
			}
		}
	}
	
	IEnumerator LoadingScene(){
		yield return new WaitForSeconds(2f);
		SceneManager.LoadScene(levelToLoad);
	}
}
