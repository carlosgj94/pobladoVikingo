using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class beerEvent : MonoBehaviour {

	[SerializeField]
	private VariableManager variables;
	[SerializeField]
	private GameManager gameManager;

	public void buttonClick()
	{
		this.gameObject.SetActive(false);
		SceneManager.LoadScene("Beer");

	}

}
