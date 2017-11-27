using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon2 : MonoBehaviour {

	public Animator animFlame;

	private Animator animWeapon;
	private Shoot shootScript;

	void Start () {
		animWeapon = GetComponent<Animator> ();	
		shootScript = GetComponent<Shoot>() as Shoot;
	}

	void Update () {
		if(Input.GetKeyDown(KeyCode.R) &&
			shootScript.nbMagazine > 0 &&
			shootScript.nbCartridge < shootScript.nbMaxCartridge){
			animWeapon.SetTrigger ("reload");
		}

		if (Input.GetButtonDown ("Fire1") && shootScript.canShoot) {
			animWeapon.SetTrigger ("shoot");
			if(shootScript.nbCartridge > 0){
				animFlame.SetTrigger("flame");
			}
		}
			
		if (Input.GetKey (KeyCode.LeftShift)) {
			if (Input.GetAxis ("Vertical") == 0) {
				animWeapon.SetBool ("run", false);
			} else {
				animWeapon.SetBool ("run", true);
			}
		} else {
			animWeapon.SetBool ("run", false);

			if (Input.GetAxis ("Vertical") == 0) {
				animWeapon.SetBool ("walk", false);
			} else {
				animWeapon.SetBool ("walk", true);
			}
		}
	}
}
