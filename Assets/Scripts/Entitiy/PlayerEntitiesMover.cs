using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
	public class PlayerEntitiesMover : MonoBehaviour
	{
		[Inject] private PlayerCamera playerCamera;
		[Inject] private PlayerInputHandler inputHandler;
		[Inject] private Selector selector;

		private void OnEnable()
		{
			inputHandler.MouseButton1 += OnMouseButton1;
		}

		private void OnMouseButton1(Vector2 mousePos)
		{
			RaycastHit? hit = playerCamera.MouseToWorldRay(mousePos);
			if (hit == null) return;

			foreach (Collider selection in selector.Selected)
			{
				selection.TryGetComponent(out IMoveable moveable);
				moveable.Move(hit.Value.point);
			}
		}

		private void OnDisable()
		{
			inputHandler.MouseButton1 -= OnMouseButton1;
		}


	}
}