using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneHandler
{
    public static void ReloadScene()
    {
        SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
    }
    public static void PlayGame()
    {   //sahnelerin 0= mainmenu 1= level1 2= level2
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
