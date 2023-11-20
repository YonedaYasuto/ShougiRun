using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //�v���C���[���
    public TileSelect PlayerController;
    public LifePanel lifePanel;
    public SkillPanel skillPanel;
    public GameObject Player;

    //��I���p�l��
    public KillgaugeUP Osyo;
    public KillgaugeUP Hu;
    public KillgaugeUP Keima;
    public KillgaugeUP Kyosya;
    public KillgaugeUP Kin;
    public KillgaugeUP Gin;
    public KillgaugeUP Kaku;
    public KillgaugeUP Hisya;

    //�e�K�E�Z�Q�[�W
    [System.NonSerialized] public int NariHu = 0;
    [System.NonSerialized] public int NariKei = 0;
    [System.NonSerialized] public int NariKyou = 0;
    [System.NonSerialized] public int NariGin = 0;
    [System.NonSerialized] public int NariKin = 0;
    [System.NonSerialized] public int Ryuma = 0;
    [System.NonSerialized] public int Ryuou = 0;
    [System.NonSerialized] public int NariOu = 0;

    //�X�R�A�{�[�h
    [SerializeField] GameObject startText;
    [SerializeField] GameObject endText;
    [SerializeField] GameObject ScoreBord;
    [SerializeField] Text MetreText;
    [SerializeField] Text KillText;
    [SerializeField] Text ScoreText;

    float metre;�@//�ړ�����
    float kill;�@ //�L����
    float score;�@//�X�R�A

    //SE
    AudioSource audioSource;
    [SerializeField] AudioClip endSE;
    [SerializeField] AudioClip scoreSE;
    [SerializeField] AudioClip selectSE;

    private void Start()
    {
        //�J�n��1.5f�u�n�߁I�I�v�ƕ\��
        Invoke("InactiveText", 1.5f);
        ScoreBord.SetActive(false);
        endText.SetActive(false);

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //���C�t�p�l�����X�V
        lifePanel.UpdateLife(PlayerController.Life());

        //�X�L���J�E���g�̕\���ƍX�V
        skillPanel.UpdateSkill(PlayerController.Skill());

        //�X�R�A�{�[�h�̍X�V
        metre = PlayerController.metre;
        kill = PlayerController.KillCount;
        score = metre * 50 + kill * 100 ;

        //���݂̃X�R�A�̕\��
        MetreText.text = "" + metre;
        KillText.text = "" + kill;
        ScoreText.text = "" + score;

        //�K�E�Z�Q�[�W�̍X�V
        Osyo.UpdateGauge(PlayerController.Kill(), PlayerController.OsyoSpecial);
        Hu.UpdateGauge(PlayerController.Kill(), PlayerController.HuSpecial);
        Keima.UpdateGauge(PlayerController.Kill(), PlayerController.KeimaSpecial);
        Kyosya.UpdateGauge(PlayerController.Kill(), PlayerController.KyosyaSpecial);
        Kin.UpdateGauge(PlayerController.Kill(), PlayerController.KinSpecial);
        Gin.UpdateGauge(PlayerController.Kill(), PlayerController.GinSpecial);
        Kaku.UpdateGauge(PlayerController.Kill(), PlayerController.KakuSpecial);
        Hisya.UpdateGauge(PlayerController.Kill(), PlayerController.HisyaSpecial);


        //�v���C���[�����S�����ۂ̏���
        if (PlayerController.Life() <= 0)
        {
            GameObject[] Enemyobjects = GameObject.FindGameObjectsWithTag("Enemytile");
            foreach (GameObject tiledestroy in Enemyobjects)
            {
                Destroy(tiledestroy);
            }
            //�v���C���[�̈ړ��}�X�͍폜
            GameObject[] objects = GameObject.FindGameObjectsWithTag("tile");
            foreach (GameObject tiledestroy in objects)
            {
                Destroy(tiledestroy);
            }
            // 0.2�b��ɏ�����
            Destroy(Player, 0.2f);
            enabled = false;
            StartCoroutine("EndGame");
        }
    }

    void InactiveText()
    {
        startText.SetActive(false);
    }


    //�{�^���������ĕK�E�Z�Q�[�W�g�p
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
