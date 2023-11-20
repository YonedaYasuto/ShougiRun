using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFollow : MonoBehaviour
{
    Vector3 diff;

    public GameObject target;
    public float followSpeed;

    //---- プレイヤーの背後で追従するカメラの設定 ---------------------//
    void Start()
    {
        diff = target.transform.position - transform.position;
        diff.z = diff.z + 1;
    }


    //---- プレイヤーの移動に合わせてなめらかにカメラ移動 ------------//
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
