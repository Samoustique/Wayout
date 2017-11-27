﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dead : MonoBehaviour {

	public GameObject constantAudio;
	public AudioClip soundDead;

	private Animator anim;
	private AIParasite aiParasiteScript;
	private NavMeshAgent agent;
	private CapsuleCollider myCollider;
	private AudioSource audioSource;
	private Rigidbody myRigidbody;
	private bool isDead = false;

	void Start () {
		audioSource = constantAudio.GetComponent<AudioSource> ();
		anim = GetComponent<Animator> ();
		aiParasiteScript = GetComponent<AIParasite>();
		agent = GetComponent<NavMeshAgent>();
		myCollider = GetComponent<CapsuleCollider>();
		myRigidbody = GetComponent<Rigidbody>();
	}

	void Update(){
		if (isDead && myCollider.enabled) {
			float x = myCollider.center.x;
			float y = 0.2f;//myCollider.center.y;
			float z = anim.GetFloat ("colliderZ");
			myCollider.center = new Vector3(x, y, z);
			myCollider.height = 0.8f;
			if (z == -2) {
				StartCoroutine (DisableCollider ());
			}
		}
	}

	public void TargetDead () {
		isDead = true;
		gameObject.tag = "Untagged";
		myRigidbody.isKinematic = false;
		anim.SetTrigger ("dead");
		anim.SetBool ("attack", false);
		aiParasiteScript.enabled = false;
		agent.enabled = false;
		audioSource.Stop();
		audioSource.PlayOneShot(soundDead);
		Destroy (gameObject, 10f);
	}

	public void ActivationIsKinematic(){
		myRigidbody.isKinematic = true;
	}

	IEnumerator DisableCollider(){
		yield return new WaitForSeconds(1.2f);
		myCollider.enabled = false;
	}
}
