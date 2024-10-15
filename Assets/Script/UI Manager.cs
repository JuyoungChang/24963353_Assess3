using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    private int score;
    private Text ScoreText;
    [SerializeField]private float timer;

    [SerializeField]private int minutes;
    [SerializeField]private int seconds;
    [SerializeField]private int mSeconds;
    [SerializeField]private TextMeshProUGUI timerText;
    void Start()
    {
        //ScoreText.text = "Score:" + 0;
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
    public void ScoreAdd()
    {
        score++;
    }

    public void InGameTimer()
    {
        timer += Time.deltaTime;
        minutes = (int)(timer / 60f);
        seconds = (int)(timer % 60 );
        mSeconds = (int)((timer - (minutes * 60 + seconds)) * 1000);
        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, mSeconds/10);
    }
}
