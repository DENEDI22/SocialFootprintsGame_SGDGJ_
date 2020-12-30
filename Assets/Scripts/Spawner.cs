using System;
using System.Linq;
using System.Security.Cryptography;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour, IPointerClickHandler
{
	[SerializeField] private GameObject[] spawnObjects;
	[SerializeField] private Transform parent;
	[SerializeField] private Transform[] spawnPoints;
	[SerializeField] private bool makeConnection;
	[SerializeField] private bool destroyAfterSpawning;
	[SerializeField] private string[] originTags;
	private Transform originConnectionPoint;
	[SerializeField] private GameObject connection;

	private void Awake()
	{
		spawnPoints = GameObject.Find("SpawnPoints").GetComponentsInChildren<Transform>();
		parent = GameObject.FindWithTag("MainCanvas").GetComponent<Transform>();
	}
	public void SpawnObject()
	{
		GameObject obj = spawnObjects[Random.Range(0, spawnObjects.Length)];
		GameObject tmp;
		if (FindObjectsOfType<ConnectionJoint>().ToList()
			    .Find(item => item.outputJointTag == obj.GetComponent<ConnectionJoint>().outputJointTag) == null)
		{
			tmp = GameObject.Instantiate(obj, parent);
			tmp.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
		}
		else
		{
			tmp = FindObjectsOfType<ConnectionJoint>().ToList()
				.Find(item => item.outputJointTag == obj.GetComponent<ConnectionJoint>().outputJointTag).gameObject;
		}
		if (makeConnection)
		{
			foreach (var VARIABLE in originTags)
			{
				originConnectionPoint = FindObjectsOfType<ConnectionJoint>().ToList()
					.Find(item => item.outputJointTag == VARIABLE).outputJoint;
				var connector = GameObject.Instantiate(connection).GetComponent<Connector>();
				connector.aPoint = originConnectionPoint;
				connector.bPoint = tmp.GetComponent<ConnectionJoint>().inputJoint;
				connector.Connect();
			}
		}
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		SpawnObject();
		if (destroyAfterSpawning)
		{
			Destroy(this);
		}
	}
}