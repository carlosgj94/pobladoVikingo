using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ParejasController : MonoBehaviour {
    [SerializeField]
    private AudioSource audioS;
    [SerializeField]
    private AudioClip sexyTime;
    private float momment;
    
    [SerializeField]
    private List<Casa> listaCasas = new List<Casa>();

    private int points = 0;
    public int vidas = 3;
    [SerializeField]
    private Text puntosTexto;
    [SerializeField]
    private Text puntosVida;

    [SerializeField]
    private GameObject popup;
	[SerializeField]
	private Text titulo;
    [SerializeField]
    private Text contenidoPopup;
	// Use this for initialization
	void Start () {
        momment = -0.5f;
	}
	
	// Update is called once per frame
	void Update () {
		if (vidas > 0 && points < 50)
        {
            if (Time.timeSinceLevelLoad - momment > 0.6f)
            {
                momment = Time.timeSinceLevelLoad;
                int random;
                do
                {
                    random = Random.Range(0, listaCasas.Count);
                } while (listaCasas[random].ocupada);
                listaCasas[random].crearPareja();

            }
        }
        else
        {
			//Aqui se va a liar una gorda!
			if (vidas <= 0) {
				titulo.text = "Has perdido";
			} else {
				titulo.text = "Has ganado";
			}
			popup.gameObject.SetActive (true);
			contenidoPopup.text = "Has logrado: " + points + ".\nQue son: " + points * 5 + " personas nuevas.\nVaya semental!";
			PlayerPrefs.SetInt ("Poblacion", PlayerPrefs.GetInt ("Poblacion") + points * 5);
        }
	}
    public void houseChecked(int number)
    {
		if (vidas > 0 && points < 50)
        {
            audioS.clip = sexyTime;
            audioS.Play();
            listaCasas[number].cerrarPareja();
            points++;
            puntosTexto.text = points + " puntos";
        }
	
    }

    public void restarVida()
    {
        vidas--;
        puntosVida.text = vidas + " vidas";
    }
}
