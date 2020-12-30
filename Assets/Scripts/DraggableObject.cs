using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableObject : MonoBehaviour, IDragHandler
{
	
	public void OnDrag(PointerEventData eventData)
	{
		if (Input.GetMouseButton(0))
		{
			Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			transform.position = cursorPos;
		}
	}
}
