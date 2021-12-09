using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts
{
	public class PlayerInputHandler : MonoBehaviour
	{

		public event Action<Vector2> MousePosChange;
		public event Action<int> Scroll;
		public event Action<Vector2> MouseButton1;
		public event Action<Vector2> MouseButton0Started;
		public event Action<Vector2> MouseButton0Cancled;

		private SurvivalInputActions survivalInputAction;
		private SurvivalInputActions.PlayerActions playerActions;

		private Vector2 mousePos;


		private void Awake()
		{
			survivalInputAction = new SurvivalInputActions();
			playerActions = survivalInputAction.Player;
		}

		private void OnEnable()
		{
			playerActions.MouseButton0.started += OnMouseButton0Started;
			playerActions.MouseButton0.canceled += OnMouseButton0Cancled;
			playerActions.MouseButton0.Enable();

			playerActions.MouseButton1.started += OnMouseButton1Started;
			playerActions.MouseButton1.Enable();

			playerActions.Scroll.performed += OnScroll;
			playerActions.Scroll.Enable();

			playerActions.MousePositionChange.performed += OnMousePosChanged;
			playerActions.MousePositionChange.Enable();
		}

		private void Start()
		{
			mousePos = Mouse.current.position.ReadValue();
		}

		private void OnMouseButton1Started(InputAction.CallbackContext obj)
		{
			MouseButton1?.Invoke(mousePos);
		}

		private void OnMouseButton0Started(InputAction.CallbackContext obj)
		{
			MouseButton0Started?.Invoke(mousePos);
		}

		private void OnMouseButton0Cancled(InputAction.CallbackContext obj)
		{
			MouseButton0Cancled?.Invoke(mousePos);
		}

		private void OnMousePosChanged(InputAction.CallbackContext obj)
		{
			mousePos = obj.ReadValue<Vector2>();

			MousePosChange?.Invoke(mousePos);
		}

		private void OnScroll(InputAction.CallbackContext obj)
		{
			Vector2 mouseDelta = obj.ReadValue<Vector2>();

			Scroll?.Invoke((int)mouseDelta.y);
		}

		private void OnDisable()
		{
			playerActions.MouseButton1.performed -= OnMouseButton1Started;
			playerActions.MouseButton1.Disable();

			playerActions.MouseButton0.performed -= OnMouseButton0Started;
			playerActions.MouseButton0.Disable();

			playerActions.Scroll.performed -= OnScroll;
			playerActions.Scroll.Disable();
			
			playerActions.MousePositionChange.performed -= OnMousePosChanged;
			playerActions.MousePositionChange.Disable();
		}
	}
}
