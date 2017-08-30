using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour
{
    // トリガーとの接触時に呼ばれるコールバック
    void OnTriggerEnter(Collider hit)
    {
        // 接触対象はPlayerタグですか？
        if (hit.CompareTag("Player"))
        {

            GameObject SEobj = GameObject.Find("Battery_SE");
            if(SEobj != null)
            {
                sound S = SEobj.GetComponent<sound>();
                S.Sound01();
            }

            // このコンポーネントを持つGameObjectを破棄する
            Destroy(gameObject);

        }
    }
}