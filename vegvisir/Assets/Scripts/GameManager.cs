using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	
    [SerializeField]
    private VariableManager variables;
    [SerializeField]
    private List<GameObject> listaEventos;
	[SerializeField]
	private List<GameObject> listaNoticias;
	[SerializeField]
	private List<GameObject> listaJuegos;
    // Use this for initialization
    [SerializeField]
    private EstadisticasManager estadisticas;
	[SerializeField]
	private GameObject morido;
	public Text contenido;

    void Start ()
    {
        this.siguientePaso();
	}
	
    public void siguientePaso()
    {
        variables.variablesNuevoDia();
        checkVidas();

    }
    void lanzarEvento()
    {
        if (variables.dias % 5 == 0)
        {
            SceneManager.LoadScene("Aldea");
        }
        else {
            int bigRandom = Random.Range(0, 10);

            if (bigRandom <= 5)
            {
                int random = Random.Range(0, listaEventos.Count);
                listaEventos[random].SetActive(true);
            }
            else if (bigRandom <= 10)
            {
                int random = Random.Range(0, listaNoticias.Count);
                listaNoticias[random].SetActive(true);
            }
        }
        /*else if(bigRandom <= 9){
			int random = Random.Range(0, listaJuegos.Count);
			listaJuegos[random].SetActive(true);
		}*/

    }
    void checkVidas()
    {
        bool muerto = false;
        if (variables.poblacion <= 0)
            muerto = true;
        else if (variables.hambre >= 100)
            muerto = true;
        else if (variables.sangre >= 100)
            muerto = true;
        else if (variables.fiesta >= 100)
            muerto = true;

		if (muerto) {
			morido.gameObject.SetActive (true);
			contenido.text = "No has conseguido gobernar bien a tu pueblo. \nHas perdido.";

			//Guardamos los datos
			PlayerPrefs.SetInt ("PoblacionFinal", variables.poblacion);
			PlayerPrefs.SetInt ("HambreFinal", variables.hambre);
			PlayerPrefs.SetInt ("SangreFinal", variables.sangre);
			PlayerPrefs.SetInt ("FiestaFinal", variables.fiesta);
			//Reseteamos los datos
			PlayerPrefs.SetInt ("Poblacion", 1000);
			PlayerPrefs.SetInt ("Hambre", 0);
			PlayerPrefs.SetInt ("Sangre", 0);
			PlayerPrefs.SetInt ("Fiesta", 0);
			PlayerPrefs.SetInt ("Dias", 0);

			muerto = false;
		} else {
			lanzarEvento();
		}
    }
}
