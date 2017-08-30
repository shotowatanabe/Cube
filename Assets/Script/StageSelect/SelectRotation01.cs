using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class SelectRotation01 : MonoBehaviour
{
    Vector3 CubePosition01;
    Vector3 CubePosition02;
    Vector3 CubePosition03;
    Vector3 CubePosition04;

    Vector3 StartPosition;

    int iPos = 0;
    int iCounter = 0;

    float Timer = 0.0f;
    float Fade_Timer = 4.0f;
    int p_Phase;

    float[] CubeCoppy = new float[12];

    Vector3[] CubePosition = {  new Vector3(0.0f, 0.6f, -7.0f),
                                new Vector3(5.0f, 1.6f, -3.5f),
                                new Vector3(0.0f, 3.6f, -2.0f),
                                new Vector3(-5.0f, 1.6f, -3.5f)};
    GameObject SelectSE;
    GameObject DecisionSE;
    GameObject P_gFadePanel;
    GameObject g_Text01;
    GameObject g_Text02;

    void Start()
    {

        CubePosition01 = CubePosition[0];
        CubePosition02 = CubePosition[1];

        Timer = 1.0f;
        p_Phase = 0;
        
        this.transform.position = CubePosition01;

        SelectSE = GameObject.Find("StegeSelect_SE01");
        DecisionSE = GameObject.Find("StegeSelect_SE02");
        P_gFadePanel = GameObject.Find("Panel");

        g_Text01 = GameObject.Find("Text01");
        g_Text02 = GameObject.Find("Text02");

    }

    void Update()
    {
        switch (p_Phase)
        {
            case 0:
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    if (iPos == 0 && SelectSE != null)
                    {
                        sound S = SelectSE.GetComponent<sound>();
                        S.Sound01();
                    }

                    CubePosition01 = CubePosition[iPos];
                    iPos = (iPos + 1) % 4; 
                    CubePosition02 = CubePosition[iPos];
                    Timer = 1.0f;
                    p_Phase = 1;
                }
                else if (Input.GetKey(KeyCode.LeftArrow))
                {
                    if (iPos == 0 && SelectSE != null)
                    {
                        sound S01 = SelectSE.GetComponent<sound>();
                        S01.Sound01();
                    }

                    CubePosition01 = CubePosition[iPos];
                    iPos = (iPos <= 0) ? 3 : (iPos - 1);
                    CubePosition02 = CubePosition[iPos];
                    Timer = 1.0f;
                    p_Phase = 1;
                }
                else if (iPos == 0 && Input.GetKeyDown(KeyCode.Space))
                {
                    
                    if (DecisionSE != null)
                    {
                        sound S01 = DecisionSE.GetComponent<sound>();
                        S01.Sound01();
                    }
                    p_Phase = 2;
                }

                break;
            case 1:
                //方向キー入力処理
                Timer -= Time.deltaTime;

                StartPosition = CubePosition01 * Timer;
                StartPosition += CubePosition02 * (1.0f - Timer);

                this.transform.position = StartPosition;

                if (Timer <= 0)
                {
                    p_Phase = 0;
                }


                break;
            case 2:
                //ゲームに移動

                Fade_Timer -= Time.deltaTime;
                
                if (Fade_Timer <= 0)
                {
                    SceneManager.LoadScene("Stage01");
                }
                break;
        }
        if (iPos == 0)
        {
            g_Text01.GetComponent<Text>().enabled = true;
            g_Text02.GetComponent<Text>().enabled = true;
        }
        else
        {
            g_Text01.GetComponent<Text>().enabled = false;
            g_Text02.GetComponent<Text>().enabled = false;
        }
    }
}
