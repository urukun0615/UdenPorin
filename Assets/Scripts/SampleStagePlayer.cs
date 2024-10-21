//サンプルシーンのデバッグ用キャラのスクリプト

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleStagePlayer : MonoBehaviour
{
    public float moveSpeed = 5f; // 移動速度
    public float jumpForce = 7f; // ジャンプの力
    private bool isGrounded; // プレイヤーが地面にいるかどうか
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Rigidbodyコンポーネントを取得
    }

    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // ADキー入力 (A: -1, D: 1)

        // X軸に沿って左右移動
        Vector3 movement = new Vector3(moveHorizontal, 0f, 0f) * moveSpeed * Time.deltaTime;
        rb.MovePosition(transform.position + movement);
    }

    void Jump()
    {
        // 上方向に力を加えてジャンプ
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false; // 空中にいる状態に切り替え
    }

    // 地面に接触しているかを確認
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // 地面に接触しているときにジャンプ可能状態に戻す
        }
    }
}
