using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EstadisticasManager : MonoBehaviour {
    [SerializeField]
    private Text PoblacionTexto;
    [SerializeField]
    private Text HambreTexto;
    [SerializeField]
    private Text SangreTexto;
    [SerializeField]
    private Text FiestaTexto;
    [SerializeField]
    private Text DiasTexto;

    [SerializeField]
    private VariableManager variables;

    [SerializeField]
    private Image hambreImagen;
    [SerializeField]
    private Image sangreImagen;
    [SerializeField]
    private Image fiestaImagen;
 
    
    public void refresh()
    {
        PoblacionTexto.text = variables.poblacion+" Poblacion";
        HambreTexto.text = variables.hambre + " Hambre";
        SangreTexto.text = variables.sangre + " Sangre";
        FiestaTexto.text = variables.fiesta + " Fiesta";
        if (variables.dias > 1)
            DiasTexto.text = variables.dias + " Dias";
        else
            DiasTexto.text = variables.dias + " Dia";

        //Cambiando Sprites
        //cambiando sprites del hambre
        if (variables.hambre < 25)
            hambreImagen.sprite = Resources.Load("Hambre/" + "hambre0", typeof(Sprite)) as Sprite;
        else if (variables.hambre < 50)
            hambreImagen.sprite = Resources.Load("Hambre/" + "hambre25", typeof(Sprite)) as Sprite;
        else if (variables.hambre < 75)
            hambreImagen.sprite = Resources.Load("Hambre/" + "hambre50", typeof(Sprite)) as Sprite;
        else if (variables.hambre < 100)
            hambreImagen.sprite = Resources.Load("Hambre/" + "hambre75", typeof(Sprite)) as Sprite;
        else
            hambreImagen.sprite = Resources.Load("Hambre/" + "hambre100", typeof(Sprite)) as Sprite;

        //cambiando sprites de la sangre
        if (variables.sangre < 25)
            sangreImagen.sprite = Resources.Load("Sangre/" + "sangre0", typeof(Sprite)) as Sprite;
        else if (variables.sangre < 50)
            sangreImagen.sprite = Resources.Load("Sangre/" + "sangre25", typeof(Sprite)) as Sprite;
        else if (variables.sangre < 75)
            sangreImagen.sprite = Resources.Load("Sangre/" + "sangre50", typeof(Sprite)) as Sprite;
        else if (variables.sangre < 100)
            sangreImagen.sprite = Resources.Load("Sangre/" + "sangre75", typeof(Sprite)) as Sprite;
        else
            sangreImagen.sprite = Resources.Load("Sangre/" + "sangre100", typeof(Sprite)) as Sprite;

        //cambiando sprite de la fiesta
        if (variables.fiesta < 25)
            fiestaImagen.sprite = Resources.Load("Fiesta/" + "fiesta0", typeof(Sprite)) as Sprite;
        else if (variables.fiesta < 50)
            fiestaImagen.sprite = Resources.Load("Fiesta/" + "fiesta25", typeof(Sprite)) as Sprite;
        else if (variables.fiesta < 75)
            fiestaImagen.sprite = Resources.Load("Fiesta/" + "fiesta50", typeof(Sprite)) as Sprite;
        else if (variables.fiesta < 100)
            fiestaImagen.sprite = Resources.Load("Fiesta/" + "fiesta75", typeof(Sprite)) as Sprite;
        else
            fiestaImagen.sprite = Resources.Load("Fiesta/" + "fiesta100", typeof(Sprite)) as Sprite;
    }
}
