using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject RestartPanel;
    [SerializeField] GameObject gameOverPanel;

    Image image;
    [SerializeField] [Range(0f, 1f)] float lerpTime;
    [SerializeField] Color[] myColors;
    int colorIndex = 0, len;
    float t = 0f;

    public static event UnityAction OnDeath;

    private void Awake()
    {
        if (Instance != null)
            Destroy(this);

        Instance = this;
    }

    public void InvokeDeath()
    {
        gameOverPanel.SetActive(true);
        OnDeath?.Invoke();
    }

    void Start()
    {
       // image = RestartPanel.GetComponent<Image>();
        //len = myColors.Length;
    }

    public void Restart() => SceneHandler.ReloadScene();

    public void PlayGame() => SceneHandler.PlayGame();


    //void Update()
    //{
    //    if (gameOver.isDied)
    //    {
    //        RestartPanel.SetActive(true);

    //        image.color = Color.Lerp(image.color, myColors[colorIndex], lerpTime);
    //        t = Mathf.Lerp(t, 1f, lerpTime);
    //        if (t > .9f)
    //        {
    //            t = 0f;
    //            colorIndex++;
    //            colorIndex = (colorIndex >= len) ? 0 : colorIndex;
    //        }
    //        if (Input.GetMouseButtonDown(0))
    //        {
    //            Time.timeScale = 1;
    //            SceneManager.LoadScene(0);
    //        }
    //    }


    //}
}
