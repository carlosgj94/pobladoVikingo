using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class BeerGame : MonoBehaviour {

    private float momment;
    private float mommentViking;
    
    private int clicks;

    [SerializeField]
    private Text counterText;

    [SerializeField]
    private Image barraImagen;

    [SerializeField]
    private Text puntosTexto;

    private bool morido=false;
    private int puntos;

    [SerializeField]
    private GameObject resultado;

    [SerializeField]
    private Text contenidoResultado;

   
   
    // Use this for initialization
    void Start () {
        momment = -1.6f;
        mommentViking = 0.0f;
        morido = false;
        Debug.Log(Time.timeSinceLevelLoad);
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.timeSinceLevelLoad < 10.0f && !morido)
        {
            if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
            {
                clicks++;
                mommentViking = Time.timeSinceLevelLoad;
                this.GetComponent<SpriteRenderer>().sprite = Resources.Load("Beer/" + "borracho02", typeof(Sprite)) as Sprite;
            }
            else {
                if (Time.timeSinceLevelLoad - mommentViking > 0.1f)
                    this.GetComponent<SpriteRenderer>().sprite = Resources.Load("Beer/" + "borracho01", typeof(Sprite)) as Sprite;
            }

            if (Time.timeSinceLevelLoad - momment > 1.0f)
            {
                momment = Time.timeSinceLevelLoad;

                puntos += clicks;

                if (clicks > 8)
                {
                    morido = true;
                    barraImagen.sprite = Resources.Load("Beer/" + "barracerveza100", typeof(Sprite)) as Sprite;
                }
                else if (clicks > 7)
                    barraImagen.sprite = Resources.Load("Beer/" + "barracerveza85", typeof(Sprite)) as Sprite;
                else if (clicks > 6)
                    barraImagen.sprite = Resources.Load("Beer/" + "barracerveza75", typeof(Sprite)) as Sprite;
                else if (clicks > 5)
                    barraImagen.sprite = Resources.Load("Beer/" + "barracerveza66", typeof(Sprite)) as Sprite;
                else if (clicks > 4)
                    barraImagen.sprite = Resources.Load("Beer/" + "barracerveza50", typeof(Sprite)) as Sprite;
                else if (clicks > 3)
                    barraImagen.sprite = Resources.Load("Beer/" + "barracerveza25", typeof(Sprite)) as Sprite;
                else if (clicks > 2)
                    barraImagen.sprite = Resources.Load("Beer/" + "barracerveza0", typeof(Sprite)) as Sprite;

                clicks = 0;
                counterText.text = "Tiempo: " + (10 - (int) Time.timeSinceLevelLoad);
                puntosTexto.text = "Puntos: " + puntos;

            }
        }
        else
        {
            resultado.gameObject.SetActive(true);
            contenidoResultado.text = "Has hecho "+puntos+" puntos.\nEsto son "+puntos/2+ " que se te restan a la fiesta";
            
        }
	}
    public void beerFinalClick()
    {
        PlayerPrefs.SetInt("PuntosBeer", puntos);
        if((PlayerPrefs.GetInt("Fiesta") - puntos/2) > 0)
            PlayerPrefs.SetInt("Fiesta", PlayerPrefs.GetInt("Fiesta") - (puntos / 2));
        else
            PlayerPrefs.SetInt("Fiesta", 0);
        SceneManager.LoadScene("Scene1");
    }
}
