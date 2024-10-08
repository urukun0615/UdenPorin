using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGroundScript : MonoBehaviour
{
    private string groundTag = "Ground";
    public bool isGround = false;
    public bool isGroundEnter, isGroundStay, isGroundExit;

    //接地判定を返すメソッド
    //物理判定の更新毎に呼ぶ必要がある
    public bool Ground()
    {
        if (isGroundEnter || isGroundStay)
        {
            isGround = true;
        }
        else if (isGroundExit)
        {
            isGround = false;
        }

        isGroundEnter = false;
        isGroundStay = false;
        isGroundExit = false;
        return isGround;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == groundTag)
        {
            isGroundEnter = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == groundTag)
        {
            isGroundStay = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == groundTag)
        {
            isGroundExit = true;
        }
    }

    void Update()
    {
        // 毎フレーム接地状態を更新
        Ground();
    }
}
