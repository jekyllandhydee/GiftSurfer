using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static event Action onPlay;
    //play game butonu-> oyun sahnesini y�kle
  public void PlayGame()
    {
        SceneManager.LoadScene(1);
        print("�al��t�");
    }
    //quit-> oyundan ��k
    public void QuitGame()
    {
        Application.Quit();
    }
}
