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
        int poblacion = Random.Range(1, 4);
        int hambre = Random.Range(1, 4);
        int sangre = Random.Range(2, 5);
        int fiesta = Random.Range(2, 5);
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
        int hambre = Random.Range(2, 5);
        int sangre = Random.Range(3, 7);
        int fiesta = Random.Range(2, 5);
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
            poblacion = Random.Range(7, 15);
            hambre = Random.Range(1, 4);
            sangre = Random.Range(2, 5);
            fiesta = Random.Range(2, 5);

            variables.disminuirPoblacion(Random.Range(7, 15));
            variables.disminuirHambre(Random.Range(1, 4));
            variables.disminuirSangre(Random.Range(2, 5));
            variables.disminuirFiesta(Random.Range(2, 5));

            resultado.gameObject.SetActive(true);
            resultado.refresh(0 - poblacion, 0-hambre, 0-sangre, 0-fiesta);
        }
        else
        {
            //Pierdes
            poblacion = Random.Range(10, 21);
            hambre = Random.Range(1, 4);
            sangre = Random.Range(2, 5);
            fiesta = Random.Range(2, 5);
            variables.disminuirPoblacion(Random.Range(10, 18));
            variables.aumentarHambre(Random.Range(1, 3));
            variables.disminuirSangre(Random.Range(2, 4));
            variables.aumentarFiesta(Random.Range(2, 4));

            resultado.gameObject.SetActive(true);
            resultado.refresh(0 - poblacion, hambre, 0-sangre, fiesta);
        }
        
        this.gameObject.SetActive(false);
    }
}
