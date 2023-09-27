using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [HideInInspector] public float gameTime;
    [HideInInspector] public float maxGameTime;

    [SerializeField] private Image flagGoal1;
    [SerializeField] private Image flagGoal2;
    [SerializeField] private Image finalGoal;

    [SerializeField] private Slider timeGauge;

    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject winPanel;

    private PlayerManager _playerManager;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Time.timeScale = 1;
        gameTime = 0f;
        maxGameTime = 3 * 10f;
        flagGoal1.enabled = false;
        flagGoal2.enabled = false;
        finalGoal.enabled = false;
    }

    private void Update()
    {
        gameTime += Time.deltaTime;

        if (gameTime > 10f)
        {
            flagGoal1.enabled = true;
            if (gameTime > 20f)
                flagGoal2.enabled = true;
            if (gameTime > maxGameTime)
            {
                gameTime = maxGameTime;
                finalGoal.enabled = true;
                Time.timeScale = 0f;                
                GameWon();
            }
        }
    }
    private void LateUpdate()
    {
        timeGauge.value = gameTime / maxGameTime;
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
        losePanel.SetActive(true);
    }

    private void GameWon()
    {
        gameOverPanel.SetActive(true);
        winPanel.SetActive(true);
        // _playerManager.diaManager.StageCleared(500);
    }

    public void OnClickRestartBtn()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OnClickStageBtn()
    {
        SceneManager.LoadScene("StageScene");
    }
}
