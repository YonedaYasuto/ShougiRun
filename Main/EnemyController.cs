using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    // �G�̋�̃X�e�[�^�X

    string[] statusName1 = {"hu", "other1" };   
    string[] statusName2 = {"keima", "kyosya", "other2" };
    string[] statusName3 = { "kin", "gin", "kaku", "hisya", "osyo" };
    [System.NonSerialized] public string status;

    //�@��X�e�[�^�X���Ƃ̃}�e���A��
    Material[] Omotemen;
    [SerializeField] Material[] KomaState;

    //�@�ړ��̃����_����(�O���A���A���)
    int[] way2 = { 1, 2};
    int[] way3 = { 1, 2, 3 };
    int[] rndZ = { -1, 1 };

    public GameObject tileHighlight;�@//�@�G�̈ړ��}�X
    GameObject tileHighlights;      �@//�@�^�C�������p
    GameObject GameController;        //�@�Q�[���V�X�e���̃R���|�[�l���g�p


    public void Start()
    {
        //�@�G�̃}�e���A�����擾
        Omotemen = GetComponent<MeshRenderer>().materials;

        //�@�Q�[���V�X�e���̃R���|�[�l���g���擾
        GameController = GameObject.FindGameObjectWithTag("GameController");
        
        //�@3�i�K��Random.Range�œG��������_���ɐ���

        int index1 = Random.Range(0, statusName1.Length);
        status = statusName1[index1];
        if(status == "other1")
        {
            int index2 = Random.Range(0, statusName2.Length);
            status = statusName2[index2];
            if(status == "other2")
            {
                int index3 = Random.Range(0, statusName3.Length);
                status = statusName3[index3];
            }
        }

        //�@�X�e�[�^�X���ƂɁA�������ɕ\������ړ��}�X��ύX

        switch (status)
        {
            case "hu": HuTile(); break;
            case "keima": KeimaTile(); break;
            case "kyosya": KyosyaTile(); break;
            case "kin": KinTile(); break;
            case "gin": GinTile(); break;
            case "kaku": KakuTile(); break;
            case "hisya": HisyaTile(); break;
            case "osyo": OsyoTile(); break;
        }
    }

    public void Update()
    {


        //�@��̃X�e�[�^�X�ɂ���āA�\�ʂɕ\������}�e���A����ύX

        switch (status)
        {
            case "hu":
                Omotemen[1] = KomaState[0];
                GetComponent<MeshRenderer>().materials = Omotemen; break;
            case "keima":
                Omotemen[1] = KomaState[1];
                GetComponent<MeshRenderer>().materials = Omotemen; break;
            case "kyosya":
                Omotemen[1] = KomaState[2];
                GetComponent<MeshRenderer>().materials = Omotemen; break;
            case "kin":
                Omotemen[1] = KomaState[3];
                GetComponent<MeshRenderer>().materials = Omotemen; break;
            case "gin":
                Omotemen[1] = KomaState[4];
                GetComponent<MeshRenderer>().materials = Omotemen; break;
            case "kaku":
                Omotemen[1] = KomaState[5];
                GetComponent<MeshRenderer>().materials = Omotemen; break;
            case "hisya":
                Omotemen[1] = KomaState[6];
                GetComponent<MeshRenderer>().materials = Omotemen; break;
            case "osyo":
                Omotemen[1] = KomaState[7];
                GetComponent<MeshRenderer>().materials = Omotemen; break;
        }

        //�@�v���C���[��ʂ�߂����G����������

        GameObject Player = GameObject.FindWithTag("Player");
        if (Player == null) return;
        else
        {
            if (Player.transform.position.z - transform.position.z >= 6)
            {
                //�|���ꂽ����Ƃ��ăX�R�A�ɉ��Z����Ȃ��悤�ɁA�X�e�[�^�X�ύX
                status = "Ohter";
                Destroy(gameObject);
            }
        }
    }

    void OnCollisionEnter(Collision collision)�@ //�G���m���d�Ȃ�����폜
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
    }

    public UnityEvent OnDestroyed = new UnityEvent();
    private void OnDestroy()    //�e�X�e�[�^�X���Ƃ́A�|���ꂽ�Ƃ��̃X�y�V�����Q�[�W���Z
    {
        if (GameController == null) return;
        else
        {
            switch (status)
            {
                case "hu": GameController.GetComponent<GameController>().NariHu++; break;
                case "keima": GameController.GetComponent<GameController>().NariKei++; break;
                case "kyosya": GameController.GetComponent<GameController>().NariKyou++; break;
                case "kin": GameController.GetComponent<GameController>().NariKin++; break;
                case "gin": GameController.GetComponent<GameController>().NariGin++; break;
                case "kaku": GameController.GetComponent<GameController>().Ryuma++; break;
                case "hisya": GameController.GetComponent<GameController>().Ryuou++; break;
                case "osyo": GameController.GetComponent<GameController>().NariOu++; break;
                case "Ohter": break;
            }
        }
        OnDestroyed.Invoke();
    }

    public void EnemyMoveMode()   //�X�e�[�^�X���Ƃ̈ړ����@
    {
        switch (status)
        {
            case "hu": HuMove(); break;
            case "keima": KeimaMove(); break;
            case "kyosya": KyosyaMove(); break;
            case "kin": KinMove(); break;
            case "gin": GinMove(); break;
            case "kaku": KakuMove(); break;
            case "hisya": HisyaMove(); break;
            case "osyo": OsyoMove(); break;
        }
    }

    public void HuMove()
    {
        StartCoroutine("HuEnemyMove");
    }

    public void KinMove()
    {
        StartCoroutine("KinEnemyMove");
    }

    public void GinMove()
    {
        StartCoroutine("GinEnemyMove");
    }

    public void KeimaMove()
    {
        StartCoroutine("KeimaEnemyMove");
    }

    public void KyosyaMove()
    {
        StartCoroutine("KyosyaEnemyMove");
    }

    public void KakuMove()
    {
        StartCoroutine("KakuEnemyMove");
    }

    public void HisyaMove()
    {
        StartCoroutine("HisyaEnemyMove");
    }

    public void OsyoMove()
    {
        StartCoroutine("OsyoEnemyMove");
    }

    IEnumerator HuEnemyMove()
    {
        Vector3 Pos = new Vector3();
        Pos = transform.position;
        Pos.z = transform.position.z - 1;
        transform.position = Pos;

        //�Â��^�C�����폜
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Enemytile");
        foreach (GameObject tiledestroy in objects)
        {
            Destroy(tiledestroy);
        }
        //1�t���[����~
        yield return null;
        //�^�C���𐶐�
        HuTile();
    }

    IEnumerator KeimaEnemyMove()
    {
        //�Â��^�C�����폜
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Enemytile");
        foreach (GameObject tiledestroy in objects)
        {
            Destroy(tiledestroy);
        }
        //1�t���[����~
        yield return null;

        Vector3 Pos = new Vector3();
        Pos = transform.position;
        int indexA = Random.Range(0, 2);

        if (transform.position.x >= -1 && transform.position.x <= 1)
        {
            int wayX = way2[indexA];
            if(wayX == 1)
            {
                Pos.x = transform.position.x - 1;
                Pos.z = transform.position.z - 2;
            }
            else if(wayX == 2)
            {
                Pos.x = transform.position.x + 1;
                Pos.z = transform.position.z - 2;
            }
        }
        else if (transform.position.x <= -2)
        {
            Pos.x = transform.position.x + 1;
            Pos.z = transform.position.z - 2;
        }
        else
        {
            Pos.x = transform.position.x - 1;
            Pos.z = transform.position.z - 2;
        }
        transform.position = Pos;
        //�^�C���𐶐�
        KeimaTile();
    }

    IEnumerator KyosyaEnemyMove()
    {
        Vector3 Pos = new Vector3();
        Pos = transform.position;
        int indexB = Random.Range(1, 5);
        transform.position = Pos;
        Pos.z = transform.position.z - indexB;

        //�Â��^�C�����폜
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Enemytile");
        foreach (GameObject tiledestroy in objects)
        {
            Destroy(tiledestroy);
        }
        //1�t���[����~
        yield return null;

        transform.position = Pos;
        //�^�C���𐶐�
        KyosyaTile();

    }

    IEnumerator KinEnemyMove()
    {
        //�Â��^�C�����폜
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Enemytile");
        foreach (GameObject tiledestroy in objects)
        {
            Destroy(tiledestroy);
        }
        //1�t���[����~
        yield return null;

        Vector3 Pos = new Vector3();
        Pos = transform.position;
        int indexA = Random.Range(0, 2);
        int indexB = Random.Range(0, 3);

        if (transform.position.x >= -1 && transform.position.x <= 1)
        {
            int wayZ = way3[indexB];
            if(wayZ == 1)
            {
                Pos.z = transform.position.z + 1;
            }
            else if (wayZ == 2)
            {
                int wayX = way2[indexA];
                if(wayX == 1)
                {
                    Pos.x = transform.position.x - 1;
                }
                else
                {
                    Pos.x = transform.position.x + 1;
                }
            }
            else
            {
                int indexX = Random.Range(-1, 2);
                Pos.x = transform.position.x + indexX;
                Pos.z = transform.position.z - 1;
            }
        }
        else if (transform.position.x <= -2)
        {
            int wayZ = way3[indexB];
            if (wayZ == 1)
            {
                Pos.z = transform.position.z + 1;
            }
            else if (wayZ == 2)
            {
                Pos.x = transform.position.x + 1;
            }
            else
            {
                int indexX = Random.Range(0, 2);
                Pos.x = transform.position.x + indexX;
                Pos.z = transform.position.z - 1;
            }
        }
        else
        {
            int wayZ = way3[indexB];
            if (wayZ == 1)
            {
                Pos.z = transform.position.z + 1;
            }
            else if (wayZ == 2)
            {
                Pos.x = transform.position.x - 1;
            }
            else
            {
                int indexX = Random.Range(-1, 1);
                Pos.x = transform.position.x + indexX;
                Pos.z = transform.position.z - 1;
            }
        }
        transform.position = Pos;
        KinTile();
    }

    IEnumerator GinEnemyMove()
    {
        //�Â��^�C�����폜
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Enemytile");
        foreach (GameObject tiledestroy in objects)
        {
            Destroy(tiledestroy);
        }
        //1�t���[����~
        yield return null;

        Vector3 Pos = new Vector3();
        Pos = transform.position;
        int indexA = Random.Range(0, 2);
        int indexB = Random.Range(0, 3);

        if (transform.position.x >= -1 && transform.position.x <= 1)
        {
            int wayZ = way2[indexA];
            if (wayZ == 1)
            {
                Pos.z = transform.position.z + 1;

                int wayX = way2[indexA];
                if (wayX == 1)
                {
                    Pos.x = transform.position.x - 1;
                }
                else
                {
                    Pos.x = transform.position.x + 1;
                }
            }
            else
            {
                int indexX = Random.Range(-1, 2);
                Pos.x = transform.position.x + indexX;
                Pos.z = transform.position.z - 1;
            }
        }
        else if (transform.position.x <= -2)
        {
            int wayZ = way2[indexA];
            if (wayZ == 1)
            {
                Pos.x = transform.position.x + 1;
                Pos.z = transform.position.z + 1;
            }
            else
            {
                int indexX = Random.Range(0, 2);
                Pos.x = transform.position.x + indexX;
                Pos.z = transform.position.z - 1;
            }
        }
        else
        {
            int wayZ = way2[indexA];
            if (wayZ == 1)
            {
                Pos.x = transform.position.x - 1;
                Pos.z = transform.position.z + 1;
            }
            else
            {
                int indexX = Random.Range(-1, 1);
                Pos.x = transform.position.x + indexX;
                Pos.z = transform.position.z - 1;
            }
        }
        transform.position = Pos;
        GinTile();
    }

    IEnumerator KakuEnemyMove()
    {
 
            //�Â��^�C�����폜
            GameObject[] Enemyobjects = GameObject.FindGameObjectsWithTag("Enemytile");
            foreach (GameObject tiledestroy in Enemyobjects)
            {
                Destroy(tiledestroy);
            }

            //1�t���[����~
            yield return null;

            Vector3 Pos = new Vector3();
            Pos = transform.position;
            int indexZ = Random.Range(0, 2);
            int indexX = Random.Range(0, 4);

            if (transform.position.x > -1 && transform.position.x < 1)
            {
                int[] rndX = { 1, 2, -1, -2 };
                Pos.x = transform.position.x + rndX[indexX];
                Pos.z = transform.position.z + (rndX[indexX] * rndZ[indexZ]);
            }
            else if (transform.position.x >= 2)
            {
                int[] rndX = { -1, -2, -3, -4 };
                Pos.x = transform.position.x + rndX[indexX];
                Pos.z = transform.position.z + (rndX[indexX] * rndZ[indexZ]);
            }
            else if (transform.position.x <= -2)
            {
                int[] rndX = { 1, 2, 3, 4 };
                Pos.x = transform.position.x + rndX[indexX];
                Pos.z = transform.position.z + (rndX[indexX] * rndZ[indexZ]);
            }
            else if (transform.position.x >= 1 && transform.position.x < 2)
            {
                int[] rndX = { -1, -2, -3, 1 };
                Pos.x = transform.position.x + rndX[indexX];
                Pos.z = transform.position.z + (rndX[indexX] * rndZ[indexZ]);
                 
            }
            else if (transform.position.x <= -1 && transform.position.x > -2)
            {
                int[] rndX = { 1, 2, 3, -1 };
                Pos.x = transform.position.x + rndX[indexX];
                Pos.z = transform.position.z + (rndX[indexX] * rndZ[indexZ]);
            }
        transform.position = Pos;
        KakuTile();
    }

    IEnumerator HisyaEnemyMove()
    {
        //�Â��^�C�����폜
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Enemytile");
        foreach (GameObject tiledestroy in objects)
        {
            Destroy(tiledestroy);
        }
        //1�t���[����~
        yield return null;

        Vector3 Pos = new Vector3();
        Pos = transform.position;
        int indexA = Random.Range(0, 2);
        int indexB = Random.Range(0, 2);

        int way = way2[indexA];
        if (way == 1)
        {
            int wayZ = way2[indexB];
            if(wayZ == 1)
            {
                int LengthZ = Random.Range(1, 3);
                Pos.z = transform.position.z + LengthZ;
            }
            if (wayZ == 2)
            {
                int LengthZ = Random.Range(1, 5);
                Pos.z = transform.position.z - LengthZ;
            }
        }
        else
        {
            if (transform.position.x <= -2)
            {
                int LengthX = Random.Range(1, 5);
                Pos.x = transform.position.x + LengthX;
            }
            else if(transform.position.x > -2 && transform.position.x <= -1)
            {
                int wayX = way2[indexB];
                if(wayX == 1)
                {
                    Pos.x = transform.position.x - 1;
                }
                else
                {
                    int LengthX = Random.Range(1, 4);
                    Pos.x = transform.position.x + LengthX;
                }
            }
            else if (transform.position.x > -1 && transform.position.x < 1)
            {
                int wayX = way2[indexB];
                int LengthX = Random.Range(0, 3);
                if (wayX == 1)
                {
                    Pos.x = transform.position.x - LengthX;
                }
                else
                {
                    Pos.x = transform.position.x + LengthX;
                }
            }
            else if (transform.position.x >= 1 && transform.position.x < 2)
            {
                int wayX = way2[indexB];
                if (wayX == 1)
                {
                    Pos.x = transform.position.x + 1;
                }
                else
                {
                    int LengthX = Random.Range(0, 4);
                    Pos.x = transform.position.x - LengthX;
                }
            }
            else
            {
                int LengthX = Random.Range(1, 5);
                Pos.x = transform.position.x - LengthX;
            }
            transform.position = Pos;
            HisyaTile();
        }
        transform.position = Pos;
        //�^�C���𐶐�
        HisyaTile();
    }

    IEnumerator OsyoEnemyMove()
    {
        //�Â��^�C�����폜
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Enemytile");
        foreach (GameObject tiledestroy in objects)
        {
            Destroy(tiledestroy);
        }
        //1�t���[����~
        yield return null;

        Vector3 Pos = new Vector3();
        Pos = transform.position;
        int indexA = Random.Range(0, 2);
        int indexB = Random.Range(0, 3);

        if (transform.position.x >= -1 && transform.position.x <= 1)
        {
            int indexX = Random.Range(-1, 2);
            int wayZ = way3[indexB];
            if (wayZ == 1)
            {
                Pos.x = transform.position.x + indexX;
                Pos.z = transform.position.z + 1;
            }
            else if (wayZ == 2)
            {
                int wayX = way2[indexA];
                if (wayX == 1)
                {
                    Pos.x = transform.position.x - 1;
                }
                else
                {
                    Pos.x = transform.position.x + 1;
                }
            }
            else
            {
                Pos.x = transform.position.x + indexX;
                Pos.z = transform.position.z - 1;
            }
        }
        else if (transform.position.x <= -2)
        {
            int indexX = Random.Range(0, 2);
            int wayZ = way3[indexB];
            if (wayZ == 1)
            {
                Pos.x = transform.position.x + indexX;
                Pos.z = transform.position.z + 1;
            }
            else if (wayZ == 2)
            {
                Pos.x = transform.position.x + 1;
            }
            else
            {
                Pos.x = transform.position.x + indexX;
                Pos.z = transform.position.z - 1;
            }
        }
        else
        {
            int indexX = Random.Range(0, 2);
            int wayZ = way3[indexB];
            if (wayZ == 1)
            {
                Pos.x = transform.position.x - indexX;
                Pos.z = transform.position.z + 1;
            }
            else if (wayZ == 2)
            {
                Pos.x = transform.position.x - 1;
            }
            else
            {
                Pos.x = transform.position.x - indexX;
                Pos.z = transform.position.z - 1;
            }
        }
        transform.position = Pos;
        OsyoTile();
    }

    void HuTile()  �@ //���p�^�C���𐶐�
    {
        tileHighlights = (GameObject)Instantiate(tileHighlight, new Vector3(transform.position.x, transform.position.y, transform.position.z - 1), tileHighlight.transform.rotation);
        tileHighlights.transform.parent = this.gameObject.transform;
    }

    void KeimaTile()�@//�j�n�p�^�C���𐶐�
    {
        if (transform.position.x >= -1 && transform.position.x <= 1)
        {
            tileHighlights = (GameObject)Instantiate(tileHighlight, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z - 2), tileHighlight.transform.rotation);
            tileHighlights.transform.parent = this.gameObject.transform;
            tileHighlights = (GameObject)Instantiate(tileHighlight, new Vector3(transform.position.x - 1, transform.position.y, transform.position.z - 2), tileHighlight.transform.rotation);
            tileHighlights.transform.parent = this.gameObject.transform;
        }
        else if (transform.position.x <= -2)
        {
            tileHighlights = (GameObject)Instantiate(tileHighlight, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z - 2), tileHighlight.transform.rotation);
            tileHighlights.transform.parent = this.gameObject.transform;
        }
        else
        {
            tileHighlights = (GameObject)Instantiate(tileHighlight, new Vector3(transform.position.x - 1, transform.position.y, transform.position.z - 2), tileHighlight.transform.rotation);
            tileHighlights.transform.parent = this.gameObject.transform;
        }
    }

    void KyosyaTile() //���ԗp�^�C���𐶐�
    {
        for (int i = 1; i < 5; i++)
        {
            tileHighlights = (GameObject)Instantiate(tileHighlight, new Vector3(transform.position.x, transform.position.y, transform.position.z - i), tileHighlight.transform.rotation);
            tileHighlights.transform.parent = this.gameObject.transform;
        }
    }

    void KinTile()�@�@//���p�^�C���𐶐�
    {
        if (transform.position.x >= -1 && transform.position.x <= 1)
        {
            for (int i = 0; i < 2; i++)
            {
                tileHighlights = (GameObject)Instantiate(tileHighlight, new Vector3(transform.position.x - 1, transform.position.y, transform.position.z - i), tileHighlight.transform.rotation);
                tileHighlights.transform.parent = this.gameObject.transform;
                tileHighlights = (GameObject)Instantiate(tileHighlight, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z - i), tileHighlight.transform.rotation);
                tileHighlights.transform.parent = this.gameObject.transform;
            }
        }
        else if (transform.position.x <= -2)
        {
            for (int i = 0; i < 2; i++)
            {
                tileHighlights = (GameObject)Instantiate(tileHighlight, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z - i), tileHighlight.transform.rotation);
                tileHighlights.transform.parent = this.gameObject.transform;
            }
        }
        else
        {
            for (int i = 0; i < 2; i++)
            {
                tileHighlights = (GameObject)Instantiate(tileHighlight, new Vector3(transform.position.x - 1, transform.position.y, transform.position.z - i), tileHighlight.transform.rotation);
                tileHighlights.transform.parent = this.gameObject.transform;
            }
        }
        tileHighlights = (GameObject)Instantiate(tileHighlight, new Vector3(transform.position.x, transform.position.y, transform.position.z - 1), tileHighlight.transform.rotation);
        tileHighlights.transform.parent = this.gameObject.transform;
        tileHighlights = (GameObject)Instantiate(tileHighlight, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), tileHighlight.transform.rotation);
        tileHighlights.transform.parent = this.gameObject.transform;
    }

    void GinTile()�@�@//��p�^�C���𐶐�
    {
        if (transform.position.x >= -1 && transform.position.x <= 1)
        {
            for (int i = -1; i < 2; i++)
            {
                tileHighlights = (GameObject)Instantiate(tileHighlight, new Vector3(transform.position.x + i, transform.position.y, transform.position.z - 1), tileHighlight.transform.rotation);
                tileHighlights.transform.parent = this.gameObject.transform;
            }

            tileHighlights = (GameObject)Instantiate(tileHighlight, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z + 1), tileHighlight.transform.rotation);
            tileHighlights.transform.parent = this.gameObject.transform;
            tileHighlights = (GameObject)Instantiate(tileHighlight, new Vector3(transform.position.x - 1, transform.position.y, transform.position.z + 1), tileHighlight.transform.rotation);
            tileHighlights.transform.parent = this.gameObject.transform;
        }
        else if (transform.position.x <= -2)
        {
            for (int i = 0; i < 2; i++)
            {
                tileHighlights = (GameObject)Instantiate(tileHighlight, new Vector3(transform.position.x + i, transform.position.y, transform.position.z - 1), tileHighlight.transform.rotation);
                tileHighlights.transform.parent = this.gameObject.transform;
            }
            tileHighlights = (GameObject)Instantiate(tileHighlight, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z + 1), tileHighlight.transform.rotation);
            tileHighlights.transform.parent = this.gameObject.transform;
        }
        else
        {
            for (int i = -1; i < 1; i++)
            {
                tileHighlights = (GameObject)Instantiate(tileHighlight, new Vector3(transform.position.x + i, transform.position.y, transform.position.z - 1), tileHighlight.transform.rotation);
                tileHighlights.transform.parent = this.gameObject.transform;
            }
            tileHighlights = (GameObject)Instantiate(tileHighlight, new Vector3(transform.position.x - 1, transform.position.y, transform.position.z + 1), tileHighlight.transform.rotation);
            tileHighlights.transform.parent = this.gameObject.transform;
        }
    }

    void KakuTile()�@ //�p�p�^�C���𐶐�
    {
        if (transform.position.x > -1 && transform.position.x < 1)
        {
            for (int i = 1; i < 3; i++)
            {
                tileHighlights = (GameObject)Instantiate(tileHighlight, new Vector3(transform.position.x + i, transform.position.y, transform.position.z + i), tileHighlight.transform.rotation);
                tileHighlights.transform.parent = this.gameObject.transform;
                tileHighlights = (GameObject)Instantiate(tileHighlight, new Vector3(transform.position.x - i, transform.position.y, transform.position.z + i), tileHighlight.transform.rotation);
                tileHighlights.transform.parent = this.gameObject.transform;
                tileHighlights = (GameObject)Instantiate(tileHighlight, new Vector3(transform.position.x + i, transform.position.y, transform.position.z - i), tileHighlight.transform.rotation);
                tileHighlights.transform.parent = this.gameObject.transform;
                tileHighlights = (GameObject)Instantiate(tileHighlight, new Vector3(transform.position.x - i, transform.position.y, transform.position.z - i), tileHighlight.transform.rotation);
                tileHighlights.transform.parent = this.gameObject.transform;
            }
        }
        else if (transform.position.x >= 2)
        {
            for (int i = 1; i < 5; i++)
            {
                tileHighlights = (GameObject)Instantiate(tileHighlight, new Vector3(transform.position.x - i, transform.position.y, transform.position.z + i), tileHighlight.transform.rotation);
                tileHighlights.transform.parent = this.gameObject.transform;
                tileHighlights = (GameObject)Instantiate(tileHighlight, new Vector3(transform.position.x - i, transform.position.y, transform.position.z - i), tileHighlight.transform.rotation);
                tileHighlights.transform.parent = this.gameObject.transform;
            }
        }
        else if (transform.position.x <= -2)
        {
            for (int i = 1; i < 5; i++)
            {
                tileHighlights = (GameObject)Instantiate(tileHighlight, new Vector3(transform.position.x + i, transform.position.y, transform.position.z + i), tileHighlight.transform.rotation);
                tileHighlights.transform.parent = this.gameObject.transform;
                tileHighlights = (GameObject)Instantiate(tileHighlight, new Vector3(transform.position.x + i, transform.position.y, transform.position.z - i), tileHighlight.transform.rotation);
                tileHighlights.transform.parent = this.gameObject.transform;
            }
        }
        else if (transform.position.x >= 1 && transform.position.x < 2)
        {
            for (int i = 1; i < 4; i++)
            {
                tileHighlights = (GameObject)Instantiate(tileHighlight, new Vector3(transform.position.x - i, transform.position.y, transform.position.z + i), tileHighlight.transform.rotation);
                tileHighlights.transform.parent = this.gameObject.transform;
                tileHighlights = (GameObject)Instantiate(tileHighlight, new Vector3(transform.position.x - i, transform.position.y, transform.position.z - i), tileHighlight.transform.rotation);
                tileHighlights.transform.parent = this.gameObject.transform;
            }
            tileHighlights = (GameObject)Instantiate(tileHighlight, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z + 1), tileHighlight.transform.rotation);
            tileHighlights.transform.parent = this.gameObject.transform;
            tileHighlights = (GameObject)Instantiate(tileHighlight, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z - 1), tileHighlight.transform.rotation);
            tileHighlights.transform.parent = this.gameObject.transform;
        }
        else if (transform.position.x <= -1 && transform.position.x > -2)
        {
            for (int i = 1; i < 4; i++)
            {
                tileHighlights = (GameObject)Instantiate(tileHighlight, new Vector3(transform.position.x + i, transform.position.y, transform.position.z + i), tileHighlight.transform.rotation);
                tileHighlights.transform.parent = this.gameObject.transform;
                tileHighlights = (GameObject)Instantiate(tileHighlight, new Vector3(transform.position.x + i, transform.position.y, transform.position.z - i), tileHighlight.transform.rotation);
                tileHighlights.transform.parent = this.gameObject.transform;
            }
            
            tileHighlights = (GameObject)Instantiate(tileHighlight, new Vector3(transform.position.x - 1, transform.position.y, transform.position.z + 1), tileHighlight.transform.rotation);
            tileHighlights.transform.parent = this.gameObject.transform;
            tileHighlights = (GameObject)Instantiate(tileHighlight, new Vector3(transform.position.x - 1, transform.position.y, transform.position.z - 1), tileHighlight.transform.rotation);
            tileHighlights.transform.parent = this.gameObject.transform;
        }
    }
    void HisyaTile()�@//��ԗp�^�C���𐶐�
    {
        if (transform.position.x > -1 && transform.position.x < 1)
        {
            for (int i = 1; i < 3; i++)
            {
                tileHighlights = (GameObject)Instantiate(tileHighlight, new Vector3(transform.position.x + i, transform.position.y, transform.position.z), tileHighlight.transform.rotation);
                tileHighlights.transform.parent = this.gameObject.transform;
                tileHighlights = (GameObject)Instantiate(tileHighlight, new Vector3(transform.position.x - i, transform.position.y, transform.position.z), tileHighlight.transform.rotation);
                tileHighlights.transform.parent = this.gameObject.transform;
            }
        }
        else if (transform.position.x >= 2)
        {
            for (int i = 1; i < 5; i++)
            {
                tileHighlights = (GameObject)Instantiate(tileHighlight, new Vector3(transform.position.x - i, transform.position.y, transform.position.z), tileHighlight.transform.rotation);
                tileHighlights.transform.parent = this.gameObject.transform;
            }
        }
        else if (transform.position.x <= -2)
        {
            for (int i = 1; i < 5; i++)
            {
                tileHighlights = (GameObject)Instantiate(tileHighlight, new Vector3(transform.position.x + i, transform.position.y, transform.position.z), tileHighlight.transform.rotation);
                tileHighlights.transform.parent = this.gameObject.transform;
            }
        }
        else if (transform.position.x >= 1 && transform.position.x < 2)
        {
            for (int i = 1; i < 4; i++)
            {
                tileHighlights = (GameObject)Instantiate(tileHighlight, new Vector3(transform.position.x - i, transform.position.y, transform.position.z), tileHighlight.transform.rotation);
                tileHighlights.transform.parent = this.gameObject.transform;
            }
            tileHighlights = (GameObject)Instantiate(tileHighlight, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z), tileHighlight.transform.rotation);
            tileHighlights.transform.parent = this.gameObject.transform;
        }
        else
        {
            for (int i = 1; i < 4; i++)
            {
                tileHighlights = (GameObject)Instantiate(tileHighlight, new Vector3(transform.position.x + i, transform.position.y, transform.position.z), tileHighlight.transform.rotation);
                tileHighlights.transform.parent = this.gameObject.transform;
            }
            tileHighlights = (GameObject)Instantiate(tileHighlight, new Vector3(transform.position.x - 1, transform.position.y, transform.position.z), tileHighlight.transform.rotation);
            tileHighlights.transform.parent = this.gameObject.transform;
        }
        for (int i = 1; i < 5; i++)
        {
            tileHighlights = (GameObject)Instantiate(tileHighlight, new Vector3(transform.position.x, transform.position.y, transform.position.z + i), tileHighlight.transform.rotation);
            tileHighlights.transform.parent = this.gameObject.transform;
            tileHighlights = (GameObject)Instantiate(tileHighlight, new Vector3(transform.position.x, transform.position.y, transform.position.z - i), tileHighlight.transform.rotation);
            tileHighlights.transform.parent = this.gameObject.transform;
        }
    }

    void OsyoTile()�@ //���p�^�C���𐶐�
    {
        if (transform.position.x <= 1 && transform.position.x >= -1)
        {
            for (int i = -1; i < 2; i++)
            {
                tileHighlights = (GameObject)Instantiate(tileHighlight, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z + i), tileHighlight.transform.rotation);
                tileHighlights.transform.parent = this.gameObject.transform;
                tileHighlights = (GameObject)Instantiate(tileHighlight, new Vector3(transform.position.x - 1, transform.position.y, transform.position.z + i), tileHighlight.transform.rotation);
                tileHighlights.transform.parent = this.gameObject.transform;
            }
        }
        else if (transform.position.x == 2)
        {
            for (int i = -1; i < 2; i++)
            {
                tileHighlights = (GameObject)Instantiate(tileHighlight, new Vector3(transform.position.x - 1, transform.position.y, transform.position.z + i), tileHighlight.transform.rotation);
                tileHighlights.transform.parent = this.gameObject.transform;
            }
        }
        else
        {
            for (int i = -1; i < 2; i++)
            {
                tileHighlights = (GameObject)Instantiate(tileHighlight, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z + i), tileHighlight.transform.rotation);
                tileHighlights.transform.parent = this.gameObject.transform;
            }
        }
        tileHighlights = (GameObject)Instantiate(tileHighlight, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), tileHighlight.transform.rotation);
        tileHighlights.transform.parent = this.gameObject.transform;
        tileHighlights = (GameObject)Instantiate(tileHighlight, new Vector3(transform.position.x, transform.position.y, transform.position.z - 1), tileHighlight.transform.rotation);
        tileHighlights.transform.parent = this.gameObject.transform;
    }

}
