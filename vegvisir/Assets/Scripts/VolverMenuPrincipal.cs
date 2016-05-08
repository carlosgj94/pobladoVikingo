using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class VolverMenuPrincipal : MonoBehaviour {

	public void onClickVolver(){
		SceneManager.LoadScene("MenuPrincipal");
	}
}
