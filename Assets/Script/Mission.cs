using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mission : MonoBehaviour {
	
	public GameObject panel;
	public bool lockedDoor = true;

	private Text missionTitle;
	private Text missionContent;
	
	void Start () {
		missionTitle = panel.transform.Find ("MissionTitle").GetComponent<Text>();
		missionContent = panel.transform.Find ("MissionContent").GetComponent<Text>();
		StartCoroutine(DisablePanel());
	}
	
	IEnumerator DisablePanel(){
		panel.SetActive(true);
		yield return new WaitForSeconds(5f);
		panel.SetActive(false);
	}

	public void UnlockDoor(){
		lockedDoor = false;
		missionTitle.text = "MISSION:";
		missionContent.text = "Find the way out";
		StartCoroutine(DisablePanel());
	}
	
	public void DisplayLockedDoor(){
		missionTitle.text = "Locked...";
		missionContent.text = "You must find the key";
		StartCoroutine(DisablePanel());
	}
	
	public void MissionFinished(){
		missionTitle.text = "You escaped!";
		missionContent.text = "";
		StartCoroutine(DisablePanel());
	}
}
