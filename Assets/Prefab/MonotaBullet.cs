using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MonotaBullet : MonoBehaviour
{
    public float pullForce = 50f;
    public GameObject monota;
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

    void OnCollisionEnter(Collision collision)//弾丸が何かに触れた時
    {
        if (collision.gameObject.CompareTag("MonotaInteraction"))//MonotaInteractionのタグがついてる場合
        {
            Debug.Log("MonotaInteractionに衝突");

            Rigidbody targetRb = collision.gameObject.GetComponent<Rigidbody>();
            if (targetRb != null)
            {
                // Monota の方向に引き寄せる力を加える
                Vector3 pullDirection = (monota.transform.position - collision.transform.position).normalized;
                targetRb.AddForce(pullDirection * pullForce, ForceMode.Impulse);
            }
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
