using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BarcoEnemigo : MonoBehaviour {

	private GameObject barcoJugador;

	//private Vector3 velocity = Vector3.zero;

	private Vector3 startPosition; 
	private float startTime;
	private float speed = 2.2F;
	private float journeyLength;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
		startPosition = transform.position;
		journeyLength = Vector3.Distance (startPosition, new Vector3 (0, 0, 0));
		barcoJugador = GameObject.FindGameObjectWithTag("BarcoVikingo");   
	}
	
	// Update is called once per frame
	void Update () {
		
		//this.transform.position = Vector3.SmoothDamp (this.transform.position, new Vector3 (0, 0, 0), ref velocity, 4f);

		float distCovered = (Time.time - startTime) * speed;
		float fracJourney = distCovered / journeyLength;
		transform.position = Vector3.Lerp (startPosition, new Vector3 (0, 0, 0), fracJourney);
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "Lanza") {
			Destroy (coll.gameObject);
			Destroy (gameObject);
			barcoJugador.GetComponent<juegoBarcos>().aumentarPuntuacion();

		}
	}
		
}


