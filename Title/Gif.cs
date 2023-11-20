using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gif : MonoBehaviour
{
    [SerializeField] float repeatTime;    //繰り返し時間
    private float elapsedTime;            //経過時間
    Image gif;                            
    [SerializeField] Sprite img1;
    [SerializeField] Sprite img2; 
    bool change = true;                   //画像の切り替え用のbool


    void Start()
    {
        gif = GetComponent<Image>();
        gif.sprite = img1;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;     //時間をカウントする

        if (elapsedTime >= repeatTime)     //繰り返し時間を過ぎたら
        {
            change = !change;              

            elapsedTime = 0;               //経過時間をリセットする
        }

        if (change == false)               //boolで画像切り替え
        {
            gif.sprite = img1;
        }
        else gif.sprite = img2;
    }
}
