using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SoundSetting : MonoBehaviour, IPointerClickHandler
{
	[SerializeField] private GameObject m_audioListener;
	private Image m_indicatorImage;
	private int m_audio;

	[SerializeField] private Sprite AudioOn;
	[SerializeField] private Sprite AudioOff;

	public void OnPointerClick(PointerEventData eventData)
	{
		SwitchAudio();
	}

	private void Awake()
	{
		// m_audioListener = Camera.main.GetComponent<AudioListener>();
		m_indicatorImage = GetComponent<Image>();
		
		if (PlayerPrefs.HasKey("Audio"))
		{
			m_audio = PlayerPrefs.GetInt("Audio");
		}
		else
		{
			m_audio = 1;
			PlayerPrefs.SetInt("Audio", m_audio);
		}

		if (m_audio == 1)
		{
			m_indicatorImage.sprite = AudioOn;
			m_audioListener.SetActive(true);
		}
		else
		{
			m_indicatorImage.sprite = AudioOff;
			m_audioListener.SetActive(false);
		}
	}

	private void SwitchAudio()
	{
		m_audio = m_audio == 1 ? 0 : 1;
		if (m_audio == 1)
		{
			m_indicatorImage.sprite = AudioOn;
			m_audioListener.SetActive(true);
		}
		else
		{
			m_indicatorImage.sprite = AudioOff;
			m_audioListener.SetActive(false);
		}
		PlayerPrefs.SetInt("Audio", m_audio);
	}
}