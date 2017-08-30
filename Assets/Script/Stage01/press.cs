using UnityEngine;
using System.Collections;

public class press : MonoBehaviour
{

    int press_Phase;
    public float speed = 0.5f;
    float Timer = 1.0f;
    Vector3 StopPositon;

	// Use this for initialization
	void Start ()
    {
        press_Phase = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        switch(press_Phase)
        {
            case 0:
                transform.position += new Vector3(0f, speed * Time.deltaTime, 0f);
                if (transform.position.y >= 5.9f)
                {
                    StopPositon = this.transform.position;
                    press_Phase = 1;
                }
                break;
            case 1:
                transform.position = StopPositon;
                Timer -= Time.deltaTime;
                if(Timer <= 0)
                {
                    press_Phase = 2;
                    Timer = 1.0f;
                }
                break;
            case 2:
                transform.position -= new Vector3(0f, speed * Time.deltaTime, 0f);
                if (transform.position.y <= 1.70f)
                {
                    StopPositon = this.transform.position;
                    press_Phase = 3;
                }
                break;
            case 3:
                transform.position = StopPositon;
                Timer -= Time.deltaTime;
                if (Timer <= 0)
                {
                    press_Phase = 0;
                    Timer = 1.0f;
                }
                break;
        }
    }
}
