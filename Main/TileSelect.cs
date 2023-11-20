using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class TileSelect : MonoBehaviour
{
    //----- �Q�[���X�R�A�Ɋւ���ϐ� -------------------------------------------//

    [SerializeField] GameObject tileHighlight;         //�v���C���[�̃}�X�\���^�C��
    [SerializeField] Text Score;                       //�X�R�A�̕\��
    [SerializeField] Text KillNumber;                  //�|������
    string status;                                     //��̏��
    bool IsPlayerTurn = true;  �@                      //�v���C���[�^�[���̐؂�ւ�
    bool HitTile = false;
    public int MotigomaCount = 0;                      //������J�E���g
    [System.NonSerialized] public int turn = 0;        //���݂̎萔
    [System.NonSerialized] public int metre = 0;       //�i�񂾋���
    [System.NonSerialized] public int KillCount = 0;   //�|������̐�

    //---- �v���C���[�̈ړ��Ɋւ���ϐ� ----------------------------------------//

    [System.NonSerialized] public float objPositionY;  //Y���W�̌Œ�p
    [System.NonSerialized] public float objPositionZ;
    Vector3 tilePosition;                              //�I�������^�C���̈ʒu


    //---- ���C�t --------------------------------------------------------------//

    const int DefaultLife = 3; //�ő僉�C�t
    int life = DefaultLife;

    //---- ���I�����郁�j���[ ------------------------------------------------//

    [SerializeField] GameObject SelectButton;
    [SerializeField] GameObject SelectMenue;
    bool inMenu = false;

    //---- ��ԁA���ԗp�̃X�L���U�� --------------------------------------------//

    [SerializeField] GameObject SquareSkillAttack;
    [SerializeField] GameObject RectangleSkillAttack;
    [SerializeField] GameObject RectangleOsyoSkillAttack;
    bool KSpecial = false;
    const int DefaultSpecialCount = 0;
    int SpecialCount = DefaultSpecialCount;

    //---- �X�L���Q�[�W�J�E���g ------------------------------------------------//

    [System.NonSerialized] public int HuSpecial = 0;
    [System.NonSerialized] public int KyosyaSpecial = 0;
    [System.NonSerialized] public int KinSpecial = 0;
    [System.NonSerialized] public int GinSpecial = 0;
    public int KeimaSpecial = 0;
    public int KakuSpecial = 0;
    public int HisyaSpecial = 0;
    public int OsyoSpecial = 0;

    //---- �X�L��SE ------------------------------------------------------------//

    AudioSource PlayeraudioSource;
    [SerializeField] AudioClip komaSE;
    [SerializeField] AudioClip enemykomaSE;
    [SerializeField] AudioClip kyosyaSkillSE;
    [SerializeField] AudioClip keimaSkillSE;
    [SerializeField] AudioClip osyoStartSE;
    [SerializeField] AudioClip OsyoSkillSE;
    [SerializeField] AudioClip osyoEndSE;
    [SerializeField] AudioClip DamageSE;
    [SerializeField] AudioClip clickSE;
    [SerializeField] AudioClip killSE;


    //---- ��̕\�ʂ̃}�e���A�� ------------------------------------------------//

    Material[] Omotemen;
    [SerializeField] Material[] KomaState;


    //---- ���C�t�擾�֐� ------------------------------------------------------//
    public int Life()
    {
        return life;
    }

    //---- �|������̎擾�֐� ------------------------------------------------//
    public int Kill()
    {
        return MotigomaCount;
    }

    //---- �X�L�������܂ł̃J�E���g�֐� ----------------------------------------//

    public int Skill()
    {
        return SpecialCount;
    }




    void Start()
    {
        //---- �����X�e�[�^�X�ݒ� ----------------------------------------//

        status = "Kin";                                                   //������X�^�[�g
        this.gameObject.transform.position = new Vector3(0, 0.55f, 0);
        objPositionY = this.gameObject.transform.position.y;
        KomaStatus();               �@                                  �@//�J�n���ɐݒ肵����̈ړ��}�X��\��
        IsPlayerTurn = true;�@�@�@�@�@                                  �@//�v���C���[�^�[������X�^�[�g
        SelectMenue.SetActive(false);                                   �@//��Z���N�g���j���[�͔�\��
        PlayeraudioSource = GetComponent<AudioSource>();
        Omotemen = GetComponent<MeshRenderer>().materials;
        Omotemen[1] = KomaState[3];
        GetComponent<MeshRenderer>().materials = Omotemen;
    }


    void Update()
    {
        //---- �X�L���������̃}�e���A���ω� -----------------------------------//

        if (KSpecial == true)
        {
            //�@�X�L��������
            switch (status)
            {
                case "Hu":
                    Omotemen[1] = KomaState[8];
                    GetComponent<MeshRenderer>().materials = Omotemen; break;
                case "Keima":
                    Omotemen[1] = KomaState[9];
                    GetComponent<MeshRenderer>().materials = Omotemen; break;
                case "Kyosya":
                    Omotemen[1] = KomaState[10];
                    GetComponent<MeshRenderer>().materials = Omotemen; break;
                case "Kin":
                    Omotemen[1] = KomaState[11];
                    GetComponent<MeshRenderer>().materials = Omotemen; break;
                case "Gin":
                    Omotemen[1] = KomaState[12];
                    GetComponent<MeshRenderer>().materials = Omotemen; break;
                case "Kaku":
                    Omotemen[1] = KomaState[13];
                    GetComponent<MeshRenderer>().materials = Omotemen; break;
                case "Hisya":
                    Omotemen[1] = KomaState[14];
                    GetComponent<MeshRenderer>().materials = Omotemen; break;
                case "Osyo":
                    Omotemen[1] = KomaState[15];
                    GetComponent<MeshRenderer>().materials = Omotemen; break;
            }
        }
        else
        {
            //�@��X�L��������
            switch (status)
            {
                case "Hu":
                    Omotemen[1] = KomaState[0];
                    GetComponent<MeshRenderer>().materials = Omotemen; break;
                case "Keima":
                    Omotemen[1] = KomaState[1];
                    GetComponent<MeshRenderer>().materials = Omotemen; break;
                case "Kyosya":
                    Omotemen[1] = KomaState[2];
                    GetComponent<MeshRenderer>().materials = Omotemen; break;
                case "Kin":
                    Omotemen[1] = KomaState[3];
                    GetComponent<MeshRenderer>().materials = Omotemen; break;
                case "Gin":
                    Omotemen[1] = KomaState[4];
                    GetComponent<MeshRenderer>().materials = Omotemen; break;
                case "Kaku":
                    Omotemen[1] = KomaState[5];
                    GetComponent<MeshRenderer>().materials = Omotemen; break;
                case "Hisya":
                    Omotemen[1] = KomaState[6];
                    GetComponent<MeshRenderer>().materials = Omotemen; break;
                case "Osyo":
                    Omotemen[1] = KomaState[7];
                    GetComponent<MeshRenderer>().materials = Omotemen; break;
            }
        }

        //---- z�������ɐi�񂾋����������UI�ɕ\�� -----------------------------------//

        objPositionZ = transform.position.z;
        metre = (int)transform.position.z;
        Score.text = "�����F" + metre + "m";�@�@�@�@�@�@�@�@�@//�i�񂾋���
        KillNumber.text = "�|������F" + KillCount + "��";   //�|������

        //---- �v���C���[�̎�ԂƓG�̎�Ԃ��Ǘ� -----------------------------------//

        //�@�v���C���[�̔�
        if (IsPlayerTurn)
        {
            //�N���b�N�ňړ�
            if (Input.GetMouseButtonDown(0))
            {
                Move(status);
            }
        }
        //  �G�̔�
        if (!IsPlayerTurn)
        {
            EnemyMover();
            PlayeraudioSource.PlayOneShot(enemykomaSE);
            IsPlayerTurn = true;
            HitTile = false;
        }
    }


    //---- �v���C���[�̈ړ��֐� ------------------------------------------------//

    void Move(string status)
    {
        // ���j���[��\����
        if (!inMenu)
        {
            // Ray���ړ��}�X�ɓ��������������ړ��\
            int layerMask = 1 << 7;
            Ray ray1 = Camera.main.ScreenPointToRay(Input.mousePosition);
            Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            Physics.Raycast(ray2, out hitInfo, Mathf.Infinity, layerMask);

            // �ړ��}�X�ȊO�̏ꍇ�͂�����x�v���C���[�̈ړ�������s��
            if (hitInfo.collider == null)
            {
                IsPlayerTurn = true;
            }
            // �I�������ړ��}�X��𓮂���
            else if (hitInfo.collider.tag == "tile")
            {
                HitTile = true;
                if (hitInfo.collider.CompareTag("tile"))
                {
                    tilePosition = hitInfo.collider.transform.position;
                    float moveX = (int)tilePosition.x;
                    moveX = Mathf.Clamp(moveX, -2, 2);
                    float moveZ = (int)tilePosition.z;

                    tilePosition = new Vector3(moveX, objPositionY, moveZ);

                    // �ړ��}�X�̈ʒu�ɓ������A�}�X�͍폜����

                    gameObject.transform.position = tilePosition;
                    Destroy(hitInfo.collider.gameObject);
                    PlayeraudioSource.PlayOneShot(komaSE);


                    if (KSpecial == true)
                    {
                        SelectButton.SetActive(false);
                        if (SpecialCount > 0)
                        {
                            switch (status)
                            {
                                case "Hu": HuSkill(); break;
                                case "Keima": KeimaSkill(); break;
                                case "Kyosya": KyosyaSkill(); break;
                                case "Kin": KinSkill(); break;
                                case "Gin": GinSkill(); break;
                                case "Kaku": KakuSkill(); break;
                                case "Hisya": HisyaSkill(); break;
                                case "Osyo": OsyoSkill(); break;
                            }
                            SpecialCount--;
                            //Debug.Log("SkillOn");
                        }
                        else
                        {
                            KSpecial = false;
                            SelectButton.SetActive(true);
                            //Debug.Log("SkillOff");
                        }
                    }
                    else
                    {
                        SelectButton.SetActive(true);
                    }

                    KomaStatus();
                    Debug.Log("�ړ����܂���");
                    turn++;
                    IsPlayerTurn = false;
                }


                //�@Ray���G�ɓ���������|��
                foreach (RaycastHit hit in Physics.RaycastAll(ray1))
                {
                    if (hit.collider.CompareTag("Enemy") && HitTile == true)
                    {
                        string Enemystatus = hit.collider.gameObject.GetComponent<EnemyController>().status;
                        switch (Enemystatus)
                        {
                            case "hu": HuSpecial++; break;
                            case "keima": KeimaSpecial++; break;
                            case "kyosya": KyosyaSpecial++; break;
                            case "kin": KinSpecial++; break;
                            case "gin": GinSpecial++; break;
                            case "kaku": KakuSpecial++; break;
                            case "hisya": HisyaSpecial++; break;
                            case "osyo": OsyoSpecial++; break;
                        }

                        Destroy(hit.collider.gameObject);
                        Destroy(hit.collider.gameObject.GetComponent<EnemyController>());
                        //Debug.Log("�G��|���܂���");
                        KillCount++;

                        //�G�̋�̃X�e�[�^�X�ɍ��킹�Ď�����J�E���g�𑝂₷

                        if (status == "Hu")
                        {
                            MotigomaCount += 20;
                        }
                        else if (status == "Keima")
                        {
                            MotigomaCount += 10;
                        }
                        else if (status == "Kyosya" || status == "Kin" || status == "Gin")
                        {
                            MotigomaCount += 2;
                        }
                        else
                        {
                            MotigomaCount++;
                        }
                        PlayeraudioSource.PlayOneShot(killSE);
                    }
                }
            }
        }
    }


    //---- �G�̋�̈ړ��֐� ----------------------------------------------------//

    void EnemyMover()
    {
        GameObject[] gameobjectTag = GameObject.FindGameObjectsWithTag("Enemy");
        //�G�����Ȃ��ꍇ
        if (gameobjectTag == null)
        {
            return;
        }
        else
        {
            //�G�̃R���|�[�l���g���擾���ē��상�\�b�h�����s
            foreach (GameObject enemy in gameobjectTag)
            {
                EnemyController enemyGo = enemy.GetComponent<EnemyController>();
                enemyGo.EnemyMoveMode();
            }
        }
    }


    //---- �G�Ƃ̓����蔻�� ----------------------------------------------------//

    void OnCollisionEnter(Collision collision)
    {
        if (IsPlayerTurn)
        {
            //�G�ɓ��������烉�C�t�����炷
            if (collision.gameObject.tag == "Enemy")
            {
                Destroy(collision.gameObject);
                if (life >= 1)
                {
                    PlayeraudioSource.PlayOneShot(DamageSE);
                    life--;
                }
            }
        }
    }

    //---- ��ύX�̃��j���[�\����\�� ------------------------------------------//

    public void MenuMode()
    {
        inMenu = !inMenu;
        if (inMenu == true) SelectMenue.SetActive(true);
        if (inMenu == false) SelectMenue.SetActive(false);
        PlayeraudioSource.PlayOneShot(clickSE);
    }


    //---- �v���C���[�̋��Ԃ��Ǘ�����֐� -----------------------------------//

    public void KomaStatus()
    {
        switch (status)
        {
            case "Hu": HuMove(); break;
            case "Keima": KeimaMove(); break;
            case "Kyosya": KyosyaMove(); break;
            case "Kin": KinMove(); break;
            case "Gin": GinMove(); break;
            case "Kaku": KakuMove(); break;
            case "Hisya": HisyaMove(); break;
            case "Osyo": OsyoMove(); break;
        }
    }

    //---- ��̃X�L���g�p�\�J�E���g���Ǘ�����֐� ---------------------------//

    public void UseHuSpecial()
    {
        KSpecial = true;
        SpecialCount = 3;
    }

    public void UseKeimaSpecial()
    {
        KSpecial = true;
        SpecialCount = 5;
    }

    public void UseKyosyaSpecial()
    {
        KSpecial = true;
        SpecialCount = 9;
    }

    public void UseKinSpecial()
    {
        KSpecial = true;
        SpecialCount = 5;
    }
    public void UseGinSpecial()
    {
        KSpecial = true;
        SpecialCount = 5;
    }

    public void UseKakuSpecial()
    {
        KSpecial = true;
        SpecialCount = 4;
    }

    public void UseHisyaSpecial()
    {
        KSpecial = true;
        SpecialCount = 4;
    }

    public void UseOsyoSpecial()
    {
        KSpecial = true;
        SpecialCount = 1;
    }

    //---- ��̃X�L���U�������֐� ------------------------------------------//

    void HuSkill()
    {
        int[] RandomStatus = { 0, 1, 2, 3 };
        int index = Random.Range(0, RandomStatus.Length);
        int randomstatusNumber;
        randomstatusNumber = RandomStatus[index];
        switch (randomstatusNumber)
        {
            case 0: status = "Kin"; KinMove(); break;
            case 1: status = "Gin"; GinMove(); break;
            case 2: status = "Kaku"; KakuMove(); break;
            case 3: status = "Hisya"; HisyaMove(); break;
        }
    }

    void KeimaSkill()
    {
        GameObject SkillAttack = (GameObject)Instantiate(SquareSkillAttack, keimaSkillPosition(), Quaternion.identity);
        SkillAttack.transform.parent = this.gameObject.transform;
        PlayeraudioSource.PlayOneShot(keimaSkillSE);
    }

    void KyosyaSkill()
    {
        GameObject SkillAttack = (GameObject)Instantiate(RectangleSkillAttack, kyosyaSkillPosition(1), Quaternion.identity);
        SkillAttack.transform.parent = this.gameObject.transform;
        PlayeraudioSource.PlayOneShot(kyosyaSkillSE);
    }
    void KinSkill()
    {
        for (int i = 0; i < 4; i++)
        {
            int PosZ = 2;
            GameObject SkillAttack = (GameObject)Instantiate(RectangleSkillAttack, kyosyaSkillPosition(PosZ * i), Quaternion.identity);
            SkillAttack.transform.parent = this.gameObject.transform;
        }
        PlayeraudioSource.PlayOneShot(kyosyaSkillSE);
    }
    void GinSkill()
    {
        for (int i = 1; i < 4; i++)
        {
            int PosZ = 2;
            GameObject SkillAttack = (GameObject)Instantiate(RectangleSkillAttack, kyosyaSkillPosition(PosZ * i - 1), Quaternion.identity);
            SkillAttack.transform.parent = this.gameObject.transform;
        }
        PlayeraudioSource.PlayOneShot(kyosyaSkillSE);
    }

    void HisyaSkill()
    {
        for (int i = 1; i < 7; i++)
        {
            GameObject SkillAttack = (GameObject)Instantiate(RectangleSkillAttack, kyosyaSkillPosition(i), Quaternion.identity);
            SkillAttack.transform.parent = this.gameObject.transform;
        }
        PlayeraudioSource.PlayOneShot(kyosyaSkillSE);
    }
    void KakuSkill()
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject SkillAttack = (GameObject)Instantiate(SquareSkillAttack, KakuSkillPosition(i), Quaternion.identity);
            SkillAttack.transform.parent = this.gameObject.transform;
        }
        PlayeraudioSource.PlayOneShot(keimaSkillSE);
    }
    void OsyoSkill()
    {
        PlayeraudioSource.PlayOneShot(osyoStartSE);
        StartCoroutine("OsyoSkillMove");
    }

    Vector3 kyosyaSkillPosition(int i)
    {
        return new Vector3(transform.position.x + 10, transform.position.y, transform.position.z + i);
    }

    Vector3 keimaSkillPosition()
    {
        return new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
    }

    Vector3 KakuSkillPosition(int i)
    {
        int posX = (int)Mathf.Pow(-1, i);
        return new Vector3(posX, transform.position.y + 3, transform.position.z + 1 + 2 * i);
    }

    Vector3 OsyoSkillPosition()
    {
        return new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
    }


    IEnumerator OsyoSkillMove()
    {
        GameObject SkillAttack = (GameObject)Instantiate(RectangleOsyoSkillAttack, OsyoSkillPosition(), Quaternion.identity);
        SkillAttack.transform.parent = this.gameObject.transform;
        float posZ = transform.position.z;
        while (transform.position.z < posZ + (int)50)
        {
            PlayeraudioSource.PlayOneShot(OsyoSkillSE);
            turn++;
            //�Â��^�C�����폜
            GameObject[] objects = GameObject.FindGameObjectsWithTag("tile");
            foreach (GameObject tiledestroy in objects)
            {
                Destroy(tiledestroy);
            }
            transform.Translate(0, 0, (int)1);
            yield return new WaitForSeconds(0.1f);
        }
        PlayeraudioSource.Stop();
        Destroy(SkillAttack);
        OsyoMove();
    }


    //---- �e��Ƃ̈ړ��}�X�����֐� -----------------------------------//

    public void HuMove()
    {
        status = "Hu";
        StartCoroutine("HuTileCreate");
    }
    IEnumerator HuTileCreate()
    {
        //�Â��^�C�����폜
        GameObject[] objects = GameObject.FindGameObjectsWithTag("tile");
        foreach (GameObject tiledestroy in objects)
        {
            Destroy(tiledestroy);
        }

        //1�t���[����~
        yield return null;

        //�^�C���𐶐�
        Instantiate(tileHighlight, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), tileHighlight.transform.rotation);

    }


    public void KinMove()
    {
        status = "Kin";
        StartCoroutine("KinTileCreate");
    }
    IEnumerator KinTileCreate()
    {
        //�Â��^�C�����폜
        GameObject[] objects = GameObject.FindGameObjectsWithTag("tile");
        foreach (GameObject tiledestroy in objects)
        {
            Destroy(tiledestroy);
        }

        //1�t���[����~
        yield return null;

        //�^�C���𐶐�
        if (transform.position.x >= -1 && transform.position.x <= 1)
        {
            for (int i = 0; i < 2; i++)
            {
                Instantiate(tileHighlight, new Vector3(transform.position.x - 1, transform.position.y, transform.position.z + i), tileHighlight.transform.rotation);
                Instantiate(tileHighlight, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z + i), tileHighlight.transform.rotation);
            }
        }
        else if (transform.position.x <= -2)
        {
            for (int i = 0; i < 2; i++)
                Instantiate(tileHighlight, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z + i), tileHighlight.transform.rotation);
        }
        else
        {
            for (int i = 0; i < 2; i++)
                Instantiate(tileHighlight, new Vector3(transform.position.x - 1, transform.position.y, transform.position.z + i), tileHighlight.transform.rotation);
        }
        Instantiate(tileHighlight, new Vector3(transform.position.x, transform.position.y, transform.position.z - 1), tileHighlight.transform.rotation);
        Instantiate(tileHighlight, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), tileHighlight.transform.rotation);

    }


    public void GinMove()
    {
        status = "Gin";
        StartCoroutine("GinTileCreate");
    }
    IEnumerator GinTileCreate()
    {
        //�Â��^�C�����폜
        GameObject[] objects = GameObject.FindGameObjectsWithTag("tile");
        foreach (GameObject tiledestroy in objects)
        {
            Destroy(tiledestroy);
        }

        //1�t���[����~
        yield return null;

        //�^�C���𐶐�
        if (transform.position.x >= -1 && transform.position.x <= 1)
        {
            for (int i = -1; i < 2; i++)
                Instantiate(tileHighlight, new Vector3(transform.position.x + i, transform.position.y, transform.position.z + 1), tileHighlight.transform.rotation);
            Instantiate(tileHighlight, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z - 1), tileHighlight.transform.rotation);
            Instantiate(tileHighlight, new Vector3(transform.position.x - 1, transform.position.y, transform.position.z - 1), tileHighlight.transform.rotation);
        }
        else if (transform.position.x <= -2)
        {
            for (int i = 0; i < 2; i++)
                Instantiate(tileHighlight, new Vector3(transform.position.x + i, transform.position.y, transform.position.z + 1), tileHighlight.transform.rotation);
            Instantiate(tileHighlight, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z - 1), tileHighlight.transform.rotation);
        }
        else
        {
            for (int i = -1; i < 1; i++)
                Instantiate(tileHighlight, new Vector3(transform.position.x + i, transform.position.y, transform.position.z + 1), tileHighlight.transform.rotation);
            Instantiate(tileHighlight, new Vector3(transform.position.x - 1, transform.position.y, transform.position.z - 1), tileHighlight.transform.rotation);
        }

    }


    public void KeimaMove()
    {
        status = "Keima";
        StartCoroutine("KeimaTileCreate");
    }
    IEnumerator KeimaTileCreate()
    {
        //�Â��^�C�����폜
        GameObject[] objects = GameObject.FindGameObjectsWithTag("tile");
        foreach (GameObject tiledestroy in objects)
        {
            Destroy(tiledestroy);
        }

        //1�t���[����~
        yield return null;

        //�^�C���𐶐�
        if (transform.position.x >= -1 && transform.position.x <= 1)
        {
            Instantiate(tileHighlight, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z + 2), tileHighlight.transform.rotation);
            Instantiate(tileHighlight, new Vector3(transform.position.x - 1, transform.position.y, transform.position.z + 2), tileHighlight.transform.rotation);
        }
        else if (transform.position.x <= -2)
        {
            Instantiate(tileHighlight, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z + 2), tileHighlight.transform.rotation);
        }
        else
        {
            Instantiate(tileHighlight, new Vector3(transform.position.x - 1, transform.position.y, transform.position.z + 2), tileHighlight.transform.rotation);
        }

    }


    public void KyosyaMove()
    {
        status = "Kyosya";
        StartCoroutine("KyosyaTileCreate");
    }
    IEnumerator KyosyaTileCreate()
    {
        //�Â��^�C�����폜
        GameObject[] objects = GameObject.FindGameObjectsWithTag("tile");
        foreach (GameObject tiledestroy in objects)
        {
            Destroy(tiledestroy);
        }

        //1�t���[����~
        yield return null;

        //�^�C���𐶐�
        for (int i = 1; i < 5; i++)
            Instantiate(tileHighlight, new Vector3(transform.position.x, transform.position.y, transform.position.z + i), tileHighlight.transform.rotation);

    }


    public void KakuMove()
    {
        status = "Kaku";
        StartCoroutine("KakuTileCreate");
    }
    IEnumerator KakuTileCreate()
    {
        //�Â��^�C�����폜
        GameObject[] objects = GameObject.FindGameObjectsWithTag("tile");
        foreach (GameObject tiledestroy in objects)
        {
            Destroy(tiledestroy);
        }

        //1�t���[����~
        yield return null;

        //�^�C���𐶐�
        if (transform.position.x > -1 && transform.position.x < 1)
        {
            for (int i = 1; i < 3; i++)
            {
                Instantiate(tileHighlight, new Vector3(transform.position.x + i, transform.position.y, transform.position.z + i), tileHighlight.transform.rotation);
                Instantiate(tileHighlight, new Vector3(transform.position.x - i, transform.position.y, transform.position.z + i), tileHighlight.transform.rotation);
                Instantiate(tileHighlight, new Vector3(transform.position.x + i, transform.position.y, transform.position.z - i), tileHighlight.transform.rotation);
                Instantiate(tileHighlight, new Vector3(transform.position.x - i, transform.position.y, transform.position.z - i), tileHighlight.transform.rotation);
            }
        }
        else if (transform.position.x >= 2)
        {
            for (int i = 1; i < 5; i++)
            {
                Instantiate(tileHighlight, new Vector3(transform.position.x - i, transform.position.y, transform.position.z + i), tileHighlight.transform.rotation);
                Instantiate(tileHighlight, new Vector3(transform.position.x - i, transform.position.y, transform.position.z - i), tileHighlight.transform.rotation);
            }
        }
        else if (transform.position.x <= -2)
        {
            for (int i = 1; i < 5; i++)
            {
                Instantiate(tileHighlight, new Vector3(transform.position.x + i, transform.position.y, transform.position.z + i), tileHighlight.transform.rotation);
                Instantiate(tileHighlight, new Vector3(transform.position.x + i, transform.position.y, transform.position.z - i), tileHighlight.transform.rotation);
            }
        }
        else if (transform.position.x >= 1 && transform.position.x < 2)
        {
            for (int i = 1; i < 4; i++)
            {
                Instantiate(tileHighlight, new Vector3(transform.position.x - i, transform.position.y, transform.position.z + i), tileHighlight.transform.rotation);
                Instantiate(tileHighlight, new Vector3(transform.position.x - i, transform.position.y, transform.position.z - i), tileHighlight.transform.rotation);
            }
            Instantiate(tileHighlight, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z + 1), tileHighlight.transform.rotation);
            Instantiate(tileHighlight, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z - 1), tileHighlight.transform.rotation);
        }
        else if (transform.position.x <= -1 && transform.position.x > -2)
        {
            for (int i = 1; i < 4; i++)
            {
                Instantiate(tileHighlight, new Vector3(transform.position.x + i, transform.position.y, transform.position.z + i), tileHighlight.transform.rotation);
                Instantiate(tileHighlight, new Vector3(transform.position.x + i, transform.position.y, transform.position.z - i), tileHighlight.transform.rotation);
            }
            Instantiate(tileHighlight, new Vector3(transform.position.x - 1, transform.position.y, transform.position.z + 1), tileHighlight.transform.rotation);
            Instantiate(tileHighlight, new Vector3(transform.position.x - 1, transform.position.y, transform.position.z - 1), tileHighlight.transform.rotation);
        }

    }


    public void HisyaMove()
    {
        status = "Hisya";
        StartCoroutine("HisyaTileCreate");
    }
    IEnumerator HisyaTileCreate()
    {
        //�Â��^�C�����폜
        GameObject[] objects = GameObject.FindGameObjectsWithTag("tile");
        foreach (GameObject tiledestroy in objects)
        {
            Destroy(tiledestroy);
        }

        //1�t���[����~
        yield return null;

        //�^�C���𐶐�
        if (transform.position.x > -1 && transform.position.x < 1)
        {
            for (int i = 1; i < 3; i++)
            {
                Instantiate(tileHighlight, new Vector3(transform.position.x + i, transform.position.y, transform.position.z), tileHighlight.transform.rotation);
                Instantiate(tileHighlight, new Vector3(transform.position.x - i, transform.position.y, transform.position.z), tileHighlight.transform.rotation);
            }
        }
        else if (transform.position.x >= 2)
        {
            for (int i = 1; i < 5; i++)
                Instantiate(tileHighlight, new Vector3(transform.position.x - i, transform.position.y, transform.position.z), tileHighlight.transform.rotation);
        }
        else if (transform.position.x <= -2)
        {
            for (int i = 1; i < 5; i++)
                Instantiate(tileHighlight, new Vector3(transform.position.x + i, transform.position.y, transform.position.z), tileHighlight.transform.rotation);
        }
        else if (transform.position.x >= 1 && transform.position.x < 2)
        {
            for (int i = 1; i < 4; i++)
                Instantiate(tileHighlight, new Vector3(transform.position.x - i, transform.position.y, transform.position.z), tileHighlight.transform.rotation);
            Instantiate(tileHighlight, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z), tileHighlight.transform.rotation);
        }
        else if (transform.position.x <= -1 && transform.position.x > -2)
        {
            for (int i = 1; i < 4; i++)

                Instantiate(tileHighlight, new Vector3(transform.position.x + i, transform.position.y, transform.position.z), tileHighlight.transform.rotation);
            Instantiate(tileHighlight, new Vector3(transform.position.x - 1, transform.position.y, transform.position.z), tileHighlight.transform.rotation);
        }
        for (int i = 1; i < 5; i++)
        {
            Instantiate(tileHighlight, new Vector3(transform.position.x, transform.position.y, transform.position.z + i), tileHighlight.transform.rotation);
            Instantiate(tileHighlight, new Vector3(transform.position.x, transform.position.y, transform.position.z - i), tileHighlight.transform.rotation);
        }
    }


    public void OsyoMove()
    {
        status = "Osyo";
        StartCoroutine("OsyoTileCreate");
    }
    IEnumerator OsyoTileCreate()
    {
        //�Â��^�C�����폜
        GameObject[] objects = GameObject.FindGameObjectsWithTag("tile");
        foreach (GameObject tiledestroy in objects)
        {
            Destroy(tiledestroy);
        }

        //1�t���[����~
        yield return null;

        //�^�C���𐶐�
        if (transform.position.x <= 1 && transform.position.x >= -1)
        {
            for (int i = -1; i < 2; i++)
            {
                Instantiate(tileHighlight, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z + i), tileHighlight.transform.rotation);
                Instantiate(tileHighlight, new Vector3(transform.position.x - 1, transform.position.y, transform.position.z + i), tileHighlight.transform.rotation);
            }
        }
        else if (transform.position.x == 2)
        {
            for (int i = -1; i < 2; i++)
                Instantiate(tileHighlight, new Vector3(transform.position.x - 1, transform.position.y, transform.position.z + i), tileHighlight.transform.rotation);
        }
        else
        {
            for (int i = -1; i < 2; i++)
                Instantiate(tileHighlight, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z + i), tileHighlight.transform.rotation);
        }
        Instantiate(tileHighlight, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), tileHighlight.transform.rotation);
        Instantiate(tileHighlight, new Vector3(transform.position.x, transform.position.y, transform.position.z - 1), tileHighlight.transform.rotation);
    }

}