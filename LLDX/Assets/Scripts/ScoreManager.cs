using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int score = 0; // �X�R�A��static
    public TextMeshProUGUI scoreText;
    private static ScoreManager instance;  // ScoreManager�̃C���X�^���X��ێ����邽�߂̕ϐ�

    // 
    void Start()
    {
        score = 0;
        instance = this;  // ScoreManager�̃C���X�^���X��ۑ�
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
        instance.UpdateScoreText();  // �ۑ������C���X�^���X���g�p���ă��\�b�h���Ăяo��
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

