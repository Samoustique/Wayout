using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour {
	
	public AudioClip soundAmmo;

	private AudioSource audioSource;
	private GameObject player;
	private WeaponManager weaponManager;

	void Start(){
		player = GameObject.Find("FPSController");
		audioSource = GetComponent<AudioSource> ();
		weaponManager = GameObject.Find("FirstPersonCharacter").GetComponent<WeaponManager> ();
	}

	void OnTriggerEnter (Collider col) {
		if (col.gameObject == player) {
			StartCoroutine (AddMagazine ());
		}
	}

	private IEnumerator AddMagazine(){
		audioSource.PlayOneShot (soundAmmo);
		GameObject weapon = weaponManager.weapons[weaponManager.current];
		weapon.GetComponent<Shoot>().AddMagazine();
		yield return new WaitForSeconds(0.2f);
		Destroy (gameObject);
	}
}
