using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerGold : MonoBehaviour
{
    public int currentGold = 1000; // 초기 골드
    public TMP_Text goldText;

    void Start()
    {
        UpdateGoldText();
    }

    public void AddGold(int amount)
    {
        currentGold += amount;
        UpdateGoldText();
    }

    private void UpdateGoldText()
    {
        goldText.text = currentGold + " G";
    }
}

public class RangerEnhance : MonoBehaviour
{
    private static RangerEnhance instance;

    public static RangerEnhance Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<RangerEnhance>();
                if (instance == null)
                {
                    GameObject managerObject = new GameObject("RangerEnhance");
                    instance = managerObject.AddComponent<RangerEnhance>();
                }
            }
            return instance;
        }
    }

    private PlayerGold playerGold; // PlayerGold 클래스의 인스턴스를 참조할 변수 추가

    public Ranger redRanger;
    public Ranger blueRanger;
    public Ranger blackRanger;
    public Ranger greenRanger;
    public Ranger pinkRanger;

    private void Awake()
    {
        // 각 Ranger 초기화
        redRanger.Initialize("Red Ranger", 5f, 2f, 1);
        blueRanger.Initialize("Blue Ranger", 7f, 2.5f, 1);
        blackRanger.Initialize("Black Ranger", 6f, 2.2f, 1);
        greenRanger.Initialize("Green Ranger", 8f, 2.8f, 1);
        pinkRanger.Initialize("Pink Ranger", 6.5f, 2.3f, 1);

        // PlayerGold 클래스의 인스턴스 참조
        playerGold = FindObjectOfType<PlayerGold>();
    }

    public void EnhanceRanger(RangerType rangerType)
    {
        // 골드가 충분한지 확인
        int enhancementCost = GetEnhancementCost(rangerType);
        if (playerGold.currentGold >= enhancementCost)
        {
            // 골드 차감
            playerGold.AddGold(-enhancementCost);

            // 레인저 강화
            GetRanger(rangerType).EnhanceRanger();

            // 강화 후 공격력과 공격 속도 출력
            Ranger enhancedRanger = GetRanger(rangerType);
            Debug.Log(enhancedRanger.GetRangerName() + "이(가) 골드 " + enhancementCost + "를 소모하여 강화되었습니다.");
            Debug.Log("새로운 공격력: " + enhancedRanger.GetAttackDamage());
            Debug.Log("새로운 공격 속도: " + enhancedRanger.GetAttackSpeed());
        }
        else
        {
            Debug.Log("골드가 부족합니다!");
        }
    }

    public int GetEnhancementCost(RangerType rangerType)
    {
        return GetRanger(rangerType).GetEnhancementCost();
    }

    public Ranger GetRanger(RangerType rangerType)
    {
        switch (rangerType)
        {
            case RangerType.Red:
                return redRanger;
            case RangerType.Blue:
                return blueRanger;
            case RangerType.Black:
                return blackRanger;
            case RangerType.Green:
                return greenRanger;
            case RangerType.Pink:
                return pinkRanger;
            default:
                return null;
        }
    }
}

public enum RangerType
{
    Red,
    Blue,
    Black,
    Green,
    Pink
}

public abstract class Ranger : MonoBehaviour
{
    private string rangerName;
    private float baseAttackDamage;
    private float baseAttackSpeed;
    private int enhancementLevel;

    private float attackDamageIncrease = 2f; // 임의의 값
    private float attackSpeedIncrease = 0.1f; // 임의의 값

    public void Initialize(string name, float attackDamage, float attackSpeed, int level)
    {
        rangerName = name;
        baseAttackDamage = attackDamage;
        baseAttackSpeed = attackSpeed;
        enhancementLevel = level;
    }

    public void EnhanceRanger()
    {
        // 공격력과 공격 속도를 증가시킵니다. (임의의 값 사용)
        baseAttackDamage += attackDamageIncrease;
        baseAttackSpeed -= attackSpeedIncrease;

        // 강화 레벨 증가
        enhancementLevel++;
    }

    public int GetEnhancementCost()
    {
        // 강화 비용을 계산하여 반환 (예: enhancementLevel * 100 등)
        return enhancementLevel * 100;
    }

    public int GetEnhancementLevel()
    {
        return enhancementLevel;
    }

    public string GetRangerName()
    {
        return rangerName;
    }

    public float GetAttackDamage()
    {
        return baseAttackDamage;
    }

    public float GetAttackSpeed()
    {
        return baseAttackSpeed;
    }
}




