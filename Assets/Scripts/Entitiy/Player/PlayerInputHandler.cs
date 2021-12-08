using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts
{
	public class PlayerInputHandler : MonoBehaviour
	{
		private SurvivalInputActions survivalInputAction;

		public event Action<int> Scroll;
		public event Action MouseButton1;


		private void Awake()
		{
			survivalInputAction = new SurvivalInputActions();
		}

		private void OnEnable()
		{
			survivalInputAction.Player.MouseButton1.performed += OnMouseButton1;
			survivalInputAction.Player.MouseButton1.Enable();

			survivalInputAction.Player.Scroll.performed += OnScroll;
			survivalInputAction.Player.Scroll.Enable();

		}

		private void OnMouseButton1(InputAction.CallbackContext obj)
		{
			MouseButton1?.Invoke();
		}


		private void OnScroll(InputAction.CallbackContext obj)
		{
			Vector2 mouseDelta = obj.ReadValue<Vector2>();

			Scroll?.Invoke((int)mouseDelta.y);
		}

		private void OnDisable()
		{
			survivalInputAction.Player.MouseButton1.performed -= OnMouseButton1;
			survivalInputAction.Player.MouseButton1.Disable();

			survivalInputAction.Player.Scroll.performed -= OnScroll;
			survivalInputAction.Player.Scroll.Disable();
		}
	}
}
