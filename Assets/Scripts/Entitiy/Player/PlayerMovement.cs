using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
	public class PlayerMovement : EntityMovement
	{
		[Inject] private PlayerInput playerInput;
		[Inject] private PlayerCamera playerCamera;

		private void OnEnable()
		{
			playerInput.Mouse1Down += OnMouse1Down;
		}

		private void OnMouse1Down(Vector3 mousePosition)
		{
			Vector3? objPoint = playerCamera.MousePositionToObjPoint(mousePosition);

			if (objPoint == null) return;

			MoveToVector(objPoint.Value);
		}

		private void OnDisable()
		{
			playerInput.Mouse1Down -= OnMouse1Down;

		}
	}
}