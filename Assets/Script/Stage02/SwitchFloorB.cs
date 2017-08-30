using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SwitchFloorB : MonoBehaviour
{
    public Material[] materials;
    int cnt = 0;
    float timeleft;

    bool damage = true;

	private GameObject p_gDeath;

	Death_Script FScript;
	GameObject SEobj;

    // Use this for initialization
    void Start()
    {
		p_gDeath = GameObject.Find("GameObject");
		SEobj = GameObject.Find("Death_SE");
    }

    // Update is called once per frame
    void Update()
    {
        timeleft -= Time.deltaTime;
        if (timeleft <= 0.0)
        {
            timeleft = 5.0f;

            cnt++;
            if (cnt == 2)
            {
                cnt = 0;
            }
            GetComponent<Renderer>().material = materials[cnt];

            damage = !damage;
        }
    }

    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.name == "Player")
        {
            if (damage)
            {
				FScript = p_gDeath.GetComponent<Death_Script>();
				FScript.pDeath();

                //	SceneManager.LoadScene("GameOver");
            }
        }
    }
}
