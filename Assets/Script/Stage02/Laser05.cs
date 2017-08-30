using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Laser05 : MonoBehaviour
{
    public float speed = 1f;

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
        transform.localPosition += new Vector3(0f, speed * Time.deltaTime, 0f);
        if (transform.localPosition.y >= 6.6)
        {
            transform.localPosition = new Vector3(-3.3f, -3.16f, 0.11f);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            FScript = p_gDeath.GetComponent<Death_Script>();
            FScript.pDeath();

            //  SceneManager.LoadScene("GameOver");
        }
    }
}
