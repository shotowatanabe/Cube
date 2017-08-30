using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public float speed = 1f;
    public float rotationPeriod = 0.3f;
    Vector3 startPos;
    float rotationTime = 0;
    float direction = 0;
    Quaternion fromRotation;
    Quaternion toRotation;
    Vector3 velocity1;
    Vector3 velocity2;
    GameObject child;

    Vector3 displacement;   //  変位
    Vector3 vecDown = new Vector3(0, -1.0f, 0);
    Vector3 velocity3;

    public Material[] materials;
    private int cnt = 0;

    bool N = true;
    bool S = false;

    bool hitA = false;
    bool hitB = false;

    private GameObject p_gDeath;

    Death_Script FScript;
    GameObject SEobj;


    //  状態
    enum PlayerPhaseCode
    {
        ADJUST = 0,
        IO = 1,
        MOVE = 2,
        ROTATE = 3
    };
    PlayerPhaseCode phase = PlayerPhaseCode.IO;
    void Start()
    {
        // 自分のRigidbodyを取ってくる
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Rigidbody.useGravity = false;

        velocity1 = new Vector3(0, 0, 0);
        velocity2 = new Vector3(0, 0, 0);
        velocity3 = new Vector3(0, 0, 0);

        displacement = new Vector3();   //  変位の初期化
        displacement = Vector3.zero;

        child = GameObject.Find("DummyPlayer");

        p_gDeath = GameObject.Find("GameObject");
        SEobj = GameObject.Find("Death_SE");
    }

    void Update()
    {
        // NS切り替え
        if (Input.GetKeyUp(KeyCode.Space))
        {
            N = !N;
            S = !S;

            cnt++;
            if (cnt == 2)
            {
                cnt = 0;
            }
            child.GetComponent<Renderer>().material = materials[cnt];
        }

        if(hitA && hitB)
        {
            FScript = p_gDeath.GetComponent<Death_Script>();
            FScript.pDeath();
            //  SceneManager.LoadScene("GameOver");
        }
    }


    void FixedUpdate()
    {
        // WSでキャラ移動
        float x = 0.0f;
        float z = 0.0f;
        float length;
        Vector3 vec = new Vector3();
        RaycastHit hitInfo;
        switch (phase)
        {
            case PlayerPhaseCode.ADJUST:
                if (displacement != Vector3.zero)
                {
                    float cx, cz;
                    float sign = Mathf.Sign(displacement.x);
                    cx = Mathf.Abs(displacement.x);
                    cx -= Mathf.Floor(cx);  //  １以下の値に限定
                    cx *= sign;

                    sign = Mathf.Sign(displacement.z);
                    cz = Mathf.Abs(displacement.z);
                    cz -= Mathf.Floor(cz);  //  １以下の値に限定
                    cz *= sign;

                    displacement.x = cx;
                    displacement.y = 0.0f;
                    displacement.z = cz;
                    m_Rigidbody.position -= displacement;

                    displacement = Vector3.zero;
                }
                velocity1 = Vector3.zero;
                child.GetComponent<Rotation>().adjust();
                goto case PlayerPhaseCode.IO;   //  fall through
            case PlayerPhaseCode.IO:
                //キー入力を拾う
                x = Input.GetAxisRaw("Horizontal");
                if (x != 0)
                {
                    direction = Mathf.Sign(x);
                    startPos = transform.position;                                              // 回転前の座標を保持
                    fromRotation = transform.rotation;                                          // 回転前のクォータニオンを保持
                    transform.Rotate(0, direction * 90, 0);                                     // 回転方向に90度回転させる
                    toRotation = transform.rotation;                                            // 回転後のクォータニオンを保持
                    transform.rotation = fromRotation;                                          // CubeのRotationを回転前に戻す。
                    rotationTime = 0;                                                           // 回転中の経過時間を0に。
                    phase = PlayerPhaseCode.ROTATE;
                }
                else
                {
                    if (Input.GetKey(KeyCode.W))
                    {
                        z = 1.0f * speed;
					    GetComponent<sound>().Sound01();
                    }
                    else if (Input.GetKey(KeyCode.S))
                    {
                        z = -1.0f * speed;
					    GetComponent<sound>().Sound01();
                    }
                    if (z != 0.0f)
                    {
                        velocity1 = z * transform.forward;
                        velocity1.y = 0.0f;
                        phase = PlayerPhaseCode.MOVE;
                        goto case PlayerPhaseCode.MOVE;
                    }
                }
                break;
            case PlayerPhaseCode.MOVE:
                //  赤壁・青壁
                vec = transform.forward;
                vec.y -= 1.0f;
                vec = Vector3.Normalize(vec);
                velocity3 = Vector3.zero;
                if (Physics.Raycast(transform.position, vec, out hitInfo, 0.5f * 1.415f))
                {
                    Collider col = hitInfo.collider;
                    if (col.name == "RedWall" && S == true)
                    {
                        if (Input.GetKey(KeyCode.W))
                        {
                            velocity3.y = 1.0f * speed;
                        }
                    }
                    if ((col.name == "BlueWall" && N == true))
                    {
                        if (Input.GetKey(KeyCode.W))
                        {
                            velocity3.y = 1.0f * speed;
                        }
                    }
                }
                displacement += velocity1 * Time.deltaTime;
                //  変位の積算
                length = Vector3.Magnitude(displacement);
                if (1.0 <= length)
                {
                    phase = PlayerPhaseCode.ADJUST;
                }
                break;
            case PlayerPhaseCode.ROTATE:
                rotationTime += Time.deltaTime;                                    // 経過時間を増やす
                float ratio = rotationTime / rotationPeriod;
                if (ratio >= 1)
                {
                    ratio = 1.0f;
                    direction = 0;
                    rotationTime = 0;
                    phase = PlayerPhaseCode.ADJUST;
                }
                transform.rotation = Quaternion.Lerp(fromRotation, toRotation, ratio);      // Quaternion.Lerpで現在の回転角をセット
                break;
        }

        //  12/12 岸本改造
        //if (Physics.SphereCast(transform.position, 0.48f,vecDown,out hitInfo,0.03f)) {
        if (Physics.SphereCast(transform.position, 0.48f, vecDown, out hitInfo, 0.1f))
        {
            if (hitInfo.distance <= 0.02f)
                velocity2.y = 0;
            else
                velocity2.y = Mathf.Max(velocity2.y, 2.0f * Physics.gravity.y * Time.deltaTime);
        }
        else
        {
            velocity2.y += Physics.gravity.y * Time.deltaTime;
        }
        //  落下速度を制限（１フレームあたり半径以上落下すると床抜けする）
        //velocity2.y = Mathf.Max(velocity2.y, -(0.45f / Time.deltaTime));
        velocity2.y = Mathf.Max(velocity2.y, -(0.24f / Time.deltaTime));

        child.GetComponent<Rotation>().rotateXZ(velocity1.x * Time.deltaTime, velocity1.z * Time.deltaTime);
        //  壁のぼり中は引力Off
        if (Vector3.SqrMagnitude(velocity3) != 0.0)
        {
            velocity2 = Vector3.zero;
        }
        m_Rigidbody.velocity = Vector3.zero;
        m_Rigidbody.position += (velocity1 + velocity2 + velocity3) * Time.deltaTime;
        velocity3 = Vector3.zero;   //  毎フレームセットするのでここで消費
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag== "PressTrigger_A")
        {
            hitA = true;
        }
        if(col.gameObject.tag== "PressTrigger_B")
        {
            hitB = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "PressTrigger_A")
        {
            hitA = false;
        }
        if (col.gameObject.tag == "PressTrigger_B")
        {
            hitB = false;
        }
    }
}

