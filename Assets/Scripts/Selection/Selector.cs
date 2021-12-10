using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace Assets.Scripts
{
	public class Selector : PlayerInputEventsBehaviour
	{
		[Zenject.Inject] private PlayerCamera playerCamera;

		private List<Collider> selected = new List<Collider>();
		public ReadOnlyCollection<Collider> Selected => selected.AsReadOnly();

		private Vector3 startPos;

		protected override void OnMouse0Started(Vector2 mousePos)
		{
			RaycastHit? hit = playerCamera.MouseToWorldRay(mousePos);
			if (hit == null) return;
			startPos = hit.Value.point;
		}

		protected override void OnMouse0Cancled(Vector2 mousePos)
		{
			RaycastHit? hit = playerCamera.MouseToWorldRay(mousePos);
			if (hit == null) return;

			DisposeOldSelection();

			Collider[] colliders = GetCollidersBetweenPoints(startPos, hit.Value.point);

			if(colliders.Length > 0)
				NewSelection(colliders);
		}

		private Collider[] GetCollidersBetweenPoints(Vector3 point1, Vector3 point2)
		{
			Vector3 center = new Vector3((point1.x + point2.x) / 2, (point1.y + point2.y) / 2, (point1.z + point2.z) / 2);

			Collider[] colliders = Physics.OverlapBox(center, new Vector3(Mathf.Abs(point1.x - point2.x) / 2, 1, Mathf.Abs(point1.z - point2.z) / 2));

			return colliders;
		}

		private void NewSelection(Collider[] colliders)
		{
			foreach (Collider collider in colliders)
			{
				if (collider.TryGetComponent(out ISelectable selectable))
				{
					selectable.Select();
					selected.Add(collider);
				}
			}
		}

		private void DisposeOldSelection()
		{
			foreach (Collider collider in selected)
			{
				collider.GetComponent<ISelectable>().DeSelect();
			}

			selected.Clear();
		}
	}
}
