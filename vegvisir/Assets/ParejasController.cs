using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ParejasController : MonoBehaviour {
    private float momment;
    
    [SerializeField]
    private List<Casa> listaCasas = new List<Casa>();

    private int points = 0;
    private int vidas = 3;
    [SerializeField]
    private Text puntosTexto;
    [SerializeField]
    private Text puntosVida;
	// Use this for initialization
	void Start () {
        momment = -0.5f;
	}
	
	// Update is called once per frame
	void Update () {
        if (vidas > 0)
        {
            if (Time.timeSinceLevelLoad - momment > 0.5f)
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
        }
	}
    public void houseChecked(int number)
    {
        listaCasas[number].cerrarPareja();
        points++;
        puntosTexto.text = points + " puntos";
    }

    public void restarVida()
    {
        vidas--;
        puntosVida.text = vidas + " vidas";
    }
}
