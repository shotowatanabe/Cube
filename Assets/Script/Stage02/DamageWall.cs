using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DamageWall : MonoBehaviour
{

    private GameObject p_gDeath;

    Death_Script FScript;
    GameObject SEobj;

    // Use this for initialization
    void Start()
    {
        p_gDeath = GameObject.Find("GameObject");
        SEobj = GameObject.Find("Death_SE");
    }


    // Update is called once per frame
    void Update ()
    {
	
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Player")
        {
            FScript = p_gDeath.GetComponent<Death_Script>();
            FScript.pDeath();

            //  SceneManager.LoadScene("GameOver");
        }
    }
}
