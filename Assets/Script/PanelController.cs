using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PanelController : MonoBehaviour
{
    public TMP_Text scoreText, timetext, lifePlayerText, countKillsText;

    [SerializeField] private GameObject menuPauseGame;
    public bool inPause;
    private float minutes, seconds;
    private float time;
    private float timePlayed;
    [SerializeField] private Player player;
    public int countKills;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI timePlayedText;

    private void Start()
    {
        Time.timeScale = 1f;
        inPause = false;
        gameOverPanel.SetActive(false);
    }

    private void Update()
    {
        time += Time.deltaTime;
        minutes = (int)(time / 60);
        seconds = time - minutes * 60;

        if (!player.isdead)
        {
            if (!inPause)
            {
                timetext.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }
            int life = (int)player.lifePlayer;
            lifePlayerText.text = life.ToString();
            countKillsText.text = countKills.ToString();
        }
       
        if (Input.GetKeyDown(KeyCode.Escape) && !player.isdead)
        {
            PauseGame();
        }
        

        if (player.isdead)
        {
            lifePlayerText.text = "0";
            Invoke("GameOver", 2);
        }
    }
    public void ControlScoreText(int num)
    {
        scoreText.text = num.ToString();
    }

    public void PauseGame()
    {
        if (!menuPauseGame.activeSelf)
        {
            menuPauseGame.SetActive(true);
            Time.timeScale = 0f;
            inPause = true;
        }
        else
        {
            menuPauseGame.SetActive(false);
            Time.timeScale = 1f;
            inPause = false;
        }
        AudioGameManager.Instance.SoundSelect();
    }

    public void MainMenu()
    {
        AudioGameManager.Instance.SoundSelect();
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void RestartLevel()
    {
        AudioGameManager.Instance.SoundSelect();
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver()
    {
        timePlayedText.text = string.Format("{0:00}:{1:00}", minutes, seconds - 2);
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

}
