using UnityEngine;
using System.Collections;

public class BGM_Script : MonoBehaviour {

    private AudioSource BGM01;
    float B_volume;
    private bool B_FadeFlag = false;

    float BGMsub = 0.0025f; 

    // Use this for initialization
    void Start () {
        BGM01 = GetComponent<AudioSource>();

        B_volume = BGM01.volume;
    }
	
	// Update is called once per frame
	void Update () {
        if(B_FadeFlag)
        {
            B_volume -= 0.01f;
            if(B_volume <= 0)
            {
                B_FadeFlag = false;
            }
        }
        GetComponent<AudioSource>().volume = (B_volume);
	}

    public void BGM_Fade()
    {
        B_FadeFlag = true;
    }
}
