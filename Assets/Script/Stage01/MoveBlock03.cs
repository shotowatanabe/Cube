using UnityEngine;
using System.Collections;

public class MoveBlock03 : MonoBehaviour
{

    bool zPlus;
    bool p_bStopFlag;
    public float speed = 3.0f;
    Rigidbody mMyRigidbody;
    Rigidbody mClient;
    Vector3 velocity;
    Vector3 mPosWhenCollide;
    Vector3 StopPositon;

    private float p_fTimer = 2.0f;

    // Use this for initialization
    void Start()
    {
        zPlus = true;
        velocity = new Vector3(0, 0, 0);
        mPosWhenCollide = new Vector3();
        mMyRigidbody = this.gameObject.GetComponent<Rigidbody>();
        mClient = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (p_bStopFlag == false)
        {
            if (zPlus == true)
            {
                transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
                if (transform.position.x >= 10.45f)
                {
                    zPlus = false;
                    StopPositon = this.transform.position;
                    p_bStopFlag = true;
                }
            }
            else if (zPlus == false)
            {
                transform.position -= new Vector3(speed * Time.deltaTime, 0f, 0f);
                if (transform.position.x <= 8.2f)
                {
                    zPlus = true;
                    StopPositon = this.transform.position;
                    p_bStopFlag = true;
                }
            }

        }
        else if (p_bStopFlag == true)
        {
            transform.position = StopPositon;
            p_fTimer -= Time.deltaTime;
            if (p_fTimer <= 0.0f)
            {
                p_bStopFlag = false;
                p_fTimer = 2.0f;
            }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        GameObject obj = col.gameObject;
        if (obj.tag == "Player")
        {
            mClient = obj.GetComponent<Rigidbody>();
            mPosWhenCollide = this.transform.position;
        }
    }
    void OnCollisionStay(Collision col)
    {
        GameObject obj = col.gameObject;
        if (obj.tag == "Player")
        {
            if (mClient != null)
            {
                mClient.position += this.transform.position - mPosWhenCollide;
                mPosWhenCollide = this.transform.position;
            }
            else
            {
                mClient = obj.GetComponent<Rigidbody>();
                mPosWhenCollide = this.transform.position;
            }
        }
    }

    void OnCollisionExit(Collision col)
    {
        GameObject obj = col.gameObject;
        if (obj.tag == "Player")
        {
            mClient = null;
        }
    }

}

