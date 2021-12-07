using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
	public class PlayerCamera : MonoBehaviour
	{
		private Camera camera;

		private void Start()
		{
			if (!TryGetComponent(out camera))
			{
				Debug.LogError("Camera wasn't found on " + this);
				return;
			}
		}

		public Vector3? MousePositionToObjPoint(Vector3 mousePosition)
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