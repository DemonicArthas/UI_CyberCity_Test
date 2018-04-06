using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	public int money;
	public int healPoints;
	public int hungry;

	public Text moneyText;
	public GameObject healPointsPanel;
	Vector3 healPointsPanelBaseCoord;

	void Awake() {
		AddMoney (0);

		healPointsPanelBaseCoord = healPointsPanel.transform.localPosition;
	}

	public void AddMoney(int amount) {
		money += amount;
		if (money < 0)
			money = 0;

		moneyText.text = money.ToString ();
	}

	public void PlayerDamage(int amount) {
		if (amount > 0) {
			healPoints -= amount;
			if (healPoints <= 0) {
				healPoints = 0;
			}

			healPointsPanel.transform.localScale = new Vector3 (healPoints / 100.0f, 1.0f, 1.0f);
			healPointsPanel.transform.localPosition = healPointsPanelBaseCoord;

			if (healPoints <= 0) {
				// TODO player death
			}
		}
	}

	public void PlayerHeal(int amount) {
		if (amount > 0) {
			healPoints += amount;
			if (healPoints > 100) {
				healPoints = 100;
			}

			healPointsPanel.transform.localScale = new Vector3 (healPoints / 100.0f, 1.0f, 1.0f);
			healPointsPanel.transform.localPosition = healPointsPanelBaseCoord;
		}
	}
}
