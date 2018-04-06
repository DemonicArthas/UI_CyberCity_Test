using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Loc_0_0Controller : MonoBehaviour {

	public Text screen0Text;
	public GameObject currentScreen;
	public Text screen3Input;
	public GameObject screen4;
	public GameObject screen5;
	public Text screen3Text;
	public GameObject player;

	PlayerController playerController;

	void Awake() {
		playerController = player.GetComponent<PlayerController> ();
	}

	public void ChangeScreen(GameObject newScreen) {
		currentScreen.SetActive (false);
		currentScreen = newScreen;
		currentScreen.SetActive (true);
	}

	public void ContinueWaiting () {
		screen0Text.text = "Вы просидели еще день. Что собиретесь делать?";
	}

	public void GiveMoney() { 
		int money = int.Parse (screen3Input.text);
		if (money < 50) {
			ChangeScreen (screen4);
		} else if (money == 50) {
			ChangeScreen (screen5);
		} else {
			screen3Text.text = "У вас нет столько денег";
		}
	}

	public void GetRadiationDamage() {
		playerController.PlayerDamage (10);
	}
		
}
