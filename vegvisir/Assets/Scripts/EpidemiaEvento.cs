using UnityEngine;
using System.Collections;

public class EpidemiaEvento : MonoBehaviour {

    [SerializeField]
    private VariableManager variables;

    [SerializeField]
    private GameManager gameManager;
    public void epidemiaClick()
    {
        this.gameObject.SetActive(false);
        gameManager.siguientePaso();

    }
    void OnEnable()
    {
        variables.disminuirPoblacion(50);
    }
}
