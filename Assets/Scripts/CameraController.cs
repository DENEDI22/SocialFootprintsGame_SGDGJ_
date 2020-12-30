using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField] [Range(20f, 200f)] private float camZoomSpeed;
	[SerializeField] private float minZoom;
	[SerializeField] [Range(1f, 30)] [Delayed]
	private float camMoveSens;

	public bool canMoveCamera = true;
	private Camera m_thisCam;
	public bool control = true;

	private void Awake()
	{
		m_thisCam = GetComponent<Camera>();
	}

	private void ClampVector3(Vector3 _vectorToCalmp, float _edgeValue)
	{
		if (_vectorToCalmp.x > _edgeValue) _vectorToCalmp = new Vector3(600, _vectorToCalmp.y);
		if (_vectorToCalmp.y > _edgeValue) _vectorToCalmp = new Vector3(_vectorToCalmp.x, 600);
		if (_vectorToCalmp.x < _edgeValue) _vectorToCalmp = new Vector3(-600, _vectorToCalmp.y);
		if (_vectorToCalmp.y < _edgeValue) _vectorToCalmp = new Vector3(_vectorToCalmp.x, -600);
	}
	
	private void Update()
	{
		if (control)
		{
			m_thisCam.orthographicSize += -camZoomSpeed * Input.GetAxis("Mouse ScrollWheel");
			
			if (Input.GetMouseButton(2) && canMoveCamera)
			{
				transform.Translate(new Vector3(Input.GetAxis("Mouse X") * camMoveSens,
					Input.GetAxis("Mouse Y") * camMoveSens) * -1);
			}
			//ClampVector3(transform.position, 600);
			float _x = Mathf.Clamp(transform.position.x, -250, 250);
			float _y = Mathf.Clamp(transform.position.y, -115, 115);
			transform.position = new Vector3(_x, _y, -300);
			if (m_thisCam.orthographicSize < 0) m_thisCam.orthographicSize = 0;
			if (m_thisCam.orthographicSize > minZoom) m_thisCam.orthographicSize = minZoom;
		}
	}
}