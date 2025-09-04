using UnityEngine;

public class BlockController : MonoBehaviour
{
    [SerializeField] private Block[] blocks;

    public delegate void OnBlockClicked(int row, int col);
    public OnBlockClicked OnBlockClickedDelegate;

    // 1. ��� ���� �ʱ�ȭ
    public void InintBlocks()
    {
        for (int i = 0; i < blocks.Length; i++)
        {
            blocks[i].InitMarker(i, onBlockClicked: blockIndex =>
            {
                // Ư�� ���� Ŭ�� �� ���¿� ���� ó��
                var row = blockIndex / Constants.BlockColumnCount;
                var col = blockIndex % Constants.BlockColumnCount;
                OnBlockClickedDelegate?.Invoke(row, col);
            });
        }
    }

    // 2. Ư�� ���� ��Ŀ ǥ��
    public void PlaceMarker(Block.MarkerType markerType, int row, int col)
    {
        // row, col >> index ��ȯ
        var blockIndex = row * Constants.BlockColumnCount + col;
        blocks[blockIndex].SetMarker(markerType);
    }
    
    // 3. Ư�� ���� ���� ����
    public void SetBlockColor()
    {
        // TODO : ���� ���� �ϼ��Ǹ� ����
    }
}
