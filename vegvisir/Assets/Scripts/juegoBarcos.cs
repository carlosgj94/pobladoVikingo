using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class juegoBarcos : MonoBehaviour {



	private float momment;
	private bool acabado = false;

	public GameObject cartel;
	public Text puntuacionFinal;
	public Text textoVidas;
	public Text textoPuntuacion;

	public GameObject barcoEnemigo1, barcoEnemigo2;

	private int vidas = 3;
	public int puntos = 0;

	// Use this for initialization
	void Start () {
		momment = -0.4f;
	}
	
	// Update is called once per frame
	void Update () {
		if (!acabado) {
			if (Time.time - momment > 1.5) {
				momment = Time.time;
				int random = Random.Range (0, 4);
				if (random == 0) {
					Instantiate (barcoEnemigo1, new Vector3 (-11, 6.5f, 0), Quaternion.identity);
				}
				if (random == 1) {
					Instantiate (barcoEnemigo1, new Vector3 (11, -6.5f, 0), Quaternion.identity);
				}
				if (random == 2) {
					Instantiate (barcoEnemigo2, new Vector3 (-11, -6.5f, 0), Quaternion.identity);
				}
				if (random == 3) {
					Instantiate (barcoEnemigo2, new Vector3 (11, 6.5f, 0), Quaternion.identity);
				}
			}
		}

	}

	void OnTriggerEnter2D(Collider2D coll){
		if (!acabado) {
			if (coll.gameObject.tag == "BarcoEnemigo") {
				//Bajar una vida
				Destroy (coll.gameObject);
				vidas--;
				textoVidas.text = vidas + " vidas";
				checkAcabado ();
			}
		}
	}

	void checkAcabado (){
		
		if(vidas == 0)
		{
			acabado = true;
			cartel.gameObject.SetActive(true);
			puntuacionFinal.text = "Has perdido.\n Tu puntuacion ha sido de: " + puntos + "\n El ansia de sangre ha disminuido " + puntos/2;

            PlayerPrefs.SetInt("PuntosBarco", puntos);
            if (PlayerPrefs.GetInt("Sangre") > (puntos / 2))
            {
                PlayerPrefs.SetInt("Sangre", PlayerPrefs.GetInt("Sangre") - puntos / 2);
            }
            else {
                PlayerPrefs.SetInt("Sangre", 0);
            }
        }

		if(puntos == 50){
			acabado = true;
			cartel.gameObject.SetActive(true);
			puntuacionFinal.text = "Has alzanzado la puntuación máxima.\n Tu puntuacion ha sido de: " + puntos + "\n El ansia de sangre ha disminuido " + puntos/2;

			PlayerPrefs.SetInt("PuntosBarco", puntos);
			if(PlayerPrefs.GetInt ("Sangre")>(puntos/2)){
				PlayerPrefs.SetInt ("Sangre", PlayerPrefs.GetInt ("Sangre") - puntos / 2);
			}else{
				PlayerPrefs.SetInt ("Sangre", 0);
			}
		}
	}

	public void aumentarPuntuacion(){
		puntos += 1;
		textoPuntuacion.text = puntos + " puntos";
		checkAcabado ();
	} 

}
