using UnityEngine;
using System.Collections;

public class MalasCosechas : MonoBehaviour {
    [SerializeField]
    private VariableManager variables;

    [SerializeField]
    private GameManager gameManager;
    public void malasCosechasClick()
    {
        this.gameObject.SetActive(false);
        gameManager.siguientePaso();

    }
    void OnEnable()
    {
        variables.aumentarHambre(10);
    }
}
