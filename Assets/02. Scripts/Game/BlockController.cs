using UnityEngine;

public class BlockController : MonoBehaviour
{
    [SerializeField] private Block[] blocks;

    public delegate void OnBlockClicked(int row, int col);
    public OnBlockClicked OnBlockClickedDelegate;

    // 1. 모든 블럭을 초기화
    public void InintBlocks()
    {
        for (int i = 0; i < blocks.Length; i++)
        {
            blocks[i].InitMarker(i, onBlockClicked: blockIndex =>
            {
                // 특정 블럭이 클릭 된 상태에 대한 처리
                var row = blockIndex / Constants.BlockColumnCount;
                var col = blockIndex % Constants.BlockColumnCount;
                OnBlockClickedDelegate?.Invoke(row, col);
            });
        }
    }

    // 2. 특정 블럭에 마커 표시
    public void PlaceMarker(Block.MarkerType markerType, int row, int col)
    {
        // row, col >> index 변환
        var blockIndex = row * Constants.BlockColumnCount + col;
        blocks[blockIndex].SetMarker(markerType);
    }
    
    // 3. 특정 블럭에 색을 설정
    public void SetBlockColor()
    {
        // TODO : 게임 로직 완성되면 구현
    }
}
