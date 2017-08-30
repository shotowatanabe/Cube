using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Death_Script : MonoBehaviour {

    public bool p_bFadeflag = false;
    private float Fade_Timer = 4.0f;

    private GameObject p_gFadepanel;
    GameObject SEobj;
    GameObject BGMobj;
    GameObject Player;
    FadeScript D_Script;
    BGM_Script B_Script;

    // Use this for initialization
    void Start ()
    {
        p_gFadepanel = GameObject.Find("Fadepanel");
        Player = GameObject.Find("Player");
        SEobj = GameObject.Find("Death_SE");
        BGMobj = GameObject.Find("stage02_BGM");
    }

    // Update is called once per frame
    void Update()
    {
        if (p_bFadeflag == true)
        {
            Fade_Timer -= Time.deltaTime;
            if (Fade_Timer < 0)
            {
                //  GameOver
                p_bFadeflag = false;
                SceneManager.LoadScene("GameOver");
            }
        }
    }

    public void pDeath()
    {
        Player.GetComponent<PlayerController>().enabled = false;

        if (p_bFadeflag == false && SEobj != null)
        {
            sound S = SEobj.GetComponent<sound>();
            S.Sound01();
            p_bFadeflag = true;
        }

        D_Script = p_gFadepanel.GetComponent<FadeScript>();
        D_Script.p_vFade();

        B_Script = BGMobj.GetComponent<BGM_Script>();
        B_Script.BGM_Fade();

    }
}
