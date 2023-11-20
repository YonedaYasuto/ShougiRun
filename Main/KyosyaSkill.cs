using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KyosyaSkill : MonoBehaviour
{
    //---- ���ԁA��Ԃ̃X�L���U���I�u�W�F�N�g -----------------//

    float speedx = 10.0f;
    GameObject Player;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {
        // �X�L���U���I�u�W�F�N�g���Ֆʂ����؂�悤�Ɉړ�������

        float x = speedx * Time.deltaTime;
        transform.Translate(-x, 0, 0);

        if(transform.position.x <= -10)
        {
            Destroy(gameObject);
        }
    }

    //---- �G�ɓ���������|�� --------------------------//
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Player.GetComponent<TileSelect>().MotigomaCount++;
            Player.GetComponent<TileSelect>().KillCount++;
            Destroy(other.gameObject);
            //Debug.Log("���������I");
        }
    }
}
