using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // �V���O���g�� instance
    public static GameManager Instance { get; private set; }

    public TextMeshProUGUI gameOverText; // �C���X�y�N�^�[�Ŋ��蓖�Ă�
    public TextMeshProUGUI scoreText; // �C���X�y�N�^�[�Ŋ��蓖�Ă�
    public Button retryButton; // �C���X�y�N�^�[�Ŋ��蓖�Ă�

    private void Awake()
    {
        // �V���O���g���̃Z�b�g�A�b�v
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

        // �ŏ��̓Q�[���I�[�o�[UI���\���ɂ���
        gameOverText.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(true);
    }

    public void GameOver()
    {
        // �X�R�A�e�L�X�g���X�V
        scoreText.text = "Score: " + ScoreManager.score; // Fix 

        // �Q�[���I�[�o�[UI��\��
        gameOverText.gameObject.SetActive(true);
        retryButton.gameObject.SetActive(true);
    }

    public void Retry()
    {
        // �Q�[���I�[�o�[UI���\��
        gameOverText.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(true);

        // ���݂̃V�[�����ēǂݍ��݂��ăQ�[�������X�^�[�g
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

