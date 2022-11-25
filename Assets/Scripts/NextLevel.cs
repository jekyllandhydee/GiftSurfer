using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public GameObject NextLevelPanel;
    // level 2'ye geçerken panel yenileme
    private async void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        { 
            NextLevelPanel.SetActive(true);
            await Task.Delay(1000);
            Time.timeScale = 0f;
            SceneManager.LoadSceneAsync(2).completed += OnLoad;

        }
    }
    void OnLoad(AsyncOperation op)
    {
        Time.timeScale = 1f;
    }
}