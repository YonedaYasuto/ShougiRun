using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explain : MonoBehaviour
{
    //ëÄçÏê‡ñæÇÃÉ{É^ÉìëÄçÏóp
    [SerializeField] GameObject expButton;
    [SerializeField] GameObject startButton;
    [SerializeField] GameObject quitButton;
    [SerializeField] GameObject expExitButton;
    [SerializeField] GameObject Exp1;
    [SerializeField] GameObject Exp2;
    [SerializeField] GameObject Exp3;

    // Start is called before the first frame update
    void Start()
    {
        expExitButton.SetActive(false);
        Exp1.SetActive(false);
        Exp2.SetActive(false);
        Exp3.SetActive(false);

    }

     public void OnclickexpButton()
    {
        expExitButton.SetActive(true);
        Exp1.SetActive(true);
        expButton.SetActive(false);
        startButton.SetActive(false);
        quitButton.SetActive(false);

    }
    public void OnclickexpExitButton()
    {
        expExitButton.SetActive(false);
        Exp1.SetActive(false);
        Exp2.SetActive(false);
        Exp3.SetActive(false);
        expButton.SetActive(true);
        startButton.SetActive(true);
        quitButton.SetActive(true);
    }

}
