using UnityEngine;
using System.Collections;

public class Moving : MonoBehaviour {
    //一秒当たりの回転角度
    private float Xangle;
    private float Yangle;

    //回転の中心をとるために使う変数
    private GameObject TargetObject;


    void Start()
    {
        Xangle = -1.5f;
        Yangle = 0.5f;
        //targetに、"Sample"の名前のオブジェクトのコンポーネントを見つけてアクセスする
        TargetObject = GameObject.Find("BasicObject");
        //変数targetPosにSampleの位置情報を取得
    }

    void Update()
    {
       
        this.gameObject.GetComponent<Transform>().transform.RotateAround(TargetObject.GetComponent<Transform>().transform.position, Vector3.up, Xangle);
        this.gameObject.GetComponent<Transform>().transform.RotateAround(TargetObject.GetComponent<Transform>().transform.position, Vector3.forward, Yangle);
    }
}
