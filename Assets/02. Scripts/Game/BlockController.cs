using UnityEngine;

public class BlockController : MonoBehaviour
{
    [SerializeField] private Block[] blocks;

    // 1. ��� ���� �ʱ�ȭ
    public void InintBlocks()
    {
        for (int i = 0; i < blocks.Length; i++)
        {
            blocks[i].InitMarker(i);
        }
    }

    // 2. Ư�� ���� ��Ŀ ǥ��
    public void PlaceMarker(Block.MarkerType markerType, int blockIndex)
    {
        blocks[blockIndex].SetMarker(markerType);
    }
    
    // 3. Ư�� ���� ���� ����
    public void SetBlockColor()
    {
        // TODO : ���� ���� �ϼ��Ǹ� ����
    }
}
