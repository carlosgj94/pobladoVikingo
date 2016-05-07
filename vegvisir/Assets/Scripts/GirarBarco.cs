using UnityEngine;
using System.Collections;

public class GirarBarco : MonoBehaviour {

	public float newAngle;

	// Use this for initialization
	void Start () {
		gameObject.transform.Rotate (0, 0, newAngle);
	}
	

}
