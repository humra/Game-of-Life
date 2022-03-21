using UnityEngine;
using UnityEngine.EventSystems;

public class DragElement : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private BlockType blockType;

    private float canvasScaleFactor;
    private RectTransform rectTransform;
    private Vector2 startPosition;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasScaleFactor = FindObjectOfType<Canvas>().scaleFactor;
        startPosition = rectTransform.anchoredPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvasScaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition = startPosition;
        FindObjectOfType<GameManager>().AddElement(blockType);
    }
}

public enum BlockType
{
    Block
}