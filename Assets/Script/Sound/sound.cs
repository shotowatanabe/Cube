using UnityEngine;
using System.Collections;

public class sound : MonoBehaviour 
{
	private AudioSource sound01;
	float x = 0.0f;
	// Use this for initialization
	void Start () 
	{
		sound01 = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update () 
	{

	}

	public void Sound01()
	{
        //sound01.PlayOneShot(sound01.clip);
        AudioClip Clip01 = gameObject.GetComponent<AudioSource>().clip;
        gameObject.GetComponent<AudioSource>().PlayOneShot(Clip01);
	}
}
