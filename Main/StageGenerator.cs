using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGenerator : MonoBehaviour
{
    const int StageChipSize = 15;

    int currentChipIndex;   //現在のステージ位置

    public Transform character;      //ターゲットキャラクターの指定
    public GameObject[] stageChips;  //ステージチッププレハブ配列
    public int startChipIndex;       //自動生成開始インデックス
    public int preInstantiate;       //先読みして生成する個数
    public List<GameObject> generatedStageList = new List<GameObject>(); //生成済みステージチップ保持リスト

    // Start is called before the first frame update
    void Start()
    {
        ///初期化処理
        currentChipIndex = startChipIndex - 1;
        UpdateStage(preInstantiate);
    }

    // Update is called once per frame
    void Update()   ///ステージの更新タイミングの監視
    {
        if(character == null)
        {
            return;
        }
        //キャラクターの位置から現在のステージチップのインデックスを計算
        int charaPositionIndex = (int)(character.position.z / StageChipSize);

        //次のステージチップに入ったらステージの更新処理を行う
        if (charaPositionIndex + preInstantiate > currentChipIndex)
        {
            UpdateStage(charaPositionIndex + preInstantiate);
        }
    }

    void UpdateStage(int toChipIndex)
    {
        if (toChipIndex <= currentChipIndex) return;

        //指定のステージチップまでを作成
        for (int i = currentChipIndex + 1; i <= toChipIndex; i++)
        {
            GameObject stageObject = GenerateStage(i);

            //生成したステージをリストに追加
            generatedStageList.Add(stageObject);
        }

        //ステージ保有上限内になるまで古いステージを削除
        while (generatedStageList.Count > preInstantiate + 2) DestroyOldStage();

        currentChipIndex = toChipIndex;
    }

    GameObject GenerateStage(int chipIndex)  //指定のインデックス位置にステージオブジェクトをランダムに生成
    {
        int nextStageChip = Random.Range(0, stageChips.Length);

        GameObject stageObject = (GameObject)Instantiate(
            stageChips[nextStageChip],
            new Vector3(0, 0, chipIndex * StageChipSize),
            Quaternion.identity
            );

        return stageObject;
    }

    void DestroyOldStage()  //一番古いステージを削除
    {
        GameObject oldStage = generatedStageList[0];
        generatedStageList.RemoveAt(0);
        Destroy(oldStage);
    }
}
