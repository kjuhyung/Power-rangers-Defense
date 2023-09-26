using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMakeClick : MonoBehaviour
{
    private bool isClicked = false;

    public BaseTowerData BTDalphaRanger;

    private GameObject GOalphaRanger; //게임오브젝트타입으로 변경해줌
    private GameObject nonAlphaRanger = null;
    public BaseTowerData BTDrealRanger;
    private GameObject GOrealRanger;

    private Vector3 offset;

    void Start()
    {
        GOalphaRanger = BTDalphaRanger.gameObject;
        GOrealRanger = BTDrealRanger.gameObject;

        isClicked = false;
    }


    private void OnMouseDown()
    {
        Debug.Log("asd");
        if (!isClicked)
        {
            
            isClicked = true;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 1.0f;
            nonAlphaRanger = Instantiate(GOalphaRanger.gameObject, mousePos, Quaternion.identity);

            offset = nonAlphaRanger.transform.position - mousePos;
        }
    }

    private void OnMouseDrag()
    {
        if (isClicked && nonAlphaRanger != null)
        {
            // 마우스를 따라 움직이도록 합니다.
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 1.0f;
            nonAlphaRanger.transform.position = mousePos + offset;
        }
    }

    private void OnMouseUp()
    {
        if (isClicked && nonAlphaRanger != null)
        {
            isClicked = false;
            // 클릭을 놓았을 때 실제 타워를 생성하고 비표시 프리팹을 삭제합니다.
            Instantiate(GOrealRanger, nonAlphaRanger.transform.position, Quaternion.identity);
            Destroy(nonAlphaRanger);
        }
    }
}
