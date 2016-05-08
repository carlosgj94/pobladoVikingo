using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class GuerraEvent : MonoBehaviour {
    //Audios
    public AudioSource audioS;
    [SerializeField]
    private AudioClip battleMusic;
    [SerializeField]
    private AudioClip pactoMusic;
    [SerializeField]
    private AudioClip retiradaMusic;

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

    private List<string> enemigos = new List<string>{"John Snow", "El Cesar", "los Aliens", "una manada de topos"};
	// Use this for initialization
	void Start () {
        int random = Random.Range(0, enemigos.Count);
        titulo.text = "Guerra con " +enemigos[random];
        contenido.text = "La guerra es algo mazo de duro lider. Que desea hacer premoh?";

        botonTexto1.text = "Abandorar";
        botonTexto2.text = "Pacto";
        botonTexto3.text = "Guerra joder!";

    }
    void OnEnable()
    {
        int random = Random.Range(0, enemigos.Count);
        titulo.text = "Guerra con " + enemigos[random];
        contenido.text = "La guerra es algo mazo de duro lider. Que desea hacer premoh?";

        botonTexto1.text = "Abandonar";
        botonTexto2.text = "Pacto";
        botonTexto3.text = "Guerra joder!";
    }
    public void abandonarClick()
    {
        audioS.clip = retiradaMusic;
        audioS.Play();
        int poblacion = Random.Range(80, 150);
        int hambre = Random.Range(6, 10);
        int sangre = Random.Range(8, 12);
        int fiesta = Random.Range(8, 12);
        variables.disminuirPoblacion(poblacion);
        variables.aumentarHambre(hambre);
        variables.aumentarSangre(sangre);
        variables.aumentarFiesta(fiesta);
        resultado.gameObject.SetActive(true);
        resultado.refresh(0-poblacion, hambre, sangre, fiesta);
        this.gameObject.SetActive(false);
        
    }
	public void pactoClick()
    {
        audioS.clip = pactoMusic;
        audioS.Play();
        int hambre = Random.Range(8,12);
        int sangre = Random.Range(9, 14);
        int fiesta = Random.Range(8, 12);
        variables.aumentarHambre(hambre);
        variables.aumentarSangre(sangre);
        variables.aumentarFiesta(fiesta);
        resultado.gameObject.SetActive(true);
        resultado.refresh(0, hambre, sangre, fiesta);
        this.gameObject.SetActive(false);
    }
    public void guerraClick()
    {
        audioS.clip = battleMusic;
        audioS.Play();
        int poblacion;
        int hambre;
        int sangre;
        int fiesta;
        if (Random.Range(0, 1) == 0)
        {
            //Ganas
            poblacion = Random.Range(150, 250);
            sangre = Random.Range(7, 10);
            fiesta = Random.Range(8, 12);

            variables.disminuirPoblacion(poblacion);
            variables.disminuirSangre(sangre);
            variables.aumentarFiesta(fiesta);

            resultado.gameObject.SetActive(true);
            resultado.refresh(0 - poblacion, 0, 0-sangre, fiesta);
        }
        else
        {
            //Pierdes
            poblacion = Random.Range(200, 350);
            hambre = Random.Range(11, 14);
            sangre = Random.Range(12, 15);
            fiesta = Random.Range(12, 15);
            variables.disminuirPoblacion(poblacion);
            variables.aumentarHambre(hambre);
            variables.disminuirSangre(sangre);
            variables.aumentarFiesta(fiesta);

            resultado.gameObject.SetActive(true);
            resultado.refresh(0 - poblacion, hambre, 0-sangre, fiesta);
        }
        
        this.gameObject.SetActive(false);
    }
}
