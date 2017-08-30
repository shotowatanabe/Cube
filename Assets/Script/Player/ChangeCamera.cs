using UnityEngine;
using System.Collections;

public class ChangeCamera : MonoBehaviour
{
    public Camera MainCamera;
    public Camera SubCamera;
    GameObject Target;
    //GameObject MainCam;
    //Vector3 MainPos;
    //Vector3 SubPos;
    //Quaternion MainAngle;
    //Quaternion SubAngle;

    // Use this for initialization
    void Start()
    {
        MainCamera.enabled = true;
        SubCamera.enabled = false;
        Target = GameObject.Find("Player");
        //MainCam = GameObject.Find("MainCamera");
        //MainPos = this.MainCam.transform.position;
        //SubPos = new Vector3(0, 3.3f, 0);
        //MainAngle = this.MainCam.transform.rotation;
        //SubAngle = new Quaternion(60, 0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        Vector3 temp = Target.transform.position - this.transform.position;
        Vector3 normal = temp.normalized;

        if (Physics.Raycast(this.transform.position, normal, out hit, 10))
        {
            //if(hit.transform.gameObject != Target)
            //{
            //    MainCam.transform.position = Vector3.Lerp(MainPos, SubPos, Time.deltaTime * 3);
            //    MainCam.transform.rotation = Quaternion.Lerp(MainAngle, SubAngle, Time.deltaTime * 3);
            //}

            if (hit.transform.gameObject == Target)
            {
                MainCamera.enabled = true;
                SubCamera.enabled = false;
            }
            else
            {
                MainCamera.enabled = false;
                SubCamera.enabled = true;
            }
        }
    }
}