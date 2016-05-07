using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Casa : MonoBehaviour {

    public bool ocupada = false;
    private float mommentStart;
    [SerializeField]
    private Button fotoPareja;
    [SerializeField]
    private ParejasController parejas;

    public void crearPareja()
    {
        if (!ocupada)
        {
            mommentStart = Time.timeSinceLevelLoad;
            fotoPareja.gameObject.SetActive(true);
        }
    }

    public void cerrarPareja(){
        fotoPareja.gameObject.SetActive(false);
        ocupada = false;
        parejas.restarVida();
    }

    void Update()
    {
        if (Time.timeSinceLevelLoad - mommentStart > 1.0f && mommentStart!=0)
        {       
            mommentStart = 0;
            cerrarPareja();
        }
    }
  
}

