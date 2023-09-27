using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerGold : MonoBehaviour
{
    public int currentGold = 1000; // �ʱ� ���
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

    private PlayerGold playerGold; // PlayerGold Ŭ������ �ν��Ͻ��� ������ ���� �߰�

    public Ranger redRanger;
    public Ranger blueRanger;
    public Ranger blackRanger;
    public Ranger greenRanger;
    public Ranger pinkRanger;

    private void Awake()
    {
        // �� Ranger �ʱ�ȭ
        redRanger.Initialize("Red Ranger", 5f, 2f, 1);
        blueRanger.Initialize("Blue Ranger", 7f, 2.5f, 1);
        blackRanger.Initialize("Black Ranger", 6f, 2.2f, 1);
        greenRanger.Initialize("Green Ranger", 8f, 2.8f, 1);
        pinkRanger.Initialize("Pink Ranger", 6.5f, 2.3f, 1);

        // PlayerGold Ŭ������ �ν��Ͻ� ����
        playerGold = FindObjectOfType<PlayerGold>();
    }

    public void EnhanceRanger(RangerType rangerType)
    {
        // ��尡 ������� Ȯ��
        int enhancementCost = GetEnhancementCost(rangerType);
        if (playerGold.currentGold >= enhancementCost)
        {
            // ��� ����
            playerGold.AddGold(-enhancementCost);

            // ������ ��ȭ
            GetRanger(rangerType).EnhanceRanger();

            // ��ȭ �� ���ݷ°� ���� �ӵ� ���
            Ranger enhancedRanger = GetRanger(rangerType);
            Debug.Log(enhancedRanger.GetRangerName() + "��(��) ��� " + enhancementCost + "�� �Ҹ��Ͽ� ��ȭ�Ǿ����ϴ�.");
            Debug.Log("���ο� ���ݷ�: " + enhancedRanger.GetAttackDamage());
            Debug.Log("���ο� ���� �ӵ�: " + enhancedRanger.GetAttackSpeed());
        }
        else
        {
            Debug.Log("��尡 �����մϴ�!");
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

    private float attackDamageIncrease = 2f; // ������ ��
    private float attackSpeedIncrease = 0.1f; // ������ ��

    public void Initialize(string name, float attackDamage, float attackSpeed, int level)
    {
        rangerName = name;
        baseAttackDamage = attackDamage;
        baseAttackSpeed = attackSpeed;
        enhancementLevel = level;
    }

    public void EnhanceRanger()
    {
        // ���ݷ°� ���� �ӵ��� ������ŵ�ϴ�. (������ �� ���)
        baseAttackDamage += attackDamageIncrease;
        baseAttackSpeed -= attackSpeedIncrease;

        // ��ȭ ���� ����
        enhancementLevel++;
    }

    public int GetEnhancementCost()
    {
        // ��ȭ ����� ����Ͽ� ��ȯ (��: enhancementLevel * 100 ��)
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



