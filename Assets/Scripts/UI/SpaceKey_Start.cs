using System.Collections;
using UnityEngine;
using TMPro;

public class SpaceKey_Start : MonoBehaviour
{
    TextMeshProUGUI textMeshPro;

    // Use this for initialization
    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        StartCoroutine(BlinkText());
    }

    public IEnumerator BlinkText()
    {
        while (true)
        {
            textMeshPro.text = "GAME START";
            yield return new WaitForSeconds(.8f);
            textMeshPro.text = "";
            yield return new WaitForSeconds(.8f);
        }
    }
}
