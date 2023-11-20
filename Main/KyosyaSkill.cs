using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KyosyaSkill : MonoBehaviour
{
    //---- 香車、飛車のスキル攻撃オブジェクト -----------------//

    float speedx = 10.0f;
    GameObject Player;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {
        // スキル攻撃オブジェクトが盤面を横切るように移動させる

        float x = speedx * Time.deltaTime;
        transform.Translate(-x, 0, 0);

        if(transform.position.x <= -10)
        {
            Destroy(gameObject);
        }
    }

    //---- 敵に当たったら倒す --------------------------//
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Player.GetComponent<TileSelect>().MotigomaCount++;
            Player.GetComponent<TileSelect>().KillCount++;
            Destroy(other.gameObject);
            //Debug.Log("当たった！");
        }
    }
}
