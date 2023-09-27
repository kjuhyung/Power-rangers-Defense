using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickStage : MonoBehaviour
{
    public string stageGame1;

    public string TowerManagement;

    public void gameStart()
    {
        SceneManager.LoadScene(stageGame1);
        Time.timeScale = 1f;
    }

    public void OnClickTowerSettingBtn()
    {
        SceneManager.LoadScene(TowerManagement);
        Time.timeScale = 1f;
    }
}
