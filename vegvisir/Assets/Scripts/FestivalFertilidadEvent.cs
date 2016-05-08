using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class FestivalFertilidadEvent : MonoBehaviour {
	//Textos
	[SerializeField]
	private Text titulo;
	[SerializeField]
	private Text contenido;
	[SerializeField]
	private Text botonTexto1;
	[SerializeField]
	private Text botonTexto2;
	[SerializeField]
	private Text botonTexto3;

	[SerializeField]
	private VariableManager variables;

	[SerializeField]
	private GameManager gameManager;

	[SerializeField]
	private ResultadoEvento resultado;

	// Use this for initialization
	void Start () {
		titulo.text = "Festival de la fertilidad";
		contenido.text = "Ha llegado la hora de celebrar el festival de la fertilidad. ¿Qué vamos a hacer?";

		botonTexto1.text = "¡Lluvia de niños!";
		botonTexto2.text = "Sin pasarse";
		botonTexto3.text = "A dormir";
	}

	void OnEnable()
	{
		titulo.text = "Festival de la fertilidad";
		contenido.text = "Ha llegado la hora de celebrar el festival de la fertilidad. ¿Qué vamos a hacer?";

		botonTexto1.text = "¡Lluvia de niños!";
		botonTexto2.text = "Sin pasarse";
		botonTexto3.text = "A dormir";
	}
	public void lluviaClick()
	{
		int poblacion = Random.Range(20, 91);
		int hambre = Random.Range(4, 7);
		int fiesta = Random.Range(3, 5);

		variables.aumentarPoblacion(poblacion);
		variables.aumentarHambre(hambre);
		variables.aumentarFiesta(fiesta);
		resultado.gameObject.SetActive(true);
		resultado.refresh(poblacion, hambre, 0, fiesta);
		this.gameObject.SetActive(false);

	}

	public void pasarseClick()
	{
		int poblacion = Random.Range(10, 61);
		int hambre = Random.Range(3, 5);
		int fiesta = Random.Range(3, 5);
		variables.aumentarHambre(hambre);
		variables.aumentarFiesta(fiesta);
		resultado.gameObject.SetActive(true);
		resultado.refresh(poblacion, hambre, 0, fiesta);
		this.gameObject.SetActive(false);
	}

	public void dormirClick()
	{
		int sangre = Random.Range(2, 4);
		variables.aumentarSangre(sangre);
		resultado.gameObject.SetActive(true);
		resultado.refresh(0, 0, sangre, 0);
		this.gameObject.SetActive(false);
	}
}
