using UnityEngine;
using System.Collections;

public class BarcosQuemados : MonoBehaviour {
    [SerializeField]
    private VariableManager variables;

    [SerializeField]
    private GameManager gameManager;
    public void barcosQuemadosClick()
    {
        this.gameObject.SetActive(false);
        gameManager.siguientePaso();

    }
    void OnEnable()
    {
        variables.aumentarSangre(5);
    }
}
