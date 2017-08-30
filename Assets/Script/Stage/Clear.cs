using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Clear : MonoBehaviour
{
    int item;
    bool clear;

	// Use this for initialization
	void Start ()
    {
        item = 0;
        clear = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void count()
    {
        ++item;
        if(item >= 1)
        {
            clear = true;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (clear)
        {
            if (col.CompareTag("Player"))
            {
                SceneManager.LoadScene("GameClear");
            }
        }
    }
}
