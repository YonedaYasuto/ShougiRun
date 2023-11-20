using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillgaugeUP : MonoBehaviour
{
    //---- ��ω��A�K�E�Z�ɕK�v�ȃQ�[�W�� ---------------------------------//
    public int limitGauge;
    public int limitspecialGauge;

    //---- ��A�K�E�Z�̑I���p�l�� ----------------------------------------//
    public Text countGauge;
    public Text SpecialcountGauge;
    public GameObject killGauge;
    public GameObject specialGauge;
    public Slider slider;


    private void Start()
    {
        specialGauge.SetActive(false);
    }

    //---- �K�E�Z�Q�[�W�̊Ǘ��A�������Ǘ�����֐� ----------------------//
    public void UpdateGauge(int killcount, int specialCount)
    {

        countGauge.text = killcount + "/" + limitGauge;
        SpecialcountGauge.text = specialCount + "/" + limitspecialGauge;

        if (killcount < limitGauge)
        {
            killGauge.GetComponent<Button>().interactable = false;
        }

        // �K�E�Z�ɕK�v�ȃQ�[�W�����܂�����K�E�Z�{�^����\��
        else if (killcount >= limitGauge)
        {

            killGauge.GetComponent<Button>().interactable = true;

            if(specialCount >= limitspecialGauge)
            {
                specialGauge.SetActive(true);
                killGauge.SetActive(false);
            }
        }
        specialCount = Mathf.Clamp(specialCount, 0, limitspecialGauge);
        slider.value = specialCount;
    }

    //---- �K�E�Z�{�^���̕\���A��\�����Ǘ�����֐� ------------------//
    public void HideSpecial()
    {
        specialGauge.SetActive(false);
        killGauge.SetActive(true);
    }
}