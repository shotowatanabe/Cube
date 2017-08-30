using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Laser06 : MonoBehaviour
{
    float timeleft;
    bool active = true;

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
        timeleft -= Time.deltaTime;
        if (timeleft <= 0.0)
        {
            timeleft = 2.0f;

            active = !active;
        }

        if(active)
        {
            GetComponent<BoxCollider>().enabled = true;
            GetComponent<MeshRenderer>().enabled = true;
        }
        else
        {
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<MeshRenderer>().enabled = false;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            FScript = p_gDeath.GetComponent<Death_Script>();
            FScript.pDeath();

            //  SceneManager.LoadScene("GameOver");
        }
    }
}
