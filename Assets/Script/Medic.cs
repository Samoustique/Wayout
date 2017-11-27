using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medic : MonoBehaviour {

	public AudioClip soundMedic;
	public int medicPoint = 10;

	private AudioSource audioSource;
	private GameObject player;
	private HealthManager healthManagerScript;

	void Start(){
		player = GameObject.Find("FPSController");
		audioSource = GetComponent<AudioSource> ();
		healthManagerScript = GameObject.Find("FirstPersonCharacter").GetComponent<HealthManager> ();
	}

	void OnTriggerEnter (Collider col) {
		if (col.gameObject == player) {
			if(healthManagerScript.life < 100){
				StartCoroutine (AddMedicPlayer ());
			}
		}
	}

	private IEnumerator AddMedicPlayer(){
		audioSource.PlayOneShot (soundMedic);
		healthManagerScript.playerHeal (medicPoint);
		yield return new WaitForSeconds(0.2f);
		Destroy (gameObject);
	}
}
