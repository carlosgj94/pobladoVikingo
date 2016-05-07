using UnityEngine;
using System.Collections;

public class HidromielAguada : MonoBehaviour {
    [SerializeField]
    private VariableManager variables;

    [SerializeField]
    private GameManager gameManager;
    public void hidromielAguadaClick()
    {
        this.gameObject.SetActive(false);
        gameManager.siguientePaso();
        
    }
    void OnEnable()
    {
        variables.aumentarFiesta(5);
    }
}
