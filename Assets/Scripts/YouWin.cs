using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouWin : MonoBehaviour
{
    public GameObject YouWinPanel;

    // end pointteki mesh render� kapal� olan k�pe �arparsa durdur ve win panelini 
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            YouWinPanel.SetActive(true);
            Time.timeScale = 0f;

        }
    }
}
