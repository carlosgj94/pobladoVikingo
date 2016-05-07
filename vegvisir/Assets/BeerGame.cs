using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BeerGame : MonoBehaviour {

    private float momment;
    
    private int clicks;

    [SerializeField]
    private Text counterText;
	// Use this for initialization
	void Start () {
        momment = -1.6f;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        {
            clicks++;
        }

        if (Time.time - momment > 1.6f)
        {
            momment = Time.time;
            int total =clicks;
            clicks = 0;
            counterText.text = " " + total;
        }
	}
}
