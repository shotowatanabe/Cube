using UnityEngine;
using System.Collections;

public class Over_Script : MonoBehaviour {

    private float Fade_Timer = 2.0f;

    private bool p_bFadeflag = false;

    private GameObject p_gFadepanel;

    FadeScript FScript;
    GameObject SEobj;


    void Start()
    {
        p_gFadepanel = GameObject.Find("Fadepanel");
        SEobj = GameObject.Find("Press_SE");
    }

    void Update()
    {
       
    }

    // トリガーとの接触時に呼ばれるコールバック
    void OnTriggerEnter(Collider hit)
    {
        // 接触対象(Player)
        if (hit.CompareTag("Player"))
        {

            if (p_bFadeflag == false && SEobj != null)
            {
                sound S = SEobj.GetComponent<sound>();
                S.Sound01();
            }
            p_bFadeflag = true;

            //  Application.LoadLevel("GameOver");
            FScript = p_gFadepanel.GetComponent<FadeScript>();
            FScript.p_vFade();

            if (p_bFadeflag == true)
            {
                Fade_Timer -= Time.deltaTime;
                if (Fade_Timer <= 0)
                {
                    Application.LoadLevel("GameOver");
                }
            }
        }
    }
}