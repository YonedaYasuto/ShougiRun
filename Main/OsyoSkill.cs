using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OsyoSkill : MonoBehaviour
{
    //---- â§è´ÇÃÉXÉLÉãçUåÇ -----------------//
    GameObject Player;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    //---- ìGÇ…ìñÇΩÇ¡ÇΩÇÁì|Ç∑ --------------------------//

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Player.GetComponent<TileSelect>().MotigomaCount++;
            Player.GetComponent<TileSelect>().KillCount++;
            Destroy(other.gameObject);
            Debug.Log("ìñÇΩÇ¡ÇΩÅI");
        }
    }
}
