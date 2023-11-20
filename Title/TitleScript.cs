using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour
{
    [SerializeField] string Start;

    public void OnClickStartButton()
    {
        SceneManager.LoadScene(Start);
    }

    public void OnClickBackMenueButton()
    {
        SceneManager.LoadScene("Title");
    }


    public void OnClickQuitButton()
    {
        Quit();//ゲームプレイ終了
    }

    void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
      UnityEngine.Application.Quit();
#endif
    }
}
