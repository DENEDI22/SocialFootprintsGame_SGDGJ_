using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WebLink : MonoBehaviour, IPointerClickHandler
{
	[SerializeField] private string link;

	public void OnPointerClick(PointerEventData eventData)
	{
		System.Diagnostics.Process.Start(link);
	}
}
