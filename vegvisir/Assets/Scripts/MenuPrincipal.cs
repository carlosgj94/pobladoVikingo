using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour {

	public void Play(){
		SceneManager.LoadScene("Scene1");
	}

	public void Quit(){
		Application.Quit();
	}


}
