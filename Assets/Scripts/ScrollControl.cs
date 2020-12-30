using UnityEngine;

public class ScrollControl : MonoBehaviour
{
	[SerializeField] [Range(50f, 500f)] private float scrollSens = 1;
	public float maxScrollPosition = 0;
	[HideInInspector] public RectTransform m_currentPage;
	public bool control = false;

	public void Start()
	{
		m_currentPage = GameObject.FindWithTag("Post").GetComponent<RectTransform>();
	}
	
	private void Update()
	{
		if (control)
		{
			m_currentPage.Translate(new Vector3(0, Input.GetAxis("Mouse ScrollWheel") * scrollSens) * -1);
		}
		if (m_currentPage.localPosition.y < 0)
		{
			m_currentPage.localPosition = Vector2.zero;
		}

		if (m_currentPage.localPosition.y > maxScrollPosition)
		{
			m_currentPage.localPosition = new Vector2(0, maxScrollPosition);
		}
	}
}