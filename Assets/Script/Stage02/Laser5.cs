using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Laser5 : MonoBehaviour
{
    public float speed = 1f;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position -= new Vector3(0f, 0f, speed * Time.deltaTime);
        if (transform.localPosition.y >= 6.6)
        {
            transform.localPosition = new Vector3(-3.3f, -3.16f, 0.11f);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Player")
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
