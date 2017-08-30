using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public UnityEngine.UI.Text scoreLabel;

    public GameObject ClearLabelObject;

    public GameObject FadeObject;

    public void Update()
    {
        int count = GameObject.FindGameObjectsWithTag("battery").Length;
        scoreLabel.text = count.ToString();

        if(count == 0)
        {
            // オブジェクトをアクティブにする
            ClearLabelObject.SetActive(true);
            FadeObject.SetActive(true);
        }
    }
}