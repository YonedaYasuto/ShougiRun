using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePanel : MonoBehaviour
{
    //---- 残機UIを表示させる関数 --------------//

    public GameObject[] icons;

    public void UpdateLife(int life)
    {
        for(int i = 0; i<icons.Length; i++)
        {
            if (i < life) icons[i].SetActive(true);
            else icons[i].SetActive(false);
        }
    }
}
