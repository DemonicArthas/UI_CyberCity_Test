using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public GameObject mapPanel;
	public Text mapLocationTextbox;
	public GameObject locationPanel;
	public GameObject startLocationPanel;

	public Location[] locations;
	private Location currentLocation;

	void Awake () {
		locationPanel.SetActive(true);
		startLocationPanel.SetActive(true);
		mapPanel.SetActive(false);
		SetInitialLocation ();
	}

	void SetInitialLocation() {
		foreach (Location loc in locations) {
			if (loc.locationPanel == startLocationPanel) {
				currentLocation = loc;
				mapLocationTextbox.text = currentLocation.caption;
				break;
			}
		}
	}

	// direction
	// 0 - hold
	// 1 - top
	// 2 - right
	// 3 - bottom
	// 4 - left
	public void Navigate(int direction) {
		int diffX = 0;
		int diffY = 0;

		switch (direction) {
			case 1:
				diffY = 1;
				break;
			case 2:
				diffX = 1;
				break;
			case 3:
				diffY = -1;
				break;
			case 4:
				diffX = -1;
				break;
		}

		foreach (Location loc in locations) {
			if (loc.x == currentLocation.x + diffX && loc.y == currentLocation.y + diffY) {
				ChangeLocation (loc);
				break;
			}
		}

		HideMap ();
	}

	public void HideMap() {
		mapPanel.SetActive (false);
		locationPanel.SetActive (true);
	}

	public void ShowMap() {
		mapPanel.SetActive (true);
		locationPanel.SetActive (false);
	}

	void ChangeLocation(Location newLocation) {
		mapLocationTextbox.text = newLocation.caption;
		currentLocation.locationPanel.SetActive (false);
		newLocation.locationPanel.SetActive (true);

		currentLocation = newLocation;
	}
}

[System.Serializable]
public class Location {
	public GameObject locationPanel;
	public int x;
	public int y;
	public string caption;
}