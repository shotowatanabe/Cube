using UnityEngine;
using System.Collections;

public class snowman : MonoBehaviour
{
    GameObject warp;

	// Use this for initialization
	void Start ()
    {
        warp = GameObject.Find("warp");
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            GameObject SEobj = GameObject.Find("Battery_SE");
            if (SEobj != null)
            {
                sound S = SEobj.GetComponent<sound>();
                S.Sound01();
            }

            warp.GetComponent<Clear>().count();
            Destroy(gameObject);
        }
    }
}
