﻿using UnityEngine;
using System.Collections;

public class Press03 : MonoBehaviour
{
    bool xFlag;
    public float speed = 1f;

    // Use this for initialization
    void Start()
    {
        xFlag = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (xFlag)
        {
            transform.localPosition -= new Vector3(speed * Time.deltaTime, 0f, 0f);
            if (transform.localPosition.x <= -4.18)
            {
                xFlag = false;
            }
        }
        else
        {
            transform.localPosition += new Vector3(speed * Time.deltaTime, 0f, 0f);
            if (transform.localPosition.x >= 0)
            {
                xFlag = true;
            }
        }
    }
}