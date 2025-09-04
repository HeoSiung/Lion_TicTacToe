using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent (typeof(SpriteRenderer))]

public class Block : MonoBehaviour
{
    [SerializeField] private Sprite oSprite;
    [SerializeField] private Sprite xSprite;
    [SerializeField] private SpriteRenderer markerSpriteRenderer;

    public delegate void OnBlockClicked(int index);
    private OnBlockClicked _onBlockClicked;

    // ��Ŀ Ÿ��
    public enum MarkerType { None, o, x }

    // �� �ε���
    private int _blockIndex;

    // ���� ������ ���� ��������Ʈ ������
    private SpriteRenderer _spriteRenderer;
    private Color _defaultBlockColor;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _defaultBlockColor = _spriteRenderer.color;
    }

    // 1. �ʱ�ȭ
    public void InitMarker(int blockIndex, OnBlockClicked onBlockClicked)
    {
        _blockIndex = blockIndex;
        SetMarker(MarkerType.None); // �⺻ Ÿ������ �ʱ�ȭ
        SetBlockColor(_defaultBlockColor);    // �⺻ �������� �ʱ�ȭ
        _onBlockClicked = onBlockClicked;
    }

    // 2. ��Ŀ ����
    public void SetMarker(MarkerType markerType)
    {
        switch (markerType)
        {
            case MarkerType.None:
                markerSpriteRenderer.sprite = null;
                break;
            case MarkerType.o:
                markerSpriteRenderer.sprite = oSprite;
                break;
            case MarkerType.x:
                markerSpriteRenderer.sprite = xSprite;
                break;
        }
    }

    // 3. ���� ����
    public void SetBlockColor(Color color)
    {
        _spriteRenderer.color = color;
    }

    // 4. �� ��ġ ó��
    private void OnMouseUpAsButton()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        Debug.Log("�� ���õ� : " +  _blockIndex);

        _onBlockClicked?.Invoke(_blockIndex);
    }
}
