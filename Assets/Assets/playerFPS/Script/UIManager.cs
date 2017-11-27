using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public Image imgLife;
	public Text txtLife;
	public Text txtCartridge;
	public Text txtMagazine;
	public GameObject bloodScreen;

	private CanvasGroup bloodCanvas;

	void Start () {
		bloodCanvas = bloodScreen.GetComponent<CanvasGroup> ();
	}

	public void UpdateTxtCartridgeMagazine (int nbCartridge, int nbMaxCartridge, int nbMagazine) {
		txtCartridge.text = "AMMO " + nbCartridge + "/" + nbMaxCartridge;
		txtMagazine.text = "MAG " + nbMagazine;
	}
	
	public void UpdateTxtCartridge (int nbCartridge, int nbMaxCartridge) {
		txtCartridge.text = "AMMO " + nbCartridge + "/" + nbMaxCartridge;
	}
	
	public void UpdateLife (int life) {
		life = Mathf.Clamp(life, 0, 100);
		imgLife.fillAmount = (float)life / 100;
		txtLife.text = life + "%";

		// blood screen
		if (life <= 0) {
			bloodCanvas.alpha = 1f;
		} else if (life >= 80) {
			bloodCanvas.alpha = 0f;
		} else if (life >= 60) {
			bloodCanvas.alpha = 0.2f;
		} else if (life >= 40) {
			bloodCanvas.alpha = 0.3f;
		} else if (life >= 20) {
			bloodCanvas.alpha = 0.5f;
		}
	}
}
