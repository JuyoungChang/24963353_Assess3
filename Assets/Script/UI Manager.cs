using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Tilemaps;
public class UIManager : MonoBehaviour
{
    [SerializeField]private int score;
    [SerializeField]private TextMeshProUGUI scoreText;

    [SerializeField]private float timer;
    [SerializeField]private float ghostScaredDuration = 30f;
    [SerializeField]private int minutes;
    [SerializeField]private int seconds;
    [SerializeField]private int mSeconds;
    [SerializeField]private bool countdown;
    [SerializeField]private TextMeshProUGUI timerText;

    void Start()
    {
        if(scoreText == null)
        {
            return;
        }
        scoreText.text = "0";
        ScoreUpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        InGameTimer();
    }
    public void LoadLv1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void Exit()
    {
        SceneManager.LoadScene("StartScene");
    }
    public void ScoreAdd(int point)
    {
        score += point;
        ScoreUpdateText();
    }

    public void ScoreUpdateText()
    {
        scoreText.text = score.ToString();
    }
    public void InGameTimer()
    {
        if(timerText == null)
        {
            return;
        }
        if(countdown && ghostScaredDuration > 0 )
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                timer = 0;
                timerText.text = "00:00:00";
                timerText.gameObject.SetActive(false);
                return;
            }
        }
        else if(!countdown)
        {
            timer += Time.deltaTime;
        }
        minutes = (int)(timer / 60f);
        seconds = (int)(timer % 60 );
        mSeconds = (int)((timer - (minutes * 60 + seconds)) * 1000);
        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, mSeconds/10);
    }
}
