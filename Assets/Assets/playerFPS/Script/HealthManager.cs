using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour {

	public int life = 100;
	public AudioClip soundPlayerDead;

	private UIManager uiManagerScript;
	private bool isDead = false;

	void Start () {
		uiManagerScript = GameObject.Find("PanelUI").GetComponent<UIManager>();
		uiManagerScript.UpdateLife(life);
	}

	public void playerDamage(int damage){
		life -= damage;
		uiManagerScript.UpdateLife(life);

		if (life <= 0 && !isDead) {
			isDead = true;
			GetComponent<AudioSource>().PlayOneShot(soundPlayerDead);
			GetComponent<PlayerDead>().Die();
		}
	}

	public void playerHeal(int heal){
		life += heal;
		uiManagerScript.UpdateLife(life);
	}
}
