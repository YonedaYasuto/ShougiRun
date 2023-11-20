using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillgaugeUP : MonoBehaviour
{
    //---- 駒変化、必殺技に必要なゲージ数 ---------------------------------//
    public int limitGauge;
    public int limitspecialGauge;

    //---- 駒、必殺技の選択パネル ----------------------------------------//
    public Text countGauge;
    public Text SpecialcountGauge;
    public GameObject killGauge;
    public GameObject specialGauge;
    public Slider slider;


    private void Start()
    {
        specialGauge.SetActive(false);
    }

    //---- 必殺技ゲージの管理、発動を管理する関数 ----------------------//
    public void UpdateGauge(int killcount, int specialCount)
    {

        countGauge.text = killcount + "/" + limitGauge;
        SpecialcountGauge.text = specialCount + "/" + limitspecialGauge;

        if (killcount < limitGauge)
        {
            killGauge.GetComponent<Button>().interactable = false;
        }

        // 必殺技に必要なゲージが溜まったら必殺技ボタンを表示
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

    //---- 必殺技ボタンの表示、非表示を管理する関数 ------------------//
    public void HideSpecial()
    {
        specialGauge.SetActive(false);
        killGauge.SetActive(true);
    }
}