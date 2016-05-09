using UnityEngine;
using System.Collections;

public class PolloKfc : MonoBehaviour {
    public float spawnDirection;
    [SerializeField]
    private VikingoKFC vikingo;
    // Use this for initialization
	void Start () {
        spawnDirection = Random.Range(0, 2)*2-1;
        if (spawnDirection == 1)
            this.gameObject.transform.position = new Vector3(1.71f, 6, 0);
        else
            this.gameObject.transform.position = new Vector3(-1.4f, 6, 0);

        if (this.gameObject.tag == "Pollo")
            this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
        else
            this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 248);

    }
	void update()
    {
        if(gameObject.transform.position.y < -10.0f)
        {
            Destroy(this.gameObject);
        }
    }
    
}
