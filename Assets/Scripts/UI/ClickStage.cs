using UnityEngine;
using UnityEngine.SceneManagement;
using static ClickStage;

public class ClickStage : MonoBehaviour
{
    public string TowerManagement;

    public void gameStart(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
        Time.timeScale = 1f;
    }

    public void OnClickTowerSettingBtn()
    {
        SceneManager.LoadScene(TowerManagement);
        Time.timeScale = 1f;
    }
}
