using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject objectToSpawn;
	public GameObject player;
	public float distanceSpawn = 50f;
	public float spawnRate = 2f;
	public float destroyTime = -1f;
	
	private float nextSpawn;
	private int idCloned = 0;
	
	void Update () {
		float distance = Vector3.Distance(player.transform.position, transform.position);
		
		if(distance < distanceSpawn && Time.time > nextSpawn){
			nextSpawn = Time.time + spawnRate;
			GameObject cloned = Instantiate(objectToSpawn, transform.position, Quaternion.identity);
			cloned.name += idCloned++;
			if(destroyTime > 0){
				Destroy(cloned, destroyTime);
			}
		}
	}
}
