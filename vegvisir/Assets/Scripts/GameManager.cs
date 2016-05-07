using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
    [SerializeField]
    private VariableManager variables;

    [SerializeField]
    private List<GameObject> listaEventos;
	[SerializeField]
	private List<GameObject> listaNoticias;
	[SerializeField]
	private List<GameObject> listaJuegos;

    [SerializeField]
    private Text morido;
    // Use this for initialization
    [SerializeField]
    private EstadisticasManager estadisticas;
    void Start ()
    {
        this.siguientePaso();
	}
	
    public void siguientePaso()
    {
        variables.variablesNuevoDia();
        lanzarEvento();
        checkVidas();
    }
    void lanzarEvento()
    {
		int bigRandom = Random.Range (0,2);

		if(bigRandom == 0){
			int random = Random.Range(0, listaEventos.Count);
	        listaEventos[random].SetActive(true);
		}else if(bigRandom == 1){
			int random = Random.Range(0, listaNoticias.Count);
			listaNoticias[random].SetActive(true);
		}else if(bigRandom == 2){
			int random = Random.Range(0, listaJuegos.Count);
			listaJuegos[random].SetActive(true);
		}

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

        if (muerto)
        {
            //Guardamos los datos
            PlayerPrefs.SetInt("PoblacionFinal", variables.poblacion);
            PlayerPrefs.SetInt("HambreFinal", variables.hambre);
            PlayerPrefs.SetInt("SangreFinal", variables.sangre);
            PlayerPrefs.SetInt("FiestaFinal", variables.fiesta);

            //Reseteamos los datos
            PlayerPrefs.SetInt("Poblacion", 0);
            PlayerPrefs.SetInt("Hambre", 0);
            PlayerPrefs.SetInt("Sangre", 0);
            PlayerPrefs.SetInt("Fiesta", 0);

            //Aqui ya cambiamos a la escena de intro
            morido.gameObject.SetActive(true);
        }
    }
}
