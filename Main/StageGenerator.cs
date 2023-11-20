using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGenerator : MonoBehaviour
{
    const int StageChipSize = 15;

    int currentChipIndex;   //���݂̃X�e�[�W�ʒu

    public Transform character;      //�^�[�Q�b�g�L�����N�^�[�̎w��
    public GameObject[] stageChips;  //�X�e�[�W�`�b�v�v���n�u�z��
    public int startChipIndex;       //���������J�n�C���f�b�N�X
    public int preInstantiate;       //��ǂ݂��Đ��������
    public List<GameObject> generatedStageList = new List<GameObject>(); //�����ς݃X�e�[�W�`�b�v�ێ����X�g

    // Start is called before the first frame update
    void Start()
    {
        ///����������
        currentChipIndex = startChipIndex - 1;
        UpdateStage(preInstantiate);
    }

    // Update is called once per frame
    void Update()   ///�X�e�[�W�̍X�V�^�C�~���O�̊Ď�
    {
        if(character == null)
        {
            return;
        }
        //�L�����N�^�[�̈ʒu���猻�݂̃X�e�[�W�`�b�v�̃C���f�b�N�X���v�Z
        int charaPositionIndex = (int)(character.position.z / StageChipSize);

        //���̃X�e�[�W�`�b�v�ɓ�������X�e�[�W�̍X�V�������s��
        if (charaPositionIndex + preInstantiate > currentChipIndex)
        {
            UpdateStage(charaPositionIndex + preInstantiate);
        }
    }

    void UpdateStage(int toChipIndex)
    {
        if (toChipIndex <= currentChipIndex) return;

        //�w��̃X�e�[�W�`�b�v�܂ł��쐬
        for (int i = currentChipIndex + 1; i <= toChipIndex; i++)
        {
            GameObject stageObject = GenerateStage(i);

            //���������X�e�[�W�����X�g�ɒǉ�
            generatedStageList.Add(stageObject);
        }

        //�X�e�[�W�ۗL������ɂȂ�܂ŌÂ��X�e�[�W���폜
        while (generatedStageList.Count > preInstantiate + 2) DestroyOldStage();

        currentChipIndex = toChipIndex;
    }

    GameObject GenerateStage(int chipIndex)  //�w��̃C���f�b�N�X�ʒu�ɃX�e�[�W�I�u�W�F�N�g�������_���ɐ���
    {
        int nextStageChip = Random.Range(0, stageChips.Length);

        GameObject stageObject = (GameObject)Instantiate(
            stageChips[nextStageChip],
            new Vector3(0, 0, chipIndex * StageChipSize),
            Quaternion.identity
            );

        return stageObject;
    }

    void DestroyOldStage()  //��ԌÂ��X�e�[�W���폜
    {
        GameObject oldStage = generatedStageList[0];
        generatedStageList.RemoveAt(0);
        Destroy(oldStage);
    }
}
