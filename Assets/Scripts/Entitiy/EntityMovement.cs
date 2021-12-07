using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts
{
	public class EntityMovement : MonoBehaviour
	{
		private NavMeshAgent agent;

		private void Start()
		{
			if (!TryGetComponent<NavMeshAgent>(out agent))
			{
				Debug.LogError("NavMeshAgent wasn't found on " + this);
				return;
			}
		}

		protected void MoveToVector(Vector3 vector)
		{
			agent.destination = vector;
		}
	}
}
