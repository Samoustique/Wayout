using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDead : MonoBehaviour {

	private Animator anim;

	void Start () {
		anim = GetComponent<Animator> ();
	}

	public void Die () {
		anim.enabled = true;
		GameObject.Find("FPSController").GetComponent<CharacterController>().enabled = false;

		// disable weapon
		for(int i = 0 ; i < transform.childCount ; ++i){
			transform.GetChild (i).gameObject.SetActive (false);
		}

		// disable targets sounds
		GameObject[] targets = GameObject.FindGameObjectsWithTag("Target");
		foreach (GameObject target in targets) {
			target.GetComponent<AudioSource> ().enabled = false;
		}
		
		StartCoroutine(GameOver());
	}
	
	IEnumerator GameOver(){
		yield return new WaitForSeconds(3f);
		SceneManager.LoadScene("menu");
	}
}
