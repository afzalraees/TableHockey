using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject playPanel;
    public GameObject gameOverScreen;
    public GameObject bg;

    public Text score;
    public TextMeshProUGUI record;
    public TextMeshProUGUI finalScore;

    public void StartGame()
    {
        Time.timeScale = 1;
        playPanel.SetActive(false);
        score.gameObject.SetActive(true);
    }

    public void Again()
    {
        GameManager.Instance.ResetPlay(); 
        score.gameObject.SetActive(true);
        score.text = "0";
    }

    public void UpdateScore(int totalScore)
    {
        score.text = totalScore.ToString();
    }

    public void GameOver()
    {
        bg.SetActive(true);
        score.gameObject.SetActive(false);
        finalScore.text = score.text;
        record.text = GameManager.Instance.record.ToString();
        PlayerPrefs.SetInt("Record", int.Parse(record.text));
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;
    }
}
