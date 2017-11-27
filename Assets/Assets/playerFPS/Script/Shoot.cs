using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

	public AudioClip soundShoot;
	public AudioClip soundReload;
	public AudioClip soundEmpty;
	public GameObject prefabBulletHole;
	public GameObject prefabSparks;
	public float shootRate = 1f;
	public int nbCartridge;
	public int nbMaxCartridge;
	public int nbMagazine;
	public bool isAutomatic = true;
	
	public bool canShoot = false;
	
	private Ray ray;
	private RaycastHit hit;
	private float nextFire;
	private UIManager uiManagerScript;
	
	void Start(){
		uiManagerScript = GameObject.Find("PanelUI").GetComponent<UIManager>();
		uiManagerScript.UpdateTxtCartridgeMagazine(nbCartridge, nbMaxCartridge, nbMagazine);
	}
	
	void OnEnable(){
		if(uiManagerScript != null){
			uiManagerScript.UpdateTxtCartridgeMagazine(nbCartridge, nbMaxCartridge, nbMagazine);
		}
	}
	
	void Update () {
		canShoot = Time.time > nextFire;

		if((isAutomatic && Input.GetButton("Fire1") || 
			!isAutomatic && Input.GetButtonDown("Fire1")) &&
			nbCartridge > 0){
			Fire();
		} else if(Input.GetButton("Fire1") && nbCartridge == 0){
			FireButEmpty();
		}
		
		if(Input.GetKeyDown(KeyCode.R) &&
			nbMagazine > 0 &&
			nbCartridge < nbMaxCartridge){
			StartCoroutine(Reload());
		}
	}
	
	private void Fire(){		
		if (canShoot){
			nextFire = Time.time + shootRate;
			GetComponent<AudioSource>().PlayOneShot(soundShoot);
			nbCartridge--;
			uiManagerScript.UpdateTxtCartridge(nbCartridge, nbMaxCartridge);
			Vector2 screenCenterPoint = new Vector2(Screen.width / 2, Screen.height / 2);
			ray = Camera.main.ScreenPointToRay(screenCenterPoint);

			if(Physics.Raycast(ray, out hit, Camera.main.farClipPlane)){
				// Something has been hit
				if(hit.transform.gameObject.tag == "Target"){
					hit.transform.gameObject.GetComponent<Dead> ().TargetDead ();
				} else if(hit.transform.gameObject.tag == "Props"){
					// bullet hole
					GameObject bulletHole = Instantiate(prefabBulletHole, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal)) as GameObject;
					Destroy(bulletHole, 20f);
					
					// sparks
					GameObject sparks = Instantiate(prefabSparks, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal)) as GameObject;
					Destroy(sparks, 3f);
				}
			}
		}
	}
	
	private void FireButEmpty(){
		if (Time.time > nextFire){
			nextFire = Time.time + shootRate;
			GetComponent<AudioSource>().PlayOneShot(soundEmpty);
		}
	}
	
	private IEnumerator Reload(){
		GetComponent<AudioSource>().PlayOneShot(soundReload);
		yield return new WaitForSeconds(0.2f);
		nbMagazine--;
		nbCartridge = nbMaxCartridge;
		uiManagerScript.UpdateTxtCartridgeMagazine(nbCartridge, nbMaxCartridge, nbMagazine);
	}
	
	public void AddMagazine(){
		nbMagazine++;
		uiManagerScript.UpdateTxtCartridgeMagazine(nbCartridge, nbMaxCartridge, nbMagazine);
	}
}
