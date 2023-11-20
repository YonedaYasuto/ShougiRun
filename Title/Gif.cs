using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gif : MonoBehaviour
{
    [SerializeField] float repeatTime;    //�J��Ԃ�����
    private float elapsedTime;            //�o�ߎ���
    Image gif;                            
    [SerializeField] Sprite img1;
    [SerializeField] Sprite img2; 
    bool change = true;                   //�摜�̐؂�ւ��p��bool


    void Start()
    {
        gif = GetComponent<Image>();
        gif.sprite = img1;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;     //���Ԃ��J�E���g����

        if (elapsedTime >= repeatTime)     //�J��Ԃ����Ԃ��߂�����
        {
            change = !change;              

            elapsedTime = 0;               //�o�ߎ��Ԃ����Z�b�g����
        }

        if (change == false)               //bool�ŉ摜�؂�ւ�
        {
            gif.sprite = img1;
        }
        else gif.sprite = img2;
    }
}
