using UnityEngine;
using System.Collections;

public class DownBlock : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public float speed = 1f;

	// Use this for initialization
	void Start ()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Rigidbody.useGravity = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "Player")
        {
            StartCoroutine("Down");
        }
    }

    IEnumerator Down()
    {
        yield return new WaitForSeconds(1); // wait
        m_Rigidbody.useGravity = true;
        StartCoroutine("Up");
    }

    IEnumerator Up()
    {
        yield return new WaitForSeconds(5);
        m_Rigidbody.useGravity = false;
        transform.position = new Vector3(0f, 0f, 42.5f);
    }
}
