using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Loc_CyberCity_Controller : MonoBehaviour {

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

    public void EatReturn(GameObject newScreen) {
        currentScreen.SetActive(false);
        currentScreen = newScreen;
        currentScreen.SetActive(true);
        playerController.PlayerHeal(20);
    }

    public void SadReturn(GameObject newScreen) {
        currentScreen.SetActive(false);
        currentScreen = newScreen;
        currentScreen.SetActive(true);
        playerController.PlayerDamage(5);
    }

	public void GivePassword() { 
		string password = screen3Input.text;
		if (password == "Way") {
			ChangeScreen (screen4);
		} else {
            screen3Text.text = "Неверный пароль";
		}
	}

	public void GetBeatenDamage() {
		playerController.PlayerDamage (10);
	}
		
}
