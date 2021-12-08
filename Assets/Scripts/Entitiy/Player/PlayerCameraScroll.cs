using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
	public class PlayerCameraScroll : MonoBehaviour
	{
		[Inject] private PlayerInputHandler playerInput;

		[SerializeField] private int MaxZoomOut;
		[SerializeField] private int MaxZoomIn;


		private Camera camera;

		private void Awake()
		{
			camera = GetComponent<Camera>();
		}

		private void OnEnable()
		{
			playerInput.Scroll += OnScroll;
		}

		private void OnScroll(int scrollDelta)
		{
			camera.transform.position = new Vector3(transform.position.x, Mathf.Clamp(-scrollDelta + camera.transform.position.y, MaxZoomOut, MaxZoomIn), transform.position.z);
		}

		private void OnDisable()
		{
			playerInput.Scroll -= OnScroll;
		}
	}
}