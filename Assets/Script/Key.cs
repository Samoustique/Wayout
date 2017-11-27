using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

	public AudioClip soundKey;

	private AudioSource audioSource;
	private GameObject player;
	private Mission missionScript;

	void Start(){
		player = GameObject.Find("FPSController");
		audioSource = GetComponent<AudioSource> ();
		missionScript = GameObject.Find("CanvasMission").GetComponent<Mission> ();
	}

	void OnTriggerEnter (Collider col) {
		if (col.gameObject == player) {
			StartCoroutine (GrabKey ());
		}
	}
	
	private IEnumerator GrabKey(){
		audioSource.PlayOneShot (soundKey);
		missionScript.UnlockDoor();
		yield return new WaitForSeconds(0.2f);
		Destroy (gameObject);
	}
}
