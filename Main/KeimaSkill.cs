using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeimaSkill : MonoBehaviour
{
    //---- �j�n�A�p�̃X�L���U���I�u�W�F�N�g -----------------//

    float speedx = 10.0f;
    GameObject Player;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {
        //�@�ォ��X�L���U���I�u�W�F�N�g���~��悤�Ɉړ�������

        float y = speedx * Time.deltaTime;
        transform.Translate(0, -y, 0);

        if (transform.position.y <= 0)
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
