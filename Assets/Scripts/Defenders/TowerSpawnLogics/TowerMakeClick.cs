using UnityEngine;

public class TowerMakeClick : MonoBehaviour
{
    public static TowerMakeClick Instance;

    private bool isClicked = false;

    public BaseTowerData BTDalphaRanger;

    private GameObject GOalphaRanger; //���ӿ�����ƮŸ������ ��������
    private GameObject nonAlphaRanger = null;
    public BaseTowerData BTDrealRanger;
    private GameObject GOrealRanger;

    private Vector3 offset;

    private Camera mainCam;
    private Ray ray;
    private RaycastHit hit;

    void Start()
    {
        mainCam = Camera.main;
        GOalphaRanger = BTDalphaRanger.gameObject;
        GOrealRanger = BTDrealRanger.gameObject;

        isClicked = false;
    }


    private void OnMouseDown()
    {
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
            // ���콺�� ���� �����̵��� �մϴ�.
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
            // Ŭ���� ������ �� ���� Ÿ���� �����ϰ� ��ǥ�� �������� �����մϴ�.
            CalcMousePos_PlaceTower();
            Destroy(nonAlphaRanger);
        }
    }

    public void TowerSpawn(Transform tileTransform)
    {
        Tile tile = tileTransform.GetComponent<Tile>();

        if (tile.isBuiltTower == true)
        {
            return;
        }
        tile.isBuiltTower = true;

        if (PlayerManager.Instance.playerGold.currentGold >= 100)
        {
            var ranger = Instantiate(GOrealRanger, new Vector3(tileTransform.position.x, tileTransform.position.y + 0.3f, 0), Quaternion.identity);
            Destroy(ranger, 8f);
            int amount = 100;
            PlayerManager.Instance.playerGold.AddGold(-amount);

        }
        else
        {
            return;
        }
        tile.isBuiltTower = false;
    }

    public void CalcMousePos_PlaceTower()
    {
        ray = mainCam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.transform.CompareTag("Tile"))
            {
                TowerSpawn(hit.transform);
            }
            else
            {
                Debug.Log("Nope");
            }
        }
    }
}