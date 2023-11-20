using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeimaSkill : MonoBehaviour
{
    //---- 桂馬、角のスキル攻撃オブジェクト -----------------//

    float speedx = 10.0f;
    GameObject Player;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {
        //　上からスキル攻撃オブジェクトが降るように移動させる

        float y = speedx * Time.deltaTime;
        transform.Translate(0, -y, 0);

        if (transform.position.y <= 0)
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
