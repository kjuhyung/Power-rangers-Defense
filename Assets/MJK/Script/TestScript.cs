using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScene : MonoBehaviour
{
    // Update is called once per frame
    float spped = 10f;

    void Update()
    {
        transform.Rotate(0, 0, this.spped * Time.deltaTime);
    }
}
