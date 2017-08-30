using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Fadein_Script : MonoBehaviour {

    public float f_speed = 0.01f;
    public float t_speed = 0.05f;
    private float red, green, blue, alfa;
    private float t_red, t_green, t_blue, t_alfa;

    public bool p_bfadeintrigger;
    GameObject p_OverText;
    float width, height;

    // Use this for initialization
    void Start () {
        red = GetComponent<Image>().color.r;
        green = GetComponent<Image>().color.g;
        blue = GetComponent<Image>().color.b;
        alfa = GetComponent<Image>().color.a;

        p_OverText = GameObject.Find("GameOver_Text");
        t_red = p_OverText.GetComponent<Image>().color.r;
        t_green = p_OverText.GetComponent<Image>().color.g;
        t_blue = p_OverText.GetComponent<Image>().color.b;
        t_alfa = p_OverText.GetComponent<Image>().color.a;

        p_bfadeintrigger = true;

    }
	
	// Update is called once per frame
	void Update ()
    {
        GetComponent<Image>().color = new Color(red, green, blue, alfa);
        if (alfa >= 0.5)
        {
            alfa -= f_speed;
        }
        else
        {
            red += t_speed;
            blue += t_speed;
            green += t_speed;
        }

        if(red >= 1.0f && blue >= 1.0f && green >= 1.0f)
        {
            t_alfa += t_speed;
        }
        p_OverText.GetComponent<Image>().color = new Color(t_red, t_green, t_blue, t_alfa);

        if(t_alfa >= 1.0f)
        {
            GameObject p_text = GameObject.Find("Retry_Text");
            p_text.GetComponent<Text>().enabled = true;
        }

    }

}
