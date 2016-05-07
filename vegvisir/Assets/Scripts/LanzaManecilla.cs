using UnityEngine;
using System.Collections;

public class LanzaManecilla : MonoBehaviour {

	public GameObject lanza;
	public Vector3 angulo;
	public Vector3 angulo1;
	public Vector3 angulo2;

    [SerializeField]
    AudioSource audioS;
    [SerializeField]
    AudioClip lanzaAudio;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		gameObject.transform.Rotate (0, 0, -100*Time.deltaTime);
		//angulo = gameObject.transform.rotation.eulerAngles;
		angulo1 = gameObject.transform.rotation.eulerAngles + new Vector3 (0, 0, 10);
		angulo2 = gameObject.transform.rotation.eulerAngles + new Vector3 (0, 0, -10);
	}

	public void OnClick(){
		lanza.gameObject.SetActive (true);
        //Instantiate (lanza, new Vector3 (0, 0, 0), Quaternion.Euler(angulo));
        audioS.clip = lanzaAudio;
        audioS.Play();
		Instantiate (lanza, new Vector3 (0, 0, 0), Quaternion.Euler(angulo1));
		Instantiate (lanza, new Vector3 (0, 0, 0), Quaternion.Euler(angulo2));
		lanza.gameObject.SetActive (false);
	}


}
