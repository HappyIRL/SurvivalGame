using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
	public class PlayerCamera : MonoBehaviour
	{
		private Camera camera;

		private void Awake()
		{
			camera = GetComponent<Camera>();
		}

		public Vector3? MousePositionToObjPoint(Vector2 mousePosition)
		{
			Ray ray = camera.ScreenPointToRay(mousePosition);

			if (Physics.Raycast(ray, out RaycastHit hit))
			{
				return hit.point;
			}

			return null;
		}
	}
}