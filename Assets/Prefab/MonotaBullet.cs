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

        // �e�ۂ�Rigidbody���d�͂̉e�����󂯂Ȃ��悤�ɂ���
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

    void OnCollisionEnter(Collision collision)//�e�ۂ������ɐG�ꂽ��
    {
        if (collision.gameObject.CompareTag("MonotaInteraction"))//MonotaInteraction�̃^�O�����Ă�ꍇ
        {
            Debug.Log("MonotaInteraction�ɏՓ�");


        }

        // �e�ۂ������ɏՓ˂����Ƃ������ɔj�󂷂�
        Destroy(gameObject);
    }

    void OnDestroy()
    {
        // �e�ۂ�������Ƃ��ɃC�x���g�𔭉΂���
        OnBulletDestroyed?.Invoke();
    }
}
