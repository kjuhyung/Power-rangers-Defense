using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool isBuiltTower { set; get; }

    private void Awake()
    {
        isBuiltTower = false;
    }
}
