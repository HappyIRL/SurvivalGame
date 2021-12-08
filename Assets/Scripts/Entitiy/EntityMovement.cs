using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;
using Vector3 = UnityEngine.Vector3;

namespace Assets.Scripts
{
	public class EntityMovement : MonoBehaviour
	{
		private NavMeshAgent agent;

		private float speed = 10f;
		private float stoppingDistance = 1f;

		private void Awake()
		{
			if (TryGetComponent(out NavMeshAgent oldAgent))
			{
				DestroyImmediate(oldAgent);
				Debug.Log("EntityMovement or a derivative will add a NavMeshAgent, do not add one yourself");
			}
			agent = gameObject.AddComponent<NavMeshAgent>();
		}

		private void Start()
		{
			agent.autoBraking = true;
			agent.speed = speed;
			agent.stoppingDistance = stoppingDistance;
		}

		protected void MoveToVector(Vector3 vector)
		{
			agent.transform.forward = vector - agent.transform.position;
			agent.velocity = agent.transform.forward * speed;
			agent.SetDestination(vector);
		}
	}
}
