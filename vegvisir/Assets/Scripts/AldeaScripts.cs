using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AldeaScripts : MonoBehaviour {

	public void cambiarEscena(string escena)
    {
        SceneManager.LoadScene(escena);
    }
}
