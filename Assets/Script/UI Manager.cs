using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    private int score;
    private Text ScoreText;
    private float timer;
    void Start()
    {
        ScoreText.text = "Score:" + 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadLv1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void ScoreAdd()
    {
        score++;
    }
}
