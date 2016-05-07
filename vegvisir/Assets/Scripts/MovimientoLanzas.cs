using UnityEngine;
using System.Collections;

public class MovimientoLanzas : MonoBehaviour {

	//private Vector3 velocity = Vector3.zero;
	public float x;
	public float y;


	private Vector3 startPosition; 
	private float startTime;
	private float speed = 2.2F;
	private float journeyLength;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
		startPosition = transform.position;
		journeyLength = Vector3.Distance (startPosition, new Vector3 (x, y, 0));  
	}

	// Update is called once per frame
	void Update () {

		//this.transform.position = Vector3.SmoothDamp (this.transform.position, new Vector3 (0, 0, 0), ref velocity, 4f);

		float distCovered = (Time.time - startTime) * speed;
		float fracJourney = distCovered / journeyLength;
		transform.position = Vector3.Lerp (startPosition, new Vector3 (x, y, 0), fracJourney);

		if (transform.position.x < -10.5f || transform.position.x > 10.5f) {
			Destroy (gameObject);
		}

	}



}
