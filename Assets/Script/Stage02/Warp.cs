using UnityEngine;
using System.Collections;

public class Warp : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            transform.position = new Vector3(9, 13, -14.5f);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            transform.position = new Vector3(1, 7, 8.5f);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            transform.position = new Vector3(5, 1.5f, -8);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            transform.position = new Vector3(-14, 1.5f, 14);
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            transform.position = new Vector3(11.5f, 24, 11);
        }
    }
}
