using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerBattery : MonoBehaviour
{

    float fHP;
    Image[] imageBattery;

    public const float INIT_HP = 180.0f;
    public const float SPLIT_HP = INIT_HP / 3.0f;
    public const float HP_SPEED = 1.0f;
    public const int   HP_COUNT = 3;
    private int p_bFadeflag = 0;
    private float Fade_Timer = 2.0f;

    private GameObject p_gFadepanel;
    FadeScript FScript;

    // Use this for initialization
    void Start ()
    {
        fHP = INIT_HP;
        imageBattery = new Image[HP_COUNT];
        p_gFadepanel = GameObject.Find("Fadepanel");


        for (int i = 0; i < HP_COUNT; i++)
        {
            imageBattery[i] = GameObject.Find("Battery" + (i + 1)).GetComponent<Image>();
            imageBattery[i].fillAmount = 1.0f;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        fHP -= HP_SPEED * Time.deltaTime;
        if (fHP > SPLIT_HP * 2.0f)
        {
            imageBattery[0].fillAmount = 1.0f;
            imageBattery[1].fillAmount = 1.0f;
            imageBattery[2].fillAmount = (fHP - 2.0f * SPLIT_HP) / SPLIT_HP;
        }
        else if (fHP > SPLIT_HP)
        {
            imageBattery[0].fillAmount = 1.0f;
            imageBattery[1].fillAmount = (fHP - SPLIT_HP) / SPLIT_HP;
            imageBattery[2].fillAmount = 0.0f;
        }
        else if (fHP > 0.0f)
        {
            imageBattery[0].fillAmount = fHP / SPLIT_HP;
            imageBattery[1].fillAmount = 0.0f;
            imageBattery[2].fillAmount = 0.0f;
        }
        else if (fHP <= 0.0f)
        {
            p_bFadeflag = 1;

            FScript = p_gFadepanel.GetComponent<FadeScript>();
            FScript.p_vFade();

            if (p_bFadeflag == 1)
            {
                Fade_Timer -= Time.deltaTime;
                if (Fade_Timer <= 0)
                {
                    //  GameOver(電池不足)
                    SceneManager.LoadScene("GameOver");
                }
            }

        }
    }

    void OnTriggerEnter(Collider hit)
    {
        if (hit.CompareTag("battery"))
        {

            //　バッテリー回復
            fHP += 300;

            if (fHP >= INIT_HP)
            {
                fHP = INIT_HP;
            }

        }
    }

}
