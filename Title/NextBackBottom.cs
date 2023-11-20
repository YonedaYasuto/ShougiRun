using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextBackBottom : MonoBehaviour
{

    //---- 操作説明のページ送り用の関数 ------------------------------//

    [SerializeField] GameObject Exp1;
    [SerializeField] GameObject Exp2;

    public void OnclickNextButton()
    {
        Exp1.SetActive(false);
        Exp2.SetActive(true);
    }
    public void OnclickBackButton()
    {
        Exp1.SetActive(true);
        Exp2.SetActive(false);
    }
}
