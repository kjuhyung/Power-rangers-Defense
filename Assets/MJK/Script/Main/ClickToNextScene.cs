using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickToNextScene : MonoBehaviour
{
    public static ClickToNextScene instance;
    [SerializeField] Animator ani;

    private bool isMainScene = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        CheckScene();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        CheckScene();
    }

    private void CheckScene()
    {
        isMainScene = SceneManager.GetActiveScene().name == "MainScene";
        enabled = isMainScene;
    }

    public void Update()
    {
        if (isMainScene && Input.GetMouseButtonDown(0))
        {
            StartCoroutine(LoadLevel());
        }
    }

    public IEnumerator LoadLevel()
    {
        ani.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        ani.SetTrigger("Start");
    }
}