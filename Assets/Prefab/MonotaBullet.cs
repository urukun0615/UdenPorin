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

        // ’eŠÛ‚ÌRigidbody‚ªd—Í‚Ì‰e‹¿‚ğó‚¯‚È‚¢‚æ‚¤‚É‚·‚é
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

    void OnCollisionEnter(Collision collision)//’eŠÛ‚ª‰½‚©‚ÉG‚ê‚½‚ç
    {
        if (collision.gameObject.CompareTag("MonotaInteraction"))//MonotaInteraction‚Ìƒ^ƒO‚ª‚Â‚¢‚Ä‚éê‡
        {
            Debug.Log("MonotaInteraction‚ÉÕ“Ë");

            Rigidbody targetRb = collision.gameObject.GetComponent<Rigidbody>();
            if (targetRb != null)
            {
                // Monota ‚Ì•ûŒü‚Éˆø‚«Šñ‚¹‚é—Í‚ğ‰Á‚¦‚é
                Vector3 pullDirection = (monota.transform.position - collision.transform.position).normalized;
                targetRb.AddForce(pullDirection * pullForce, ForceMode.Impulse);
            }
        }

        // ’eŠÛ‚ª‰½‚©‚ÉÕ“Ë‚µ‚½‚Æ‚«‘¦À‚É”j‰ó‚·‚é
        Destroy(gameObject);
    }

    void OnDestroy()
    {
        // ’eŠÛ‚ªÁ‚¦‚é‚Æ‚«‚ÉƒCƒxƒ“ƒg‚ğ”­‰Î‚·‚é
        OnBulletDestroyed?.Invoke();
    }
}
