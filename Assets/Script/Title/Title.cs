using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    private GameObject p_StartText;

    private float p_fTimer = 0.0f;  //  点滅用タイマー

    private float p_fInterval01 = 1.0f;
    private float p_fInterval02 = 0.4f;

    GameObject P_gFadePanel;


    int p_iCounter = 0;

    int p_iPhase;

    void Start()
    {
        this.p_StartText = GameObject.Find("StartText");
        P_gFadePanel = GameObject.Find("Panel");
        p_iPhase = 0;
    }
    void Update()
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
                    this.p_StartText.GetComponent<SpriteRenderer>().color = new Color(255.0f, 255.0f, 255.0f, 0.0f);
                }else{
                    //p_fAlpha = (p_fTimer * 2.0f) * 255.0f;
                    this.p_StartText.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255.0f);
                }
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    p_iPhase = 1;
                    GameObject SEobj = GameObject.Find("Title_SE");
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
                    this.p_StartText.GetComponent<SpriteRenderer>().color = new Color(255.0f, 255.0f, 255.0f, 0.0f);
                }else{
                    //p_fAlpha = (p_fTimer * 2.0f) * 255.0f;
                    this.p_StartText.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255.0f);
                }
                if (p_iCounter >= 7)
                {
                    SceneManager.LoadScene("StegeSelect");
                }
                break;
        }
    }
}