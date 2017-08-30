using UnityEngine;
using System.Collections;

public class DataBase : MonoBehaviour
{

    private static bool Flag = false;
	// Use this for initialization
	void Awake ()
    {
        if(!Flag)
        {
            DontDestroyOnLoad(this.gameObject);
            Flag = true;
        }
        else
        {
            Destroy(this.gameObject);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
