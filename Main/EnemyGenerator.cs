using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{ 
    public TileSelect PlayerController;�@//�v���C���[���
    [SerializeField] GameObject Enemy;
    float GemeratorCount;�@//�v���C���[�̈ړ���
    int wavecount = 0;    //�E�F�[�u��
    float y = 180;�@�@�@�@//�G���v���C���[������������

    // Update is called once per frame
    void Update()
    {
        GemeratorCount = PlayerController.turn;
        if(GemeratorCount > 5)  //5�}�X�i�ނƃE�F�[�u�J�E���g����
        {
            //�E�F�[�u�R����
            if(wavecount < 3)
            {
                for (int i = 0; i < 2; i++)
                {
                    int randomX = Random.Range(-2, 3);
                    int randomZ = Random.Range(0, 5);
                    Instantiate(Enemy, EnemyPosition(randomX, randomZ), Quaternion.Euler(0.0f, y, 0.0f));
                }
            }
            //�E�F�[�u10����
            else if (3 < wavecount && wavecount <10)
            {
                for (int i = 0; i < 3; i++)
                {
                    int randomX = Random.Range(-2, 3);
                    int randomZ = Random.Range(0, 7);
                    Instantiate(Enemy, EnemyPosition(randomX, randomZ), Quaternion.Euler(0.0f, y, 0.0f));
                }
            }
            //�E�F�[�u40����
            else if (10 <= wavecount && wavecount < 40)
            {
                for (int i = 0; i < 4; i++)
                {
                    int randomX = Random.Range(-2, 3);
                    int randomZ = Random.Range(0, 9);
                    Instantiate(Enemy, EnemyPosition(randomX, randomZ), Quaternion.Euler(0.0f, y, 0.0f));
                }
            }
            //�E�F�[�u40�ȏ�
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    int randomX = Random.Range(-2, 3);
                    int randomZ = Random.Range(0, 5);
                    Instantiate(Enemy, EnemyPosition(randomX, randomZ), Quaternion.Euler(0.0f, y, 0.0f));
                }
            }
            PlayerController.turn = 0;   //�v���C���[�̈ړ��񐔃��Z�b�g
            wavecount++;�@               //�E�F�[�u�J�E���g��i�߂�
        }
    }

    Vector3 EnemyPosition(int x, int z)  //�G�̔z�u�ʒu
    {
        float posY = PlayerController.objPositionY;
        float posZ = PlayerController.objPositionZ;
        return new Vector3(x, posY, (int) posZ + 7 + z );
    }
}
