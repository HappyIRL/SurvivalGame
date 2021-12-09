using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
	public interface ISelectable
	{
		public void Select();
		public void DeSelect();
	}
}
