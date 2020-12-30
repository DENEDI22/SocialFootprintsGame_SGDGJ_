using System.Reflection;
using UnityEngine;

namespace DefaultNamespace
{
	public class ConnectionJoint : MonoBehaviour
	{
		public Transform inputJoint;
		public Transform outputJoint;
		private bool isOutput;
		public string outputJointTag;
	}
}