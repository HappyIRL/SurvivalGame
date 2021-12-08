using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Assets.Scripts
{
	public class PlayerMovement : EntityMovement
	{
		[Inject] private PlayerCamera playerCamera;
		[Inject] private PlayerInputHandler inputHandler;

		//Getting called from Unity their PlayerInput

		private void OnEnable()
		{
			inputHandler.MouseButton1 += OnMouseButton1;
		}

		private void OnMouseButton1()
		{
			Vector3? objPoint = playerCamera.MousePositionToObjPoint(Mouse.current.position.ReadValue());

			if (objPoint == null) return;

			MoveToVector(objPoint.Value);
		}

		private void OnDisable()
		{
			inputHandler.MouseButton1 -= OnMouseButton1;
		}
	}
}