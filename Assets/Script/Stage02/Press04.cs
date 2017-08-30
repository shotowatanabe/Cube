using UnityEngine;
using System.Collections;

public class Press04 : MonoBehaviour
{
    bool yFlag;
    public float speed = 1f;

    // Use this for initialization
    void Start()
    {
        yFlag = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (yFlag)
        {
            transform.localPosition += new Vector3(0f, speed * Time.deltaTime, 0f);
            if (transform.localPosition.y >= 14.8)
            {
                yFlag = false;
            }
        }
        else
        {
            transform.localPosition -= new Vector3(0f, speed * Time.deltaTime, 0f);
            if (transform.localPosition.y <= 11.55)
            {
                yFlag = true;
            }
        }
    }
}