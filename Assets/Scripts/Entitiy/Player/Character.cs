using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
	public class Character : MonoBehaviour, ISelectable
	{
		private bool isSelected = false;

		public bool IsSelected => isSelected;

		public void Select()
		{
			isSelected = true;

		}

		public void DeSelect()
		{
			isSelected = false;
		}
	}
}