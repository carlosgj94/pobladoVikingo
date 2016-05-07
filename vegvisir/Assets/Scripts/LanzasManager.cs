using UnityEngine;
using System.Collections;

public class LanzasManager : MonoBehaviour {

	public float momment;

	void Start () {
		momment = -1f;
	}

	void Update (){
		
	}

	public GameObject lanzaArribaIzq, lanzaAbajoIzq, lanzaArribaDer, lanzaAbajoDer;

	public void lanzaArribaIzqClick (){
		if (Time.time - momment > 1) {
			momment = Time.time;
			Instantiate (lanzaArribaIzq, new Vector3 (-1, 1, 0), Quaternion.identity);
		}

	}

	public void lanzaAbajoIzqClick (){
		if (Time.time - momment > 1) {
			momment = Time.time;
			Instantiate (lanzaAbajoIzq, new Vector3 (-1, -1, 0), Quaternion.identity);
		}

	}

	public void lanzaArribaDerClick (){
		if (Time.time - momment > 1) {
			momment = Time.time;
			Instantiate (lanzaArribaDer, new Vector3 (1, 1, 0), Quaternion.identity);
		}

	} 

	public void lanzaAbajoDerClick (){
		if (Time.time - momment > 1) {
			momment = Time.time;
			Instantiate (lanzaAbajoDer, new Vector3 (1, -1, 0), Quaternion.identity);
		}

	}
		

	
}
