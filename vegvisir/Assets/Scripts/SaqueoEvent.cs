using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class SaqueoEvent : MonoBehaviour {

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

	private List<string> saqueados = new List<string>{"la aldea vecina", "a tu suegra", "un almacen de cascos con cuernos", "la península ibérica"};
	// Use this for initialization
	void Start () {
		int random = Random.Range(0, saqueados.Count);
		titulo.text = "Saquear " +saqueados[random];
		contenido.text = "Un buen saqueo calma a nuestras gentes y nos arroja unos ricos benificios. Vamos, ¿no?";

		botonTexto1.text = "No dejéis ni las paredes";
		botonTexto2.text = "Un buen saqueo no hace daño";
		botonTexto3.text = "Otro día si eso ...";
	}
	void OnEnable()
	{
		int random = Random.Range(0, saqueados.Count);
		titulo.text = "Saquear " +saqueados[random];
		contenido.text = "Un buen saqueo calma a nuestras gentes y nos arroja unos ricos benificios. Vamos, ¿no?";

		botonTexto1.text = "No dejéis ni las paredes";
		botonTexto2.text = "Un buen saqueo no hace daño";
		botonTexto3.text = "Otro día si eso ...";
	}

	public void paredesClick()
	{
		int sangre = Random.Range(2, 9);
		int poblacion = Random.Range(40, 61);
		int hambre = Random.Range(3, 5);

		variables.disminuirSangre(sangre);
		variables.disminuirPoblacion(poblacion);
		variables.aumentarHambre(hambre);
		resultado.gameObject.SetActive(true);
		resultado.refresh(0-poblacion, 0-sangre, hambre, 0);
		this.gameObject.SetActive(false);

	}

	public void saqueoClick()
	{
		int sangre = Random.Range(1,7);
		int poblacion = Random.Range(30, 41);
		int hambre = Random.Range(3,5);

		variables.disminuirSangre(sangre);
		variables.disminuirPoblacion(poblacion);
		variables.aumentarHambre(hambre);
		resultado.gameObject.SetActive(true);
		resultado.refresh(0-poblacion, 0-sangre, hambre, 0);
		this.gameObject.SetActive(false);
	}

	public void otroClick()
	{
		int fiesta = Random.Range(3, 5);
		variables.aumentarFiesta(fiesta);
		resultado.gameObject.SetActive(true);
		resultado.refresh(0, 0, 0, fiesta);
		this.gameObject.SetActive(false);
	}
}