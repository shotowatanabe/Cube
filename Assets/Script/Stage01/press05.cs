using UnityEngine;
using System.Collections;

public class press05 : MonoBehaviour
{

    bool zPlus;
    public float speed = 1f;

    // Use this for initialization
    void Start()
    {
        zPlus = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (zPlus)
        {
            transform.position -= new Vector3(0f, 0f, speed * Time.deltaTime);
            if (transform.position.z <= -5)
                zPlus = false;
        }
        else
        {
            transform.position += new Vector3(0f, 0f, speed * Time.deltaTime);
            if (transform.position.z >= -1.65)
                zPlus = true;
        }
    }
}
