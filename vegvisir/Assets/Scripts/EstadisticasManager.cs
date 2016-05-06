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
    // Use this for initialization
 
    public void refresh()
    {
        PoblacionTexto.text = variables.poblacion+" Poblacion";
        HambreTexto.text = variables.hambre + " Hambre";
        SangreTexto.text = variables.sangre + " Sangre";
        FiestaTexto.text = variables.fiesta + " Fiesta";

        DiasTexto.text = variables.dias + " Dias";
    }
}
