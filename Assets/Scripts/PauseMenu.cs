using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
	[SerializeField] private GameObject pauseMenu;
	private CameraController m_cameraController;
	public bool canBePaused = true;

	private void Awake()
	{
		m_cameraController = GetComponent<CameraController>();
	}

	public void Resume()
	{
		pauseMenu.SetActive(false);
		m_cameraController.canMoveCamera = true;
	}

	public void MainMenu()
	{
		SceneManager.LoadScene(0);
	}

	public void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape) && canBePaused)
		{
			 pauseMenu.SetActive(!pauseMenu.activeInHierarchy);
			 m_cameraController.canMoveCamera = !m_cameraController.canMoveCamera;
		}
	}
}
