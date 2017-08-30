using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour
{
    GameObject parent;
    Quaternion m_DefaultRotation;

    // Use this for initialization
    void Start()
    {
        parent = GameObject.Find("Player");
        //m_DefaultRotation = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        //var defaultRotation = transform.rotation;
        //float default_y = defaultRotation.y;
        //var inverseRotation = Quaternion.Inverse(transform.parent.rotation);
        //float inverse_y = inverseRotation.y;

        //default_y = default_y * inverse_y;

        //transform.rotation = defaultRotation;
    }
    public void rotateXZ(float x, float z)
    {
        x *= 90.0f;
        z *= 90.0f;
        transform.Rotate(new Vector3(z, 0, -x), Space.World);
    }

    public void adjust()
    {
        //90°補正

        var MyQuaternion = transform.rotation;
        float x = MyQuaternion.x;
        float y = MyQuaternion.y;
        float z = MyQuaternion.z;
        float w = MyQuaternion.w;
        float s;

        //  x
        s = Mathf.Sign(x);
        x = Mathf.Abs(x);
        if (x < 0.25f)
        {
            x = 0;
        }
        else if (x < 0.6f)
        {
            x = 0.5f * s;
        }
        else if (x < 0.85f)
        {
            x = 0.70710678118654752440084436210485f * s;
        }
        else
        {
            x = s;
        }

        //  y
        s = Mathf.Sign(y);
        y = Mathf.Abs(y);
        if (y < 0.25f)
        {
            y = 0;
        }
        else if (y < 0.6f)
        {
            y = 0.5f * s;
        }
        else if (y < 0.85f)
        {
            y = 0.70710678118654752440084436210485f * s;
        }
        else
        {
            y = s;
        }

        //  z
        s = Mathf.Sign(z);
        z = Mathf.Abs(z);
        if (z < 0.25f)
        {
            z = 0;
        }
        else if (z < 0.6f)
        {
            z = 0.5f * s;
        }
        else if (z < 0.85f)
        {
            z = 0.70710678118654752440084436210485f * s;
        }
        else
        {
            z = s;
        }

        //  w
        s = Mathf.Sign(w);
        w = Mathf.Abs(w);
        if (w < 0.25f)
        {
            w = 0;
        }
        else if (w < 0.6f)
        {
            w = 0.5f * s;
        }
        else if (w < 0.85f)
        {
            w = 0.70710678118654752440084436210485f * s;
        }
        else
        {
            w = s;
        }
        MyQuaternion.x = x;
        MyQuaternion.y = y;
        MyQuaternion.z = z;
        MyQuaternion.w = w;
        transform.rotation = MyQuaternion;
    }
}