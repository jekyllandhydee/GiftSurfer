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
            Time.timeScale = 0f;

            AdManager.Instance.ShowInterstitialAd();
        }
    }
    void OnLoad(AsyncOperation op)
    {
        Time.timeScale = 1f;
    }

    public void LoadNext()
    {
        SceneManager.LoadSceneAsync(2).completed += OnLoad;
    }
}