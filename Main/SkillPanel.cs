using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPanel : MonoBehaviour
{
    public GameObject[] icons;

    public void UpdateSkill(int skill)
    {
        for (int i = 0; i < icons.Length; i++)
        {
            if (i < skill) icons[i].SetActive(true);
            else icons[i].SetActive(false);
        }
    }
}
