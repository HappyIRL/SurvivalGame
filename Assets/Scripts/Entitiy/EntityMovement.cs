using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts
{
	public class EntityMovement : MonoBehaviour
	{
		private NavMeshAgent agent;

		private float speed = 10f;
		private float stoppingDistance = 0.1f;

		private Vector3 destination;

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
			destination = vector;
			agent.transform.forward = vector - agent.transform.position;
			agent.velocity = agent.transform.forward * speed;
			agent.SetDestination(vector);
		}

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.green;
			Gizmos.DrawCube(destination, new Vector3(0.1f, 0.1f, 0.1f));
		}
	}
}
