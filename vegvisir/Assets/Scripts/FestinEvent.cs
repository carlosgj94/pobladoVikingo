using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class FestinEvent : MonoBehaviour {
	
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

	private List<string> comida = new List<string>{"ganso", "salmón ahumado", "queso y miel", "hipters"};
	// Use this for initialization
	void Start () {
		int random = Random.Range(0, comida.Count);
		titulo.text = "Festín de " +comida[random];
		contenido.text = "Para los vikingos los festines son algo casi tan serio como las batallas. ¿Cómo nos lo montamos?";

		botonTexto1.text = "Festín opulento";
		botonTexto2.text = "Festín de tranquis";
		botonTexto3.text = "Cada uno en su casa";
	}
	void OnEnable()
	{
		int random = Random.Range(0, comida.Count);
		titulo.text = "Festín de " +comida[random];
		contenido.text = "Para los vikingos los festines son algo casi tan serio como las batallas. ¿Cómo nos lo montamos?";

		botonTexto1.text = "Festín opulento";
		botonTexto2.text = "Festín de tranquis";
		botonTexto3.text = "Cada uno en su casa";
	}

	public void opulentoClick()
	{
		int hambre = Random.Range(4, 9);
		int fiesta = Random.Range(3, 7);
		int sangre = Random.Range(2, 5);
		variables.disminuirHambre(hambre);
		variables.aumentarFiesta(fiesta);
		variables.aumentarSangre(sangre);
		resultado.gameObject.SetActive(true);
		resultado.refresh(0, 0-hambre, sangre, fiesta);
		this.gameObject.SetActive(false);

	}
	public void tranquisClick()
	{
		int hambre = Random.Range(3, 7);
		int fiesta = Random.Range(2, 5);
		int sangre = Random.Range(2, 5);
		variables.disminuirHambre(hambre);
		variables.aumentarFiesta(fiesta);
		variables.aumentarSangre(sangre);
		resultado.gameObject.SetActive(true);
		resultado.refresh(0, 0-hambre, sangre, fiesta);
		this.gameObject.SetActive(false);
	}
	public void casaClick()
	{
		int poblacion = Random.Range(20, 41);

		variables.disminuirPoblacion (poblacion);
		resultado.gameObject.SetActive(true);
		resultado.refresh(0-poblacion, 0, 0, 0);
		this.gameObject.SetActive(false);
	}
}
