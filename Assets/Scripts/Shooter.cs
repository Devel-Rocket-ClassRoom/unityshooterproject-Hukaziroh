using UnityEngine;

public class CreateBlocks : MonoBehaviour
{
    public GameObject blockPrefab;      // 블럭 프리팹
    public Transform blockPoint;        // 블럭시작 위치
    public int row = 40;
    public int col = 40;

    private void Start()
    {
        Vector3 pos = blockPoint.position;
        for (int r = 0; r < row; r++)
        {
            // 가로로 col만큼 그려라
            for (int c = 0; c < col; c++)
            {
                Instantiate(blockPrefab, pos, blockPoint.rotation);
                pos.z = blockPoint.position.x + c * 1.1f;
                pos.y = r * 1.1f;
            }
        }
    }

    void Update()
    {

    }
}

