using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private static PlayerManager instance;

    public static PlayerManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PlayerManager>();
                if (instance == null)
                {
                    GameObject managerObject = new GameObject("PlayerManager");
                    instance = managerObject.AddComponent<PlayerManager>();
                }
            }
            return instance;
        }
    }

    public PlayerGold playerGold;
    public DiaManager diaManager;
    public  PlayerHP playerHP; 

 
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject); // 씬 전환 시 파괴되지 않도록 설정

        playerGold = FindObjectOfType<PlayerGold>();
        diaManager = FindObjectOfType<DiaManager>();
        playerHP = FindObjectOfType<PlayerHP>();
    }


}