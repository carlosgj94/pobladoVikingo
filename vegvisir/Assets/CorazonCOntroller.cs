using UnityEngine;
using System.Collections;

public class CorazonCOntroller : MonoBehaviour {
    float speed = 1.0f; //how fast it shakes
    float amount = 1.0f; //how much it shakes

    void Update()
    {
        Vector3 v = new Vector3(Mathf.Sin(Time.time * speed), 0, 0);
        transform.localPosition = v;

        //this.camera.transform.localPosition = Random.insideUnitSphere * this.ShakeAmount * this.shake;
    }
}
