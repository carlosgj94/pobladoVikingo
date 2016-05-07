using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class VikingoKFC : MonoBehaviour {
    [SerializeField]
    private Text puntosTexto;
    [SerializeField]
    private GameObject morido;
    public int puntos = 0;

    [SerializeField]
    private AudioSource audioS;
    [SerializeField]
    private AudioClip tragarAudio;
    [SerializeField]
    private AudioClip flechasAudio;

    [SerializeField]
    private Text puntuacionFinal;

    public float direction;

    [SerializeField]
    private Text vidasTexto;
    private float vidas = 2;

    private float momment;
	private bool acabado = false;

    [SerializeField]
    private PolloKfc polloObject;
    [SerializeField]
    private PolloKfc flechaObject;

    void start()
    {
        momment = -0.4f;
    }
    // Update is called once per frame
    void Update()
    {

		if (!acabado) {

			direction = Input.GetAxisRaw ("Horizontal");
			if (Input.touchCount > 0) {
				Touch touch = Input.GetTouch (0);
				if (touch.position.x > Screen.width / 2)
					direction = 1;
				if (touch.position.x < Screen.width / 2)
					direction = -1;
			}

			//Cambiamos las sprites

			if (direction == 0) {
            
				this.GetComponent<SpriteRenderer> ().sprite = Resources.Load ("kfc/" + "vikingo03", typeof(Sprite)) as Sprite;
			} else if (direction < 0) {
				this.GetComponent<SpriteRenderer> ().sprite = Resources.Load ("Kfc/" + "vikingo01", typeof(Sprite)) as Sprite;
			} else {
				this.GetComponent<SpriteRenderer> ().sprite = Resources.Load ("Kfc/" + "vikingo02", typeof(Sprite)) as Sprite;
			}
			
			if (Time.time - momment > 0.4) {
				momment = Time.time;
				polloObject.gameObject.SetActive (true);
				flechaObject.gameObject.SetActive (true);
				if (Random.Range (0, 2) == 0)
					Instantiate (polloObject, new Vector3 (0, 0, 0), Quaternion.identity);
				else
					Instantiate (flechaObject, new Vector3 (0, 0, 0), Quaternion.identity);

				//polloObject.gameObject.SetActive(false);
				//flechaObject.gameObject.SetActive(false);
			}
		}
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
		if (!acabado) {
			if (coll.gameObject.tag == "Pollo") {
				//Sumar un punto
				if (coll.gameObject.GetComponent<PolloKfc> ().spawnDirection == direction) {
					puntos++;
					puntosTexto.text = puntos + " Puntos";
					Destroy (coll.gameObject);
					checkAcabado ();
				} else {
					vidas--;
					vidasTexto.text = vidas + " Vidas";
					checkAcabado ();
				}
			} else {
				//Morir
				if (coll.gameObject.GetComponent<PolloKfc> ().spawnDirection == direction) {
					vidas--;
					vidasTexto.text = vidas + " Vidas";
					checkAcabado ();
					Destroy (coll.gameObject);
				}
			}
		}
    }

    private void checkAcabado()
    {
        if(vidas == 0)
        {
			acabado = true;
            morido.gameObject.SetActive(true);
			puntuacionFinal.text = "Has perdido.\n Tu puntuacion ha sido de: " + puntos + "\n El hambre ha disminuido en " + puntos/2;

            PlayerPrefs.SetInt("PuntosKfc", puntos);
			PlayerPrefs.SetInt ("Hambre", PlayerPrefs.GetInt ("Hambre") - puntos / 2);
        }

		if(puntos == 50)
		{
			acabado = true;
			morido.gameObject.SetActive(true);
			puntuacionFinal.text = "Obtenida la puntuación máxima.\n Tu puntuacion ha sido de: " + puntos + "\n El hambre ha disminuido " + puntos/2;
			PlayerPrefs.SetInt("PuntosKfc", puntos);

			if (PlayerPrefs.GetInt ("Hambre") > (puntos / 2)) {
				PlayerPrefs.SetInt ("Hambre", PlayerPrefs.GetInt ("Hambre") - (puntos / 2));
			}else{
				PlayerPrefs.SetInt ("Hambre", 0);
			}
		}

    }
}
