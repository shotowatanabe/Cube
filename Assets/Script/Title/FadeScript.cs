using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour
{
    private float alfa;
    public float speed = 0.015f;
    private float red, green, blue;

    public bool p_bfadetrigger;

    void Start()
    {
        red = GetComponent<Image>().color.r;
        green = GetComponent<Image>().color.g;
        blue = GetComponent<Image>().color.b;

        p_bfadetrigger = false;
    }

    void Update()
    {
        if (p_bfadetrigger == true)
        {
            GetComponent<Image>().color = new Color(red, green, blue, alfa);
            alfa += speed;
        }
    }

    public void p_vFade()
    {
        p_bfadetrigger = true;
    }

}