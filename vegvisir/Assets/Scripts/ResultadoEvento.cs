using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResultadoEvento : MonoBehaviour {
    [SerializeField]
    private Text contenido;

    [SerializeField]
    private GameManager gameManager;
	public void refresh(int poblacion, int hambre, int sangre, int fiesta)
    {
        contenido.text = "Poblacion: " + poblacion +
            "\nHambre: " + hambre+
            "\nSangre: "+sangre+
            "\nFiesta: "+fiesta;
    }
    public void resultadoClick()
    {
        gameManager.siguientePaso();
        this.gameObject.SetActive(false);
    }
}
