using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts
{
	public class EntityMovement : MonoBehaviour, IMoveable
	{
		private NavMeshAgent agent;

		private float speed = 10f;
		private float stoppingDistance = 0.1f;

		protected virtual void Awake()
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

		public virtual void Move(Vector3 destination)
		{
			agent.transform.forward = destination - agent.transform.position;
			agent.velocity = agent.transform.forward * speed;
			agent.SetDestination(destination);
		}
	}
}
