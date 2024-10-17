//逆L字の壁を上昇させるスイッチのスクリプトby片桐歩夢

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRisingSwitch : MonoBehaviour
{
    public bool switchPushing = false;//スイッチが押されているか
    public GameObject SwitchTrriger;
    public GameObject LWall;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (switchPushing)
        {
            LWall.transform.position += new Vector3(0, 1 * Time.deltaTime, 0);
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "MonotaCarryBox")
        {
            switchPushing = true;
            //Debug.Log("MonotaCarryBoxがトリガーに触れている");
        }
    }

    // トリガーから出た時
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "MonotaCarryBox")
        {
            switchPushing = false;
        }
    }

}
