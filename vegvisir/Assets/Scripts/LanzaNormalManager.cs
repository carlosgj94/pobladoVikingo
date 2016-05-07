using UnityEngine;
using System.Collections;

public class LanzaNormalManager : MonoBehaviour {

	public LanzaManecilla lanzaManecilla;
	public Rigidbody2D rb;
	Quaternion rotation;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}

	void Update (){
		rb.AddForce (gameObject.transform.up.normalized*100);
	}

}
