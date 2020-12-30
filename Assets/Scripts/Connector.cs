using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connector : MonoBehaviour
{
	public Transform aPoint;
	public Transform bPoint;

	private LineRenderer m_lineRenderer;

	private void Awake()
	{
		m_lineRenderer = GetComponent<LineRenderer>();
	}
	
	public void Connect()
	{
		Vector3[] points = new Vector3[] {aPoint.position, bPoint.position};
		m_lineRenderer.SetPositions(points);
	}
	
	private void Update()
	{
		Connect();
	}
}
