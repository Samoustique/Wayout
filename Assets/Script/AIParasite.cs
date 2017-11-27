using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIParasite : MonoBehaviour {

	public AudioClip soundAttack;
	public float distanceWalk = 10f;
	public float distanceAttack = 2f;
	public int damage = 10;
	public float minSpeed = 1f;
	public float maxSpeed = 2f;
	[SerializeField]
	public float distanceCurrent;

	private GameObject target;
	private NavMeshAgent agent;
	private Animator anim;
	private AudioSource audioSource;
	private HealthManager healthManagerScript;

	void Start () {
		audioSource = GetComponent<AudioSource> ();
		anim = GetComponent<Animator> ();
		GameObject firstPersonCharacter = GameObject.Find("FirstPersonCharacter");
		if(firstPersonCharacter != null){
			healthManagerScript = firstPersonCharacter.GetComponent<HealthManager> ();	
		}
		target = GameObject.Find("FPSController");
		agent = GetComponent<NavMeshAgent> ();
		agent.speed = Random.Range (minSpeed, maxSpeed);
	}

	void Update () {
		distanceCurrent = Vector3.Distance (target.transform.position, transform.position);
		if (distanceCurrent < distanceWalk) {
			anim.SetBool ("walk", true);
			anim.SetBool ("attack", false);
			agent.SetDestination (target.transform.position);

			if (distanceCurrent < distanceAttack) {
				anim.SetBool ("attack", true);
				// stay still
				agent.SetDestination (transform.position);
			}
		} else {
			anim.SetBool ("walk", false);
			anim.SetBool ("attack", false);
			// stay still
			agent.SetDestination (transform.position);
		}
	}

	public void DamageToPlayer(){
		audioSource.PlayOneShot (soundAttack);
		healthManagerScript.playerDamage (damage);
	}
}
