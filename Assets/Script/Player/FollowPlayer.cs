using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour
{
    GameObject Target;

	// Use this for initialization
	void Start ()
    {
        Target = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 pos = Target.transform.localPosition;
        transform.localPosition = pos;
	}
}
