using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickToNextScene : MonoBehaviour
{
    public static ClickToNextScene instance;
    [SerializeField] Animator ani;

    private bool IsStartScene = false;

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
        IsStartScene = SceneManager.GetActiveScene().name == "StartScene";
        enabled = IsStartScene;
    }

    public void Update()
    {
        if (IsStartScene && Input.GetMouseButtonDown(0))
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