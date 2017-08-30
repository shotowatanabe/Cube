using UnityEngine;
using System.Collections;

public class Unlock : MonoBehaviour
{
    GameObject door;

	// Use this for initialization
	void Start ()
    {
        door = GameObject.Find("door");
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            door.transform.localPosition = new Vector3(0f, -4.4f, -1.1f);
            Destroy(this.gameObject);
        }
    }
}
