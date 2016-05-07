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
            ocupada = true;
            mommentStart = Time.timeSinceLevelLoad;
            fotoPareja.gameObject.SetActive(true);
        }
    }

    public void cerrarPareja(){
        ocupada = false;
        fotoPareja.gameObject.SetActive(false);
        mommentStart = 0;
    }

    void Update()
    {
        if(ocupada)
        if (Time.timeSinceLevelLoad - mommentStart > 2.2f )
        {
           if(parejas.vidas>0)
            parejas.restarVida();
            cerrarPareja();
        }
    }
  
}

