using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //プレイヤー情報
    public TileSelect PlayerController;
    public LifePanel lifePanel;
    public SkillPanel skillPanel;
    public GameObject Player;

    //駒選択パネル
    public KillgaugeUP Osyo;
    public KillgaugeUP Hu;
    public KillgaugeUP Keima;
    public KillgaugeUP Kyosya;
    public KillgaugeUP Kin;
    public KillgaugeUP Gin;
    public KillgaugeUP Kaku;
    public KillgaugeUP Hisya;

    //各必殺技ゲージ
    [System.NonSerialized] public int NariHu = 0;
    [System.NonSerialized] public int NariKei = 0;
    [System.NonSerialized] public int NariKyou = 0;
    [System.NonSerialized] public int NariGin = 0;
    [System.NonSerialized] public int NariKin = 0;
    [System.NonSerialized] public int Ryuma = 0;
    [System.NonSerialized] public int Ryuou = 0;
    [System.NonSerialized] public int NariOu = 0;

    //スコアボード
    [SerializeField] GameObject startText;
    [SerializeField] GameObject endText;
    [SerializeField] GameObject ScoreBord;
    [SerializeField] Text MetreText;
    [SerializeField] Text KillText;
    [SerializeField] Text ScoreText;

    float metre;　//移動距離
    float kill;　 //キル数
    float score;　//スコア

    //SE
    AudioSource audioSource;
    [SerializeField] AudioClip endSE;
    [SerializeField] AudioClip scoreSE;
    [SerializeField] AudioClip selectSE;

    private void Start()
    {
        //開始時1.5f「始め！！」と表示
        Invoke("InactiveText", 1.5f);
        ScoreBord.SetActive(false);
        endText.SetActive(false);

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //ライフパネルを更新
        lifePanel.UpdateLife(PlayerController.Life());

        //スキルカウントの表示と更新
        skillPanel.UpdateSkill(PlayerController.Skill());

        //スコアボードの更新
        metre = PlayerController.metre;
        kill = PlayerController.KillCount;
        score = metre * 50 + kill * 100 ;

        //現在のスコアの表示
        MetreText.text = "" + metre;
        KillText.text = "" + kill;
        ScoreText.text = "" + score;

        //必殺技ゲージの更新
        Osyo.UpdateGauge(PlayerController.Kill(), PlayerController.OsyoSpecial);
        Hu.UpdateGauge(PlayerController.Kill(), PlayerController.HuSpecial);
        Keima.UpdateGauge(PlayerController.Kill(), PlayerController.KeimaSpecial);
        Kyosya.UpdateGauge(PlayerController.Kill(), PlayerController.KyosyaSpecial);
        Kin.UpdateGauge(PlayerController.Kill(), PlayerController.KinSpecial);
        Gin.UpdateGauge(PlayerController.Kill(), PlayerController.GinSpecial);
        Kaku.UpdateGauge(PlayerController.Kill(), PlayerController.KakuSpecial);
        Hisya.UpdateGauge(PlayerController.Kill(), PlayerController.HisyaSpecial);


        //プレイヤーが死亡した際の処理
        if (PlayerController.Life() <= 0)
        {
            GameObject[] Enemyobjects = GameObject.FindGameObjectsWithTag("Enemytile");
            foreach (GameObject tiledestroy in Enemyobjects)
            {
                Destroy(tiledestroy);
            }
            //プレイヤーの移動マスは削除
            GameObject[] objects = GameObject.FindGameObjectsWithTag("tile");
            foreach (GameObject tiledestroy in objects)
            {
                Destroy(tiledestroy);
            }
            // 0.2秒後に消える
            Destroy(Player, 0.2f);
            enabled = false;
            StartCoroutine("EndGame");
        }
    }

    void InactiveText()
    {
        startText.SetActive(false);
    }


    //ボタンを押して必殺技ゲージ使用
    public void OnClickOsyo()
    {
        PlayerController.MotigomaCount -= Osyo.limitGauge;
        audioSource.PlayOneShot(selectSE);
    }
    public void OnClickHu()
    {
        PlayerController.MotigomaCount -= Hu.limitGauge;
        audioSource.PlayOneShot(selectSE);
    }
    public void OnClickKeima()
    {
        PlayerController.MotigomaCount -= Keima.limitGauge;
        audioSource.PlayOneShot(selectSE);
    }
    public void OnClickKyosya()
    {
        PlayerController.MotigomaCount -= Kyosya.limitGauge;
        audioSource.PlayOneShot(selectSE);
    }
    public void OnClickKin()
    {
        PlayerController.MotigomaCount -= Kin.limitGauge;
        audioSource.PlayOneShot(selectSE);
    }
    public void OnClickGin()
    {
        PlayerController.MotigomaCount -= Gin.limitGauge;
        audioSource.PlayOneShot(selectSE);
    }
    public void OnClickKaku()
    {
        PlayerController.MotigomaCount -= Kaku.limitGauge;
        audioSource.PlayOneShot(selectSE);
    }
    public void OnClickHisya()
    {
        PlayerController.MotigomaCount -= Hisya.limitGauge;
        audioSource.PlayOneShot(selectSE);
    }

    public void OnClickOsyoSpecial()
    {
        PlayerController.OsyoSpecial -= Osyo.limitspecialGauge;
        audioSource.PlayOneShot(selectSE);
    }
    public void OnClickHuSpecial()
    {
        PlayerController.HuSpecial -= Hu.limitspecialGauge; ;
        audioSource.PlayOneShot(selectSE);
    }
    public void OnClickKeimSpecial()
    {
        PlayerController.KeimaSpecial -= Keima.limitspecialGauge;
        audioSource.PlayOneShot(selectSE);
    }
    public void OnClickKyosyaSpecial()
    {
        PlayerController.KyosyaSpecial -= Kyosya.limitspecialGauge;
        audioSource.PlayOneShot(selectSE);
    }
    public void OnClickKinSpecial()
    {
        PlayerController.KinSpecial -= Kin.limitspecialGauge;
        audioSource.PlayOneShot(selectSE);
    }
    public void OnClickGinSpecial()
    {
        PlayerController.GinSpecial -= Gin.limitspecialGauge;
        audioSource.PlayOneShot(selectSE);
    }
    public void OnClickKakuSpecial()
    {
        PlayerController.KakuSpecial -= Kaku.limitspecialGauge;
        audioSource.PlayOneShot(selectSE);
    }
    public void OnClickHisyaSpecial()
    {
        PlayerController.HisyaSpecial -= Hisya.limitspecialGauge;
        audioSource.PlayOneShot(selectSE);
    }

    IEnumerator EndGame()
    {
        endText.SetActive(true);
        audioSource.PlayOneShot(endSE);

        yield return new WaitForSeconds(2.5f);

        audioSource.PlayOneShot(scoreSE);
        endText.SetActive(false);
        ScoreBord.SetActive(true);
    }
}
