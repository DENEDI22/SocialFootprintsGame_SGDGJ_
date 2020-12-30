using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
 	[SerializeField] private GameObject m_tutorial;

	public void StartGame()
	{
		SceneManager.LoadScene(1);
	}

	public void Tutorial()
	{
		m_tutorial.SetActive(true);
	}

	public void Exit()
	{
		Application.Quit();
	}
}
