using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SlidesChanger : MonoBehaviour
{
	[SerializeField] private AudioSource audioSource;
	[SerializeField] private bool playOnAwake;
	[SerializeField] private GameObject[] slides;
	[SerializeField] private AudioClip[] audioClips;
	[SerializeField] private GameObject bg;
	[SerializeField] private string nextScene;

	private PauseMenu m_pauseMenu;
	private bool isPlaying = false;
	private int CurrentSlide = 0;

	private void Awake()
	{
		m_pauseMenu = GameObject.FindObjectOfType<PauseMenu>();
		if (playOnAwake)
		{
			audioSource = GameObject.Find("Voice").GetComponent<AudioSource>();
			Play();
		}
	}

	private void Update()
	{
		if (Input.anyKeyDown && isPlaying)
		{
			NextSlide();
		}
	}

	public void Play()
	{
		m_pauseMenu.canBePaused = false;
		CurrentSlide = 0;
		foreach (var VARIABLE in slides)
		{
			VARIABLE.SetActive(false);
		}
		slides[CurrentSlide].SetActive(true);
		audioSource.clip = audioClips[CurrentSlide];
		audioSource.Play();
		isPlaying = true;
		try
		{
			bg.SetActive(true);
		}
		catch (Exception e)
		{
		}

		CurrentSlide++;
	}

	private void NextSlide()
	{
		foreach (var VARIABLE in slides)
		{
			VARIABLE.SetActive(false);
		}

		try
		{
			slides[CurrentSlide].SetActive(true);
			try
			{
				audioSource.clip = audioClips[CurrentSlide];
				audioSource.Play();
			}
			catch (Exception e)
			{
				Debug.LogWarning("No audioToPlay");
			}
			CurrentSlide++;
		}
		
		catch (Exception e)
		{
			if (!string.IsNullOrEmpty(nextScene))
			{
				SceneManager.LoadScene(nextScene);
			}
			//Debug.LogError(e);
			isPlaying = false;
			m_pauseMenu.canBePaused = true;
			if(bg) bg.SetActive(false);
			audioSource.Stop();
		}
	}
}
