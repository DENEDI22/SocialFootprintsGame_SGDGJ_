using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Epilogue : MonoBehaviour, IPointerClickHandler
{
	[SerializeField] private GameObject Epilogu;
	private Transform hud;

	private void Awake()
	{
		hud = GameObject.Find("HUD").transform;
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		Instantiate(Epilogu, hud);
	}
}
