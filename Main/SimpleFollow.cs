using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFollow : MonoBehaviour
{
    Vector3 diff;

    public GameObject target;
    public float followSpeed;

    //---- �v���C���[�̔w��ŒǏ]����J�����̐ݒ� ---------------------//
    void Start()
    {
        diff = target.transform.position - transform.position;
        diff.z = diff.z + 1;
    }


    //---- �v���C���[�̈ړ��ɍ��킹�ĂȂ߂炩�ɃJ�����ړ� ------------//
    void LateUpdate()
    {
        if (target == null) return;
        else
        {
            if (target.transform.position.z > 1)
            {
                transform.position = Vector3.Lerp(
                    transform.position,
                    target.transform.position - diff,
                    Time.deltaTime * followSpeed
                    );
            }
        }
    }
}
