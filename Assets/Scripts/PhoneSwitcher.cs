using UnityEngine;

public class PhoneSwitcher : MonoBehaviour
{
	[SerializeField] private AudioClip phonePowerSound;
	private Animator m_animator;
	private AudioSource m_sfxAudioSource;
	private CameraController m_cameraController;
	[SerializeField] private ScrollControl m_scrollControl;

	private void Awake()
	{
		m_cameraController = GameObject.FindObjectOfType<CameraController>();
		m_animator = GetComponent<Animator>();
		m_sfxAudioSource = GameObject.Find("SFX").GetComponent<AudioSource>();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Tab))
		{
			SwitchPhone();
		}
	}

	public void ChangePage(GameObject _newPage)
	{
		Destroy(m_scrollControl.m_currentPage.gameObject);
		m_scrollControl.m_currentPage = Instantiate(_newPage, m_scrollControl.transform).GetComponent<RectTransform>();
		m_scrollControl.maxScrollPosition = _newPage.GetComponent<Page>().MaxScroll;
		if (!m_scrollControl.control)
		{
			SwitchPhone();
		}
	}

	public void SwitchPhone()
	{
		m_animator.SetTrigger("Power");
		m_sfxAudioSource.clip = phonePowerSound;
		m_scrollControl.control = !m_scrollControl.control;
		m_cameraController.control = !m_cameraController.control;
		m_sfxAudioSource.Play();
	}
}