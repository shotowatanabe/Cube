using UnityEngine;
using System.Collections;

public class Wind : MonoBehaviour
{
    GameObject player;
    public float speed = 1f;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnTriggerStay(Collider col)
    {
        if(col.CompareTag("Player"))
        {
            player.transform.position -= new Vector3(speed * Time.deltaTime, 0f, 0f);
        }
    }
}
