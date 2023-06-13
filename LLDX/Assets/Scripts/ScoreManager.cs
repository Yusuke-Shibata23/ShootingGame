using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int score = 0; // スコアはstatic
    public TextMeshProUGUI scoreText;
    private static ScoreManager instance;  // ScoreManagerのインスタンスを保持するための変数

    // 
    void Start()
    {
        score = 0;
        instance = this;  // ScoreManagerのインスタンスを保存
        UpdateScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScoreText();
    }

    public static void AddScore(int value)
    {
        score += value;
        instance.UpdateScoreText();  // 保存したインスタンスを使用してメソッドを呼び出す
    }

    private void UpdateScoreText()
    {
        // 
        if (scoreText != null)
        {
            scoreText.text = "Score: " + ScoreManager.score;

        }
    }
}

