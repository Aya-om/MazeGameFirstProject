using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    public Text winText;
    public void ShowWin()
    {
        gameObject.SetActive(true);
        winText.text = "YOU Win :) ";
    }
    public void StartButton()
    {
        SceneManager.LoadScene(0);
    }
}
