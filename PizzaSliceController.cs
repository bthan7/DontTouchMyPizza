using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaSliceController : MonoBehaviour {


	public GameObject[] pizzaSlices;


	private GameManager m_GameManagerRef;

	private int m_TempHealth;

	// Use this for initialization
	void Start () {

		m_GameManagerRef = GameObject.FindWithTag ("GAME MANAGER").GetComponent<GameManager> ();

		m_TempHealth = m_GameManagerRef.health;
		UpdateSlices ();
	}
	
	// Update is called once per frame
	void Update () {


		if (m_GameManagerRef.health != m_TempHealth) {
			UpdateSlices ();
			m_TempHealth = m_GameManagerRef.health;		
		}
			

	}

	public void UpdateSlices(){


		switch (m_GameManagerRef.health) {
		case 6:
			
			pizzaSlices[0].SetActive(true);
			pizzaSlices[1].SetActive(true);
			pizzaSlices[2].SetActive(true);
			pizzaSlices[3].SetActive(true);
			pizzaSlices[4].SetActive(true);
			pizzaSlices[5].SetActive(true);
			break;

		case 5:

			pizzaSlices[0].SetActive(false);
			pizzaSlices[1].SetActive(true);
			pizzaSlices[2].SetActive(true);
			pizzaSlices[3].SetActive(true);
			pizzaSlices[4].SetActive(true);
			pizzaSlices[5].SetActive(true);
			break;

		case 4:

			pizzaSlices[0].SetActive(false);
			pizzaSlices[1].SetActive(false);
			pizzaSlices[2].SetActive(true);
			pizzaSlices[3].SetActive(true);
			pizzaSlices[4].SetActive(true);
			pizzaSlices[5].SetActive(true);
			break;

		case 3:

			pizzaSlices[0].SetActive(false);
			pizzaSlices[1].SetActive(false);
			pizzaSlices[2].SetActive(false);
			pizzaSlices[3].SetActive(true);
			pizzaSlices[4].SetActive(true);
			pizzaSlices[5].SetActive(true);
			break;

		case 2:

			pizzaSlices[0].SetActive(false);
			pizzaSlices[1].SetActive(false);
			pizzaSlices[2].SetActive(false);
			pizzaSlices[3].SetActive(false);
			pizzaSlices[4].SetActive(true);
			pizzaSlices[5].SetActive(true);
			break;

		case 1:

			pizzaSlices[0].SetActive(false);
			pizzaSlices[1].SetActive(false);
			pizzaSlices[2].SetActive(false);
			pizzaSlices[3].SetActive(false);
			pizzaSlices[4].SetActive(false);
			pizzaSlices[5].SetActive(true);
			break;

		case 0:

			pizzaSlices[0].SetActive(false);
			pizzaSlices[1].SetActive(false);
			pizzaSlices[2].SetActive(false);
			pizzaSlices[3].SetActive(false);
			pizzaSlices[4].SetActive(false);
			pizzaSlices[5].SetActive(false);
			break;

	
			default :

			pizzaSlices[0].SetActive(false);
			pizzaSlices[1].SetActive(false);
			pizzaSlices[2].SetActive(false);
			pizzaSlices[3].SetActive(false);
			pizzaSlices[4].SetActive(false);
			pizzaSlices[5].SetActive(false);
			break;

		}
	}

}
