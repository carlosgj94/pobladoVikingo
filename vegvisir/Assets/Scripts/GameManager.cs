using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
    [SerializeField]
    private VariableManager variables;

    [SerializeField]
    private List<GameObject> listaEventos;
	// Use this for initialization
	void Start () {
        this.siguientePaso();
	}
	
    public void siguientePaso()
    {
        variables.variablesNuevoDia();
        lanzarEvento();
    }
    void lanzarEvento()
    {
        int random = Random.Range(0, listaEventos.Count);
        listaEventos[random].SetActive(true);

    }
}
