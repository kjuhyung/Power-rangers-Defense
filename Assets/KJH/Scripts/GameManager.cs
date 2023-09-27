using UnityEngine;
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


    private void Awake()
    {
        instance = this;

    }

    private void Start()
    {
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
                // TODO
                // 보상 화면 
            }
        }
    }
    private void LateUpdate()
    {
        timeGauge.value = gameTime / maxGameTime;
    }



}
