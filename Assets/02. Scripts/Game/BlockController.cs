using UnityEngine;

public class BlockController : MonoBehaviour
{
    [SerializeField] private Block[] blocks;

    // 1. 모든 블럭을 초기화
    public void InintBlocks()
    {
        for (int i = 0; i < blocks.Length; i++)
        {
            blocks[i].InitMarker(i);
        }
    }

    // 2. 특정 블럭에 마커 표시
    public void PlaceMarker(Block.MarkerType markerType, int blockIndex)
    {
        blocks[blockIndex].SetMarker(markerType);
    }
    
    // 3. 특정 블럭에 색을 설정
    public void SetBlockColor()
    {
        // TODO : 게임 로직 완성되면 구현
    }
}
