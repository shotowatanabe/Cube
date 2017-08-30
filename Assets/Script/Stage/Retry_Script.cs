using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class Retry_Script : MonoBehaviour {

    private GameObject p_Retry_Text;

    private float p_fTimer = 0.0f;  //  点滅用タイマー

    private float p_fInterval01 = 1.0f;
    private float p_fInterval02 = 0.4f;

    GameObject P_gFadePanel;

    public bool p_TextFlag; 

    int p_iCounter = 0;

    int p_iPhase;

    // Use this for initialization
    void Start ()
    {
        p_Retry_Text = GameObject.Find("Retry_Text");
        P_gFadePanel = GameObject.Find("Fadeout_Panel");
        p_iPhase = 0;
        p_TextFlag = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(p_TextFlag == true)
        {
            p_fTimer += Time.deltaTime;
            switch (p_iPhase)
            {
                case 0:
                    if (p_fTimer >= p_fInterval01)
                    {
                        p_fTimer = 0.0f;
                    }
                    if (p_fTimer >= (p_fInterval01 / 2.0f))
                    {
                        //p_fAlpha = ((1 - p_fTimer) * 2.0f )* 255.0f;
                        p_Retry_Text.GetComponent<Text>().color = new Color(255.0f, 255.0f, 0.0f, 0.0f);
                    }
                    else
                    {
                        //p_fAlpha = (p_fTimer * 2.0f) * 255.0f;
                        p_Retry_Text.GetComponent<Text>().color = new Color(255, 255, 0, 255.0f);
                    }
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        p_iPhase = 1;
                        GameObject SEobj = GameObject.Find("Over_SE");
                        if (SEobj != null)
                        {
                            sound S = SEobj.GetComponent<sound>();
                            S.Sound01();
                        }
                    }
                    break;
                case 1:

                    if (p_fTimer >= p_fInterval02)
                    {
                        p_fTimer = 0.0f;
                        ++p_iCounter;
                        if (p_iCounter == 2)
                        {
                            P_gFadePanel.GetComponent<FadeScript>().p_vFade();
                        }
                    }
                    if (p_fTimer >= (p_fInterval02 / 2.0f))
                    {
                        //p_fAlpha = ((1 - p_fTimer) * 2.0f )* 255.0f;
                        this.p_Retry_Text.GetComponent<Text>().color = new Color(255.0f, 255.0f, 0.0f, 0.0f);
                    }
                    else
                    {
                        //p_fAlpha = (p_fTimer * 2.0f) * 255.0f;
                        this.p_Retry_Text.GetComponent<Text>().color = new Color(255, 255, 0, 1.0f);
                    }
                    if (p_iCounter >= 7)
                    {
                        SceneManager.LoadScene("StegeSelect");
                    }
                    break;
            }
        }
    }

    public void pFade()
    {
        p_TextFlag = true;
    }
}
