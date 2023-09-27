using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    
    [SerializeField] public RedRanger redRanger;
    [SerializeField] public BlueRanger blueRanger;
    [SerializeField] public BlackRanger blackRanger;
    [SerializeField] public GreenRanger greenRanger;
    [SerializeField] public PinkRanger pinkRanger;

    List<GameObject> rangerList;

    private static TowerManager instance;

    public static TowerManager Instance
    {
        get
        {
            if (null == instance)
            {
                instance = FindObjectOfType<TowerManager>();
                if (null == instance)
                {
                    // 만약 TowerManager 객체를 찾을 수 없다면 새로 생성합니다.
                    GameObject go = new GameObject("TowerManager");
                    instance = go.AddComponent<TowerManager>();
                }
            }
            return instance;
        }
    }

    void Awake()
    {
        rangerList = new List<GameObject>();

        //                              name, attValue, attDelay, hp, 
        redRanger.RedSetData("RedRanger", 0f, 2f, 10f);
        blueRanger.BlueSetData("BlueRanger", 1f, 3f, 5f, 2f);
        greenRanger.GreenSetData("GreenRanger", 2f, 5f, 4f);
        blackRanger.BlackSetData("BlackRanger", 1f, 2f, 6f);
        pinkRanger.PinkSetData("PinkRanger", 1f, 2f, 8f, 1f);

        rangerList.Add(redRanger.gameObject);
        rangerList.Add(blueRanger.gameObject);
        rangerList.Add(greenRanger.gameObject);
        rangerList.Add(blackRanger.gameObject);
        rangerList.Add(pinkRanger.gameObject);
        // ----------------------------------------------------------------

    }

    void Start()
    {
        Vector3 basePos = new Vector3(-16.5f, -8f, 0);

        for (int i = 0; i < rangerList.Count; i++)
        {
            Instantiate(rangerList[i], basePos, Quaternion.identity);
            basePos.x += 3.5f;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
