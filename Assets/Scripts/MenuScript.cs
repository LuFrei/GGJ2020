using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
	public List<GameObject> buttons;
	public List<Sprite> select;
	public List<Sprite> press;
	private List<Sprite> norm;

	public bool isCreds = false;
	public GameObject creds;
	private int index = 0; // index of selected button
	private bool menuSwitch = false;
	private GameObject selector;
    // Start is called before the first frame update
    void Start()
    {
		norm = new List<Sprite>();
		for(int i = 0; i<buttons.Count; i++) { norm.Add(buttons[i].GetComponent<Image>().sprite); }
    }

	// Update is called once per fram
	void Transition() { SceneManager.LoadScene("BattleScene1"); }
	void Quit() { Application.Quit(); }
	void Click() {
		// color


		// operation
		switch (index) {
			case 0:
				Invoke("Transition", 0.25f);
				Debug.Log("ToScene!");
				break;

			case 1:
				isCreds = true;
				creds.SetActive(true);
				break;
			case 2:
				Invoke("Quit", 0.2f);
				Debug.Log("Quit");
				break;

		}


	}
	void MenuSwitch() { menuSwitch = false; }
	void Update() {
		if (!isCreds && !menuSwitch) {
			if ((int)Input.GetAxis("P1Vert") != 0) {
				buttons[index].GetComponent<Image>().sprite = norm[index];
				index -= (int)Input.GetAxis("P1Vert");
				if (index > 2) { index = 0; }
				if (index < 0) { index = 2; }
				buttons[index].GetComponent<Image>().sprite = select[index];
				menuSwitch = true;
				Invoke("MenuSwitch", 0.5f);
			}


			// if selector not on button, move towards it.


			//on A pressed, --> click()
			if (!Input.GetButton("P1A")) { buttons[index].GetComponent<Image>().sprite = select[index]; }
			if (Input.GetButtonDown("P1A")) {
				buttons[index].GetComponent<Image>().sprite = press[index];
				Click();
			}
		} else {
			if (Input.GetButtonDown("P1A")) {
				isCreds = false;
				creds.SetActive(false);
			}
		}

	}
}
