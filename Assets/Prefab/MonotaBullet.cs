using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MonotaBullet : MonoBehaviour
{
    public GameObject Monota;
    public event Action OnBulletDestroyed;
    

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1f);

        // 弾丸のRigidbodyが重力の影響を受けないようにする
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)//弾丸が何かに触れたら
    {
        if (collision.gameObject.CompareTag("MonotaInteraction"))//MonotaInteractionのタグがついてる場合
        {
            Debug.Log("MonotaInteractionに衝突");


        }

        // 弾丸が何かに衝突したとき即座に破壊する
        Destroy(gameObject);
    }

    void OnDestroy()
    {
        // 弾丸が消えるときにイベントを発火する
        OnBulletDestroyed?.Invoke();
    }
}
