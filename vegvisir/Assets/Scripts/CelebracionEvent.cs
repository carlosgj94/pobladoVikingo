using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class CelebracionEvent : MonoBehaviour {
	
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

	private List<string> fiesta = new List<string>{"Yule", "Blot", "San Fermin", "la Feria de Abril","Hanukkah"};
	// Use this for initialization
	void Start () {
		int random = Random.Range(0, fiesta.Count);
		titulo.text = "Fiesta de " +fiesta[random];
		contenido.text = "Las fechas indican fiesta y las ganas nunca faltan en el pueblo. ¿La liamos?";

		botonTexto1.text = "Como si fuera Ragnarök";
		botonTexto2.text = "Una hidromiel y a casa";
		botonTexto3.text = "No, mañana hay que saquear";
	}
	void OnEnable()
	{
		int random = Random.Range(0, fiesta.Count);
		titulo.text = "Fiesta de " +fiesta[random];
		contenido.text = "Las fechas indican fiesta y las ganas nunca faltan en el pueblo. ¿La liamos?";

		botonTexto1.text = "Como si fuera Ragnarök";
		botonTexto2.text = "Una hidromiel y a casa";
		botonTexto3.text = "Nada, mañana hay que saquear";
	}

	public void ragnarokClick()
	{
		int fiesta = Random.Range(2, 9);
		int poblacion = Random.Range(40, 61);
		int sangre = Random.Range(3, 5);
		variables.disminuirFiesta(fiesta);
		variables.disminuirPoblacion(poblacion);
		variables.aumentarHambre(sangre);
		resultado.gameObject.SetActive(true);
		resultado.refresh(0-poblacion, sangre, 0, 0-fiesta);
		this.gameObject.SetActive(false);

	}

	public void hidromielClick()
	{
		int fiesta = Random.Range(1, 7);
		int poblacion = Random.Range(30, 41);
		int sangre = Random.Range(3, 5);
		variables.disminuirFiesta(fiesta);
		variables.disminuirPoblacion(poblacion);
		variables.aumentarHambre(sangre);
		resultado.gameObject.SetActive(true);
		resultado.refresh(0-poblacion, sangre, 0, 0-fiesta);
		this.gameObject.SetActive(false);
	}

	public void nadaClick()
	{
		int hambre = Random.Range(3, 5);
		variables.aumentarHambre(hambre);
		resultado.gameObject.SetActive(true);
		resultado.refresh(0, 0, hambre, 0);
		this.gameObject.SetActive(false);
	}
}