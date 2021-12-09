using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Assets.Scripts
{
	public class PlayerCameraMove : MonoBehaviour
	{
		[Inject] private PlayerInputHandler playerInput;

		[SerializeField] private float maxZoomOut = 12;
		[SerializeField] private float maxZoomIn = 4;

		[SerializeField] private float panSpeed = 1f;

		//When the camera should start moving when reaching a certain distance to the boarder;
		[SerializeField] private float moveScreenDistanceFromBoarder = 100f;

		private Utils.Float2MinMax moveScreenTriggerX;
		private Utils.Float2MinMax moveScreenTriggerY;

		private Vector3 cameraPos;
		private Vector2 mousePos;



		private Camera camera;

		private void Awake()
		{
			camera = GetComponent<Camera>();
		}

		private void OnEnable()
		{
			playerInput.Scroll += OnScroll;
			playerInput.MousePosChange += OnMousePosChange;
		}

		private void Start()
		{
			moveScreenTriggerX = new Utils.Float2MinMax(moveScreenDistanceFromBoarder, Screen.width - moveScreenDistanceFromBoarder);

			moveScreenTriggerY = new Utils.Float2MinMax(moveScreenDistanceFromBoarder, Screen.height - moveScreenDistanceFromBoarder);
		}

		private void OnMousePosChange(Vector2 mousePos)
		{
			this.mousePos = mousePos;
		}

		private void Update()
		{
			cameraPos = camera.transform.position;

			if (mousePos.x <= moveScreenTriggerX.min)
				cameraPos.x -= panSpeed * Time.deltaTime;
			if (mousePos.x >= moveScreenTriggerX.max)
				cameraPos.x += panSpeed * Time.deltaTime;
			if (mousePos.y <= moveScreenTriggerY.min)
				cameraPos.z -= panSpeed * Time.deltaTime;
			if (mousePos.y >= moveScreenTriggerY.max)
				cameraPos.z += panSpeed * Time.deltaTime;

			camera.transform.position = cameraPos;
		}

		private void OnScroll(int scrollDelta)
		{
			camera.transform.position = new Vector3(transform.position.x, Mathf.Clamp(-scrollDelta + camera.transform.position.y, maxZoomIn, maxZoomOut), transform.position.z);
		}

		private void OnDisable()
		{
			playerInput.Scroll -= OnScroll;
			playerInput.MousePosChange -= OnMousePosChange;

		}
	}
}