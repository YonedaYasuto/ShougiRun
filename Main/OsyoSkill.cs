using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OsyoSkill : MonoBehaviour
{
    //---- �����̃X�L���U�� -----------------//
    GameObject Player;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    //---- �G�ɓ���������|�� --------------------------//

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Player.GetComponent<TileSelect>().MotigomaCount++;
            Player.GetComponent<TileSelect>().KillCount++;
            Destroy(other.gameObject);
            Debug.Log("���������I");
        }
    }
}
