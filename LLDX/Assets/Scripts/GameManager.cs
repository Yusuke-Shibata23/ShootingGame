using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // シングルトン instance
    public static GameManager Instance { get; private set; }

    public TextMeshProUGUI gameOverText; // インスペクターで割り当てる
    public TextMeshProUGUI scoreText; // インスペクターで割り当てる
    public Button retryButton; // インスペクターで割り当てる

    private void Awake()
    {
        // シングルトンのセットアップ
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // 最初はゲームオーバーUIを非表示にする
        gameOverText.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(true);
    }

    public void GameOver()
    {
        // スコアテキストを更新
        scoreText.text = "Score: " + ScoreManager.score; // Fix 

        // ゲームオーバーUIを表示
        gameOverText.gameObject.SetActive(true);
        retryButton.gameObject.SetActive(true);
    }

    public void Retry()
    {
        // ゲームオーバーUIを非表示
        gameOverText.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(true);

        // 現在のシーンを再読み込みしてゲームをリスタート
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

