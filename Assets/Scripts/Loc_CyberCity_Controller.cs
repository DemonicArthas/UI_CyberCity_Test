using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Loc_CyberCity_Controller : MonoBehaviour {

	public GameObject currentScreen;
    public GameObject alleyEmpty;
    public GameObject alleyDefault;
    public GameObject outpostScreen;
    public GameObject player;
    public Button passwordButton;
    public bool passwordKnown;
    public GameObject BGImage;
    public GameObject ShineBG;
    PlayerController playerController;

	void Awake() {
		playerController = player.GetComponent<PlayerController> ();
        passwordKnown = false;
    }

	public void ChangeScreen(GameObject newScreen) {
		currentScreen.SetActive (false);
		currentScreen = newScreen;
		currentScreen.SetActive (true);
	}

    public void EatReturn(GameObject newScreen) {
        if (playerController.money > 10) {
            currentScreen.SetActive(false);
            currentScreen = newScreen;
            currentScreen.SetActive(true);
            playerController.AddMoney(-20);
            playerController.PlayerHeal(20);
        }
    }

    public void SadReturn(GameObject newScreen) {
        playerController.PlayerDamage(1);
        currentScreen.SetActive(false);
        currentScreen = newScreen;
        currentScreen.SetActive(true);
    }

    public void GoToAlley() {
        if (passwordKnown == true) {
            ChangeScreen(alleyEmpty);
        }
        else {
            ChangeScreen(alleyDefault);
        }
    }

    public void PasswordBuy(GameObject newScreen)
    {
        if (playerController.money > 75)
        {
            passwordKnown = true;
            currentScreen.SetActive(false);
            currentScreen = newScreen;
            currentScreen.SetActive(true);
        }
    }

    public void PasswordTake(GameObject newScreen) {
        passwordKnown = true;
        playerController.PlayerDamage(15);
            currentScreen.SetActive(false);
            currentScreen = newScreen;
            currentScreen.SetActive(true);
        }

     public void PasswordCheck() { 
		if (passwordKnown == true) {
            passwordButton.interactable = true;
        }
        ChangeScreen(outpostScreen);
    }

	public void GetBeatenScreen(GameObject newScreen) {
		playerController.PlayerDamage (10);
        currentScreen.SetActive(false);
        currentScreen = newScreen;
        currentScreen.SetActive(true);
    }

    public void EscapeBG(GameObject newBGImage)
    {
        BGImage.SetActive(false);
        BGImage = newBGImage;
        BGImage.SetActive(true);
    }
    public void EscapeScreen(GameObject newScreen) {
        EscapeBG (ShineBG);
        currentScreen.SetActive(false);
        currentScreen = newScreen;
        currentScreen.SetActive(true);
    }

}
