using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
	public List<GameObject> buttons;

	private int index = 0; // index of selected button
	private GameObject selector;
	private bool moveSelector = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per fram
	void Click() {
		// color
		buttons[index].GetComponent<Image>().CrossFadeColor(Color.gray, 0.25f, true, true);

		// operation
		switch (index) {
			case 1:
				break;
			case 2:
				break;

		}


	}
	void Update() {
		if ((int)Input.GetAxis("Vertical") !=0) {
			index += (int)Input.GetAxis("Vertical");
			moveSelector = true;
		}
		
		
		// if selector not on button, move towards it.
		if (moveSelector) {
			// move towards
			selector.transform.position = Vector3.MoveTowards(selector.transform.position, buttons[index].transform.position, 10 * Time.deltaTime);
			if(Vector3.Distance(selector.transform.position, buttons[index].transform.position) < 0.01f) {
				selector.transform.position = buttons[index].transform.position;
				moveSelector = false;
			}
		}

		//on A pressed, --> click()
		if (Input.GetButtonDown("a")) {
			Click();
		}
	}
}
