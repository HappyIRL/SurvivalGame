using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{

	//Make this an interface? Something like IPlayerMoveable
	public class PlayerEntitiesMover : PlayerInputEventsBehaviour
	{


		[Zenject.Inject] private PlayerCamera playerCamera;
		[Zenject.Inject] private Selector selector;

		protected override void OnMouse1(Vector2 mousePos)
		{
			RaycastHit? hit = playerCamera.MouseToWorldRay(mousePos);
			if (hit == null) return;

			foreach (Collider selection in selector.Selected)
			{
				selection.TryGetComponent(out IMoveable moveable);
				moveable.Move(hit.Value.point);
			}
		}
	}
}