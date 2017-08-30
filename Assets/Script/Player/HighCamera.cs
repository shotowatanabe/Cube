using UnityEngine;
using System.Collections;

public class HighCamera : MonoBehaviour
{
    public float speed = 1f;
    public float rotationPeriod = 0.3f;
    bool isRotate = false;
    Vector3 startPos;
    float rotationTime = 0;
    float direction = 0;
    Quaternion fromRotation;
    Quaternion toRotation;
    public Transform target;    // ターゲットへの参照
    private Vector3 offset;     // 相対座標

    void Start()
    {
        //自分自身とtargetとの相対距離を求める
        offset = GetComponent<Transform>().position - target.position;
    }

    void Update()
    {
        // 自分自身の座標に、targetの座標に相対座標を足した値を設定する
        GetComponent<Transform>().position = target.position + offset;

        float y = 0;
        y = Input.GetAxisRaw("Horizontal");

        if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)) && !isRotate)
        {
            direction = y;
            startPos = transform.position;                                              // 回転前の座標を保持
            fromRotation = transform.rotation;                                          // 回転前のクォータニオンを保持
            transform.Rotate(0, direction * 90, 0);                                     // 回転方向に90度回転させる
            toRotation = transform.rotation;                                            // 回転後のクォータニオンを保持
            transform.rotation = fromRotation;                                          // CubeのRotationを回転前に戻す。
            rotationTime = 0;                                                           // 回転中の経過時間を0に。
            isRotate = true;
        }
    }

    void FixedUpdate()
    {

        if (isRotate)
        {

            rotationTime += Time.fixedDeltaTime;                                    // 経過時間を増やす
            float ratio = Mathf.Lerp(0, 1, rotationTime / rotationPeriod);          // 回転の時間に対する今の経過時間の割合

            // 回転
            if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
            {
                transform.rotation = Quaternion.Lerp(fromRotation, toRotation, ratio);      // Quaternion.Lerpで現在の回転角をセット
            }
            // 移動・回転終了時に各パラメータを初期化。isRotateフラグを下ろす。
            if (ratio == 1)
            {
                isRotate = false;
                direction = 0;
                rotationTime = 0;
            }
        }
    }
}