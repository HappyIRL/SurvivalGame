using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts
{
	public class PlayerInput : MonoBehaviour
	{
		public Action<Vector3> Mouse1Down;

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Mouse1))
			{
				Mouse1Down?.Invoke(Input.mousePosition);
			}
		}
	}
}