using UnityEngine;
using System.Collections;

public class PitFall : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    Vector3 StartPos;

    // Use this for initialization
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Rigidbody.useGravity = false;
        StartPos = this.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Player")
        {
            StartCoroutine("Down");
        }
    }

    IEnumerator Down()
    {
        yield return new WaitForSeconds(1); // wait
        m_Rigidbody.useGravity = true;

        GameObject SEobj = GameObject.Find("pitfall_SE");
        if (SEobj != null)
        {
            sound S = SEobj.GetComponent<sound>();
            S.Sound01();
        }

        StartCoroutine("Up");
    }

    IEnumerator Up()
    {
        yield return new WaitForSeconds(5);
        m_Rigidbody.useGravity = false;
        transform.localPosition = StartPos;
    }
}
