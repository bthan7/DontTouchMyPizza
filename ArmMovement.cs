using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ArmMovement : MonoBehaviour {

	public Transform target, slapSpawnPoint;

	public float speed;

	public bool isMovingToPizza;

	public Sprite pizzaHoldingSprite, redHand;

	public GameObject ketchup, Slap;



	private bool holdingPizza;

	private bool slaped;

	private float tempSpeed;

	private float rotateSpeed = 2000f;

	private AudioManager m_AudioManagerRef;

	private GameManager m_GameManagerRef;

	private Rigidbody2D rb;


	// Use this for initialization
	void Start () {

		m_GameManagerRef = GameObject.FindWithTag("GAME MANAGER").GetComponent<GameManager>();

		m_AudioManagerRef = GameObject.FindWithTag ("AUDIO MANAGER").GetComponent<AudioManager> ();

		target = GameObject.FindWithTag ("TARGET").GetComponent<Transform> ();




		speed = Random.Range (1F, 4F);

		rb = GetComponent<Rigidbody2D>();

		isMovingToPizza = true;



	}

	void Update(){

		if (GameManager.gameOver) {
		
			isMovingToPizza = false;
			Destroy (gameObject, 3F);
		}
	}

	
	void FixedUpdate () {


		if (isMovingToPizza) {
			Vector2 direction = (Vector2)target.position - rb.position;

			direction.Normalize ();

			float rotateAmount = Vector3.Cross (direction, transform.up).z;

			rb.angularVelocity = rotateAmount * rotateSpeed;

			rb.velocity = transform.up * -speed;
		} else {
		
			rb.velocity = transform.up * speed * 2;
		
		}
			

	}

	void OnTriggerEnter2D ()
	{
		holdingPizza = true;
		GetComponent<SpriteRenderer> ().sprite = pizzaHoldingSprite;
		ketchup.SetActive (true);
		m_GameManagerRef.health--;

		if (DataManager.LoadVibrationStatus() && VibrationManager.supportingHaptic) {
			VibrationManager.VibrationFail ();
		}
			
		StartCoroutine (GoBack ());

		Destroy (gameObject, 3F);

	}


	void OnMouseOver(){
	
		if (!holdingPizza && !slaped && Input.GetMouseButtonDown (0)) {
		
			slaped = true;
		
			m_AudioManagerRef.PlaySlap ();

			Destroy (Instantiate (Slap, slapSpawnPoint.position, slapSpawnPoint.rotation), 1);

			GetComponent<SpriteRenderer> ().sprite = redHand;

			if(DataManager.LoadVibrationStatus() && VibrationManager.supportingHaptic){
				VibrationManager.VibrationArmHit ();
			}


			StartCoroutine (GoBack ());

			Destroy (gameObject, 3F);


		}
	
	}

	IEnumerator GoBack(){

		tempSpeed = speed;
		speed = 0;

		yield return new WaitForSeconds (0.2F);

		isMovingToPizza = false;
		speed = tempSpeed;
		
	}
}