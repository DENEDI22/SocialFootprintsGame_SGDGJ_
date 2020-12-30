using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Account : MonoBehaviour, IPointerDownHandler, IPointerClickHandler
{
	private GameObject postsParent;
	public GameObject postsPage;
	private PhoneSwitcher m_phoneSwitcher;

	private void OnMouseOver()
	{
		Debug.Log("Pointer is over it");
	}
	
	public void OnPointerDown(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Right)
		{
			// m_phoneSwitcher.ChangePage(postsPage);
		}
	}
	
	private void Awake()
	{
		m_phoneSwitcher = GameObject.FindObjectOfType<PhoneSwitcher>();
	}

	public void ShowRecentPosts()
	{
		m_phoneSwitcher.ChangePage(postsPage);
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Right)
		{
			m_phoneSwitcher.ChangePage(postsPage);
		}
	}
}
