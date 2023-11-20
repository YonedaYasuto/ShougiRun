using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{ 
    public TileSelect PlayerController;　//プレイヤー情報
    [SerializeField] GameObject Enemy;
    float GemeratorCount;　//プレイヤーの移動回数
    int wavecount = 0;    //ウェーブ数
    float y = 180;　　　　//敵がプレイヤーが向かい合う

    // Update is called once per frame
    void Update()
    {
        GemeratorCount = PlayerController.turn;
        if(GemeratorCount > 5)  //5マス進むとウェーブカウント増加
        {
            //ウェーブ３未満
            if(wavecount < 3)
            {
                for (int i = 0; i < 2; i++)
                {
                    int randomX = Random.Range(-2, 3);
                    int randomZ = Random.Range(0, 5);
                    Instantiate(Enemy, EnemyPosition(randomX, randomZ), Quaternion.Euler(0.0f, y, 0.0f));
                }
            }
            //ウェーブ10未満
            else if (3 < wavecount && wavecount <10)
            {
                for (int i = 0; i < 3; i++)
                {
                    int randomX = Random.Range(-2, 3);
                    int randomZ = Random.Range(0, 7);
                    Instantiate(Enemy, EnemyPosition(randomX, randomZ), Quaternion.Euler(0.0f, y, 0.0f));
                }
            }
            //ウェーブ40未満
            else if (10 <= wavecount && wavecount < 40)
            {
                for (int i = 0; i < 4; i++)
                {
                    int randomX = Random.Range(-2, 3);
                    int randomZ = Random.Range(0, 9);
                    Instantiate(Enemy, EnemyPosition(randomX, randomZ), Quaternion.Euler(0.0f, y, 0.0f));
                }
            }
            //ウェーブ40以上
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    int randomX = Random.Range(-2, 3);
                    int randomZ = Random.Range(0, 5);
                    Instantiate(Enemy, EnemyPosition(randomX, randomZ), Quaternion.Euler(0.0f, y, 0.0f));
                }
            }
            PlayerController.turn = 0;   //プレイヤーの移動回数リセット
            wavecount++;　               //ウェーブカウントを進める
        }
    }

    Vector3 EnemyPosition(int x, int z)  //敵の配置位置
    {
        float posY = PlayerController.objPositionY;
        float posZ = PlayerController.objPositionZ;
        return new Vector3(x, posY, (int) posZ + 7 + z );
    }
}
