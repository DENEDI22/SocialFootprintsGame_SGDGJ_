using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AudioComment : MonoBehaviour, IPointerEnterHandler
{
	[SerializeField] private AudioClip comment;
	[SerializeField] private AudioSource audioSource;

	private void Awake()
	{
		audioSource = GameObject.Find("Voice").GetComponent<AudioSource>();
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (!audioSource.GetComponent<AudioCommentRecorder>().comments.Contains(comment))
		{
			audioSource.clip = comment;
			audioSource.Play();
			audioSource.GetComponent<AudioCommentRecorder>().comments.Add(comment);
		}
		Destroy(this);
	}
}