using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class kfcEvent : MonoBehaviour {

	[SerializeField]
	private VariableManager variables;
	[SerializeField]
	private GameManager gameManager;

	public void buttonClick()
	{
		this.gameObject.SetActive(false);
		SceneManager.LoadScene("kfc");

	}

}
