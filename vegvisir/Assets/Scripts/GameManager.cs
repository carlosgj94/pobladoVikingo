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
    private Text morido;
	// Use this for initialization
	void Start () {
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
        int random = Random.Range(0, listaEventos.Count);
        listaEventos[random].SetActive(true);

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
            PlayerPrefs.SetInt("PoblacionFinal", 0);
            PlayerPrefs.SetInt("HambreFinal", 0);
            PlayerPrefs.SetInt("SangreFinal", 0);
            PlayerPrefs.SetInt("FiestaFinal", 0);

            //Aqui ya cambiamos a la escena de intro
            morido.gameObject.SetActive(true);
        }
    }
}
