using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent (typeof(SpriteRenderer))]

public class Block : MonoBehaviour
{
    [SerializeField] private Sprite oSprite;
    [SerializeField] private Sprite xSprite;
    [SerializeField] private SpriteRenderer markerSpriteRenderer;

    // 마커 타입
    public enum MarkerType { None, o, x }

    // 블럭 인덱스
    private int _blockIndex;

    // 색산 변경을 위한 스프라이트 렌더러
    private SpriteRenderer _spriteRenderer;
    private Color _defaultBlockColor;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _defaultBlockColor = _spriteRenderer.color;
    }

    // 1. 초기화
    public void InitMarker(int blockIndex)
    {
        _blockIndex = blockIndex;
        SetMarker(MarkerType.None); // 기본 타입으로 초기화
        SetBlockColor(_defaultBlockColor);    // 기본 색상으로 초기화
    }

    // 2. 마커 설정
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

    // 3. 색상 변경
    public void SetBlockColor(Color color)
    {
        _spriteRenderer.color = color;
    }

    // 4. 블럭 터치 처리
    private void OnMouseUpAsButton()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        Debug.Log("블럭 선택됨 : " +  _blockIndex);
    }
}
