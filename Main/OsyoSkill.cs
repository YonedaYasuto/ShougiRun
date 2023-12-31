using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OsyoSkill : MonoBehaviour
{
    //---- 王将のスキル攻撃 -----------------//
    GameObject Player;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    //---- 敵に当たったら倒す --------------------------//

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Player.GetComponent<TileSelect>().MotigomaCount++;
            Player.GetComponent<TileSelect>().KillCount++;
            Destroy(other.gameObject);
            Debug.Log("当たった！");
        }
    }
}
